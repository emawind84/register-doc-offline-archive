using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis.register
{
    public interface IRegisterDocumentDao
    {
        /// <summary>
        /// Load a single document instance
        /// </summary>
        /// <param name="docno"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        RegisterDocument LoadDocument(string docno, string version = null);

        /// <summary>
        /// Import documents from outer source
        /// </summary>
        void ImportDocumentData(RegisterDocument d);

        /// <summary>
        /// Search through all documents
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        DataTable SearchDocument(Dictionary<string, object> criteria = null);

        /// <summary>
        /// Delete the entire register
        /// </summary>
        void DeleteRegisterData();

        int LoadRegisterCount();

    }
}
