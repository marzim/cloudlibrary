using System;

namespace CloudManager.Models
{
    public interface IVMWare
    {
        string Name { get; set; }
        string vNetName { get; set; }
        string vNetAddress { get; set; }         
        string subnetName { get; set; }         
        string subnetAddress { get; set; }           
        string nicName { get; set; }          
        string adminUser { get; set; }           
        string adminPassword { get; set; }

        ICredentials credentials { set; }

        IResourceGroup resourceGroup { set; }

        void create();

        void delete();

        void update();

    }
}
