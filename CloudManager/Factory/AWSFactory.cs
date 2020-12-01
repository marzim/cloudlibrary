namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AWSFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "ManageVMWare":
                    return new AWSVMManager();            
                case "ManageDatabase":
                    return new AWSDBManager();
                default:
                    return null;
                
            }
        }        
    }
}