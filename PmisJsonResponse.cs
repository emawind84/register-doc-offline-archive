using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_test
{
    public class PmisJsonResponse<T>
    {
        public List<T> List
        {
            get; set;
        }
    }
}
