using YamlDotNet.Serialization;

namespace pmis.profile
{
    public class Profile
    {

        public delegate void ProfileChangeHandler(Profile profile);

        public Profile()
        {

        }

        public Profile(string profileName)
        {
            this.ProfileName = profileName;
        }

        [YamlMember(Alias = "profile.name")]
        public string ProfileName { get; set; }

        [YamlMember(Alias = "pmis.project.code")]
        public string PmisProjectCode { get; set; }

        [YamlMember(Alias = "pmis.api.url")]
        public string PmisApiUrl { get; set; }

        [YamlMember(Alias = "register.folder.uri")]
        public string RegisterFolderUri { get; set; }

        [YamlMember(Alias = "picture.folder.uri")]
        public string PictureFolderUri { get; set; }

        [YamlMember(Alias = "language")]
        public string Language { get; set; }

        [YamlMember(Alias = "sqlite.db.location")]
        public string SqliteDbLocation { get; set; }

        [YamlMember(Alias = "db.type")]
        public string DbType { get; set; }

        [YamlMember(Alias = "register.status")]
        public string[] RegisterStatus { get; set; }

        [YamlMember(Alias = "register.discipline")]
        public string[] RegisterDiscipline { get; set; }

        [YamlMember(Alias = "register.type")]
        public string[] RegisterType { get; set; }
        
    }
}
