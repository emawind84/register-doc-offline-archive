using pmis.profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace pmis
{
    public static class ProfileService
    {
        public static Profile.ProfileChangeHandler ProfileChanged;

        public static string ProfileHome
        {
            get {
                var dataFolder = AppConfig.AppDataFullPath;
                return Path.Combine(dataFolder, "data");
            }
        }

        /// <summary>
        /// Build a profile object from the current application settings
        /// </summary>
        /// <returns></returns>
        public static Profile BuildCurrentProfile()
        {
            var statuses = new String[Properties.Settings.Default.register_status.Count];
            var disciplines = new String[Properties.Settings.Default.register_discipline.Count];
            var types = new String[Properties.Settings.Default.register_type.Count];

            Properties.Settings.Default.register_status.CopyTo(statuses, 0);
            Properties.Settings.Default.register_discipline.CopyTo(disciplines, 0);
            Properties.Settings.Default.register_type.CopyTo(types, 0);

            return new Profile()
            {
                ProfileName = Properties.Settings.Default.current_profile,
                PmisProjectCode = Properties.Settings.Default.pmis_project_code,
                PmisApiUrl = Properties.Settings.Default.pmis_api_url,
                RegisterFolderUri = Properties.Settings.Default.register_folder_uri,
                PictureFolderUri = Properties.Settings.Default.picture_folder_uri,
                Language = Properties.Settings.Default.language,
                DbType = Properties.Settings.Default.db_type,
                SqliteDbLocation = Properties.Settings.Default.sqlite_db_location,
                RegisterStatus = statuses,
                RegisterDiscipline = disciplines,
                RegisterType = types
            };
        }

        /// <summary>
        /// Check if the profile exists
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        public static bool ProfileExists(string profileName)
        {
            var profilepath = Path.Combine(ProfileHome, "profile." + profileName + ".yaml");
            return File.Exists(profilepath);
        }

        /// <summary>
        /// Create a new profile object and create a yaml file inside the profile folder
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Profile CreateProfile(string name)
        {
            if ( String.IsNullOrEmpty( name ) )
            {
                throw new ArgumentException("The profile name is not valid.");
            }

            if (ProfileExists(name))
            {
                throw new Exception("Profile already present.");
            }

            var profile = BuildCurrentProfile();
            profile.ProfileName = name;
            SaveProfile(profile);

            return profile;
        }

        /// <summary>
        /// Save a profile object into a yaml file
        /// </summary>
        /// <param name="profile"></param>
        public static void SaveProfile(Profile profile)
        {
            WriteProfile(profile);
        }

        /// <summary>
        /// Load a profile given a profile name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The loaded profile object</returns>
        public static Profile LoadProfile(string name)
        {
            var profilepath = Path.Combine(ProfileHome, "profile." + name + ".yaml");

            var deserializer = new DeserializerBuilder()
                //.WithNamingConvention(new CamelCaseNamingConvention())
                .IgnoreUnmatchedProperties()
                .Build();

            try
            {
                using (StreamReader reader = new StreamReader(File.Open(profilepath, FileMode.Open)))
                {
                    var profile = deserializer.Deserialize<Profile>(reader);
                    return profile;
                }
            } catch (FileNotFoundException ex)
            {
                throw new Exception(String.Format("The profile {0} doesn't exist.", name), ex);
            }
        }

        /// <summary>
        /// Delete a profile given the profile name
        /// </summary>
        /// <param name="name"></param>
        public static void DeleteProfile(string name)
        {
            var profilepath = Path.Combine(ProfileHome, "profile." + name + ".yaml");
            if (File.Exists(profilepath))
                File.Delete(profilepath);
        }

        /// <summary>
        /// Given a profile object update the application default settings
        /// </summary>
        /// <param name="profile"></param>
        public static void ChangeProfile(Profile profile)
        {
            Properties.Settings.Default.current_profile = profile.ProfileName;
            Properties.Settings.Default.pmis_project_code = profile.PmisProjectCode;
            Properties.Settings.Default.pmis_api_url = profile.PmisApiUrl;
            Properties.Settings.Default.register_folder_uri = profile.RegisterFolderUri;
            Properties.Settings.Default.picture_folder_uri = profile.PictureFolderUri;
            Properties.Settings.Default.sqlite_db_location = profile.SqliteDbLocation;
            Properties.Settings.Default.db_type = profile.DbType;
            Properties.Settings.Default.language = profile.Language;

            Properties.Settings.Default.register_status.Clear();
            Properties.Settings.Default.register_status.AddRange(profile.RegisterStatus);

            Properties.Settings.Default.register_discipline.Clear();
            Properties.Settings.Default.register_discipline.AddRange(profile.RegisterDiscipline);

            Properties.Settings.Default.register_type.Clear();
            Properties.Settings.Default.register_type.AddRange(profile.RegisterType);

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            // publish profile changed event
            ProfileChanged?.Invoke(profile);
        }

        /// <summary>
        /// Load all the profiles available
        /// </summary>
        /// <returns></returns>
        public static List<Profile> LoadProfiles()
        {
            var list = new List<Profile>();
            //list.Add(new Profile("Default"));

            string pattern = @"profile\.(.*)\.yaml";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            DirectoryInfo dataDir = new DirectoryInfo(ProfileHome);
            FileInfo[] files = dataDir.GetFiles();
            foreach (FileInfo file in files)
            {
                MatchCollection matches = rgx.Matches(file.Name);
                if (matches.Count > 0)
                {
                    list.Add(new Profile(matches[0].Groups[1].Value));
                }
            }

            return list;
        }

        private static void WriteProfile(Profile profile)
        {
            if (!Directory.Exists(ProfileHome))
                Directory.CreateDirectory(ProfileHome);

            var serializer = new SerializerBuilder()
                //.WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            var yaml = serializer.Serialize(profile);
            var profilepath = Path.Combine(ProfileHome, "profile." + profile.ProfileName + ".yaml");
            using (FileStream stream =
                File.Open(profilepath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(yaml);
                }
            }

        }
    }
}
