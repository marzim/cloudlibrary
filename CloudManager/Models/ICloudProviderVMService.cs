using System;

namespace CloudManager.Models{
    public interface ICloudProviderVMService : ICloudProvider{

        void deleteVM();

        void updateVM();

        ICredentials credentials {set;}
        
        IResourceGroup resourceGroup {set;}

        IVMWare vmware {set;}
    }
}