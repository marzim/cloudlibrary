using System;
using CloudManager.Models;

namespace CloudManager.Decorators
{
    public abstract class VMWareDecorator : IVMWare
    {
        protected IVMWare _vmware;

        protected VMWareDecorator(IVMWare vmware)
        {
            this._vmware = vmware;
        }

        private string _name;
        private string _vNetName;
        private string _vNetAddress;    
        private string _subnetName;       
        private string _subnetAddress;           
        private string _nicName;       
        private string _adminUser;        
        private string _adminPassword; 

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

        public virtual string create(ICredentials credentials)
        {
           return _vmware.create(credentials);
        }
    }

    
}
