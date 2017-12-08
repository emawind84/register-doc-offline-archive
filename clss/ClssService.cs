using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.clss
{
    public class ClssService
    {
        public event EventHandler ImportComplete;

        private IClssDao daoService;
        private bool updating = false;

        public ClssService(IClssDao daoService)
        {
            this.daoService = daoService;

            // update classification data
            //UpdateClassificationData();

        }

        public async Task UpdateClassificationData()
        {
            if (updating) return;
            updating = true;
            LogUtil.Log("UpdateClassificationData called");
            try
            {
                // first we delete all clss
                daoService.DeleteClassificationData();

                var types = new String[Properties.Settings.Default.register_type.Count];
                Properties.Settings.Default.register_type.CopyTo(types, 0);
                foreach (string t in types)
                {
                    Classification c = new Classification();
                    var tt = t.Split(',');
                    c.Level = tt[0];
                    c.Name = tt[1];
                    c.Code = tt[2];
                    c.UpCode = tt[3];
                    //LogUtil.Log("Importing " + c);
                    await Task.Run(() => daoService.UpdateClassificationData(c));
                }
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
            finally
            {
                updating = false;
            }

            OnImportComplete(EventArgs.Empty);
        }

        public DataTable LoadClassificationList(int level=0, string upcode=null)
        {
            try
            {
                LogUtil.Log(String.Format("Loading clss level {0}, upcode {1}", level, upcode));
                return daoService.LoadClassificationList(level, upcode);
            }
            catch (Exception e)
            {
                e.Log();
                throw e;
            }
        }

        protected virtual void OnImportComplete(EventArgs e)
        {
            ImportComplete?.Invoke(this, e);
        }

    }
}
