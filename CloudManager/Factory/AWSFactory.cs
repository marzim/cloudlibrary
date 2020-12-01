namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AWSFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "AWSManageVMWare":
                    return new AWSVMManager();            
                case "AWSManageDatabase":
                    return new AWSDBManager();
                default:
                    return null;
                
            }
        }        
    }
}