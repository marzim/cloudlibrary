namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AzureFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "AzureManageVMWare":
                    return new AzureVMManager();                
                case "AzureManageDatabase":
                    return new AzureDBManager();
                default:
                    return null;
                
            }
        }
    }
}