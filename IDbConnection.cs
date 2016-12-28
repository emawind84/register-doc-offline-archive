using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public interface IDbConnection
    {
        /// <summary>
        /// Open the db connection
        /// </summary>
        void Open();

        /// <summary>
        /// Close the db connection
        /// </summary>
        void Close();

    }
}
