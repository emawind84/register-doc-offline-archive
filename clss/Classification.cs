using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.clss
{
    public class Classification
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string UpCode { get; set; }

        public string Level { get; set; }

        public override string ToString()
        {
            return String.Format("Clss [{0}, {1}, {2}]",
                Code,
                Name, 
                Level );
        }
    }
}
