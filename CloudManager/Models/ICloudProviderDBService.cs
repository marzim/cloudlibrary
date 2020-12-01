using System;

namespace CloudManager.Models{
    public interface ICloudProviderDBService : ICloudProvider{

        void deleteDB();

        void updateDB();

        ICredentials credentials {set;}
        
        IResourceGroup resourceGroup {set;}

        IVMWare vmware {set;}
    }
}