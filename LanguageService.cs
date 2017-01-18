using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public class LanguageService
    {
        private ResXResourceSet resSet;

        private static string subFolder = "i18n/";
        
        public LanguageService(String locale)
        {
            resSet = new ResXResourceSet(String.Format(@"{0}{1}.resx", subFolder, locale));
        }

        public string Get(string key)
        {
            return resSet.GetString(key);
        }
    }
}
