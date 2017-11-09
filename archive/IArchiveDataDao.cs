using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.archive
{
    public interface IArchiveDataDao
    {

        Archive LoadArchive(string id);

        DataTable SearchArchive(Dictionary<string, object> criteria = null);

        void ImportArchiveData(Archive a);

        void DeleteArchive();

    }
}
