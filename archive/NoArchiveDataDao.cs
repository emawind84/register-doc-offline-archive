using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.archive
{
    class NoArchiveDataDao : IArchiveDataDao
    {
        public void DeleteArchive()
        {
            throw new NotImplementedException();
        }

        public void ImportArchiveData(Archive a)
        {
            throw new NotImplementedException();
        }

        public Archive LoadArchive(string id)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchArchive(Dictionary<string, object> criteria = null)
        {
            throw new NotImplementedException();
        }
    }
}
