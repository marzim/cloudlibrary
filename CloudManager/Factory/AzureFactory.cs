namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AzureFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "ManageVMWare":
                    return new AzureVMManager();                
                case "ManageDatabase":
                    return new AzureDBManager();
                default:
                    return null;
                
            }
        }        
    }
}