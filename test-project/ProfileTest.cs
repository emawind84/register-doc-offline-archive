using Microsoft.VisualStudio.TestTools.UnitTesting;
using pmis;
using pmis.profile;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archiveTest
{
    [TestClass]
    public class ProfileTest
    {
        [TestInitialize]
        public void setup()
        {
            AppConfig.InitConfig();
        }

        [TestCleanup]
        public void cleanup()
        {
            var profilename = "My Profile";
            var profilepath = Path.Combine(ProfileService.ProfileHome, "profile." + profilename + ".yaml");
            File.Delete(profilepath);
        }

        [TestMethod]
        public void SaveProfile()
        {
            // save my test profile
            ProfileService.SaveProfile(createTestProfile());

            // load the saved profile
            var profile = ProfileService.LoadProfile("My Profile");

            // check if has been saved
            Assert.IsNotNull(profile);
            Assert.AreEqual("My Profile", profile.ProfileName);
            Assert.IsTrue(profile.RegisterStatus.Length > 0);
            Assert.IsTrue(profile.RegisterDiscipline.Length > 0);
            Assert.IsTrue(profile.RegisterType.Length > 0);

            // change properties and save again
            profile.Language = "en_US";
            profile.PmisProjectCode = "PJT2";
            ProfileService.SaveProfile(profile);

            profile = ProfileService.LoadProfile("My Profile");
            Assert.AreEqual("en_US", profile.Language);
            Assert.AreEqual("PJT2", profile.PmisProjectCode);
        }

        [TestMethod]
        public void LoadProfile()
        {
            // create test profile
            ProfileService.SaveProfile(createTestProfile());

            var profile = ProfileService.LoadProfile("My Profile");
            Assert.IsNotNull(profile);
            Assert.AreEqual("My Profile", profile.ProfileName);

            // load a profile that doesn't exist
            try
            {
                ProfileService.LoadProfile("My Profile 2");
                Assert.Fail();
            } catch (ApplicationException) { }
            
        }

        [TestMethod]
        public void DeleteProfile()
        {
            // create test profile
            var profilename = "My Profile";
            ProfileService.SaveProfile(createTestProfile());

            ProfileService.DeleteProfile(profilename);

            try
            {
                ProfileService.LoadProfile(profilename);
                Assert.Fail();
            }
            catch (Exception) { }
        }

        // Test profile
        private Profile createTestProfile()
        {
            var disciplines = new String[] { "dsc1", "dsc2", "dsc3" };
            var statuses = new String[] { "st1", "st2", "st3", "st4" };
            var types = new String[] { "type1", "type2", "type3" };

            return new Profile("My Profile")
            {
                DbType = "sqlite",
                SqliteDbLocation = "data/archive.db",
                Language = "en_US",
                PictureFolderUri = "pictures",
                RegisterFolderUri = "register",
                PmisProjectCode = "GLB_PMIS",
                PmisApiUrl = "http://dev.sangah.com",
                RegisterDiscipline = disciplines,
                RegisterStatus = statuses,
                RegisterType = types
            };
        }
    }
}
