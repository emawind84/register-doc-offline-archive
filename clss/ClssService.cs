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

        private IClssDao daoService;
        public event EventHandler ImportComplete;

        public ClssService(IClssDao daoService)
        {
            this.daoService = daoService;

            // update classification data
            //UpdateClassificationData();

        }

        public async void UpdateClassificationData()
        {
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

            OnImportComplete(EventArgs.Empty);
        }

        public DataTable LoadClassificationList(string level)
        {
            try
            {
                return daoService.LoadClassificationList(level);
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
