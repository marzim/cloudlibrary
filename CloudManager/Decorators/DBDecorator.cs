namespace CloudManager.Decorators{
    using System;
    using CloudManager.Models;

    public class DBDecorator : IDatabase{
        protected IDatabase database;

        private string _name;
        private string _adminUser;
        private string _adminPassword;
        private string _serverVersion;

        protected DBDecorator(IDatabase _database){
            this.database = _database;
        }

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

        public virtual void create(){
            database.create();
        }
    }
}