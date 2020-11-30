namespace CloudManager.Models{
    using System;

    public class Database : IDatabase{
        private string _name;
        private string _adminUser;
        private string _adminPassword;
        private string _serverVersion;

        public string name{
            get { return _name; }
            set { _name = value; }
        }

        public string adminUser{
            get { return _adminUser; }
            set { _adminUser = value; }
        }

        public string adminPassword{
            get { return _adminPassword; }
            set { _adminPassword = value; }
        }

        public string serverVersion{
            get { return _serverVersion; }
            set { _serverVersion = value; }
        }

        public string create(){ return "";}

    }
}