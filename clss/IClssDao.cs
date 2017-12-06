using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.clss
{
    public interface IClssDao
    {
        void UpdateClassificationData(Classification clss);

        DataTable LoadClassificationList(int level, string upcode = null);

        void DeleteClassificationData();
    }
}
