using System;

namespace CloudManager.Models
{
    public class VMWare : IVMWare
    {
        private string _name;
        private string _vNetName;
        private string _vNetAddress;    
        private string _subnetName;       
        private string _subnetAddress;           
        private string _nicName;       
        private string _adminUser;        
        private string _adminPassword; 

        private ICredentials _credentials;

        private IResourceGroup _resourceGroup;

        public string Name{
            get{ return _name; }
            set{ _name = value; }
        }

        public string vNetName{
            get{ return _vNetName; }
            set{ _vNetName = value; }
        }

        public string vNetAddress{
            get{ return _vNetAddress; }
            set{ _vNetAddress = value; }
        }

        public string subnetName{
            get{ return _subnetName; }
            set{ _subnetName = value; }
        }

        public string subnetAddress{
            get{ return _subnetAddress; }
            set{ _subnetAddress = value; }
        }

        public string nicName{
            get{ return _nicName; }
            set{ _nicName = value; }
        }

        public string adminUser{
            get{ return _adminUser; }
            set{ _adminUser = value; }
        }

        public string adminPassword{
            get{ return _adminPassword; }
            set{ _adminPassword = value; }
        }

        public ICredentials credentials{
            set{ _credentials = value; }
        }

        public IResourceGroup resourceGroup{
            set{ _resourceGroup = value;}
        }

        public void create(){}

        public void delete(){}

        public void update(){}

    }

    
}
