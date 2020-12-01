namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class IGSFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "IGSManageVMWare":
                    return new IGSVMManager();                
                case "IGSManageDatabase":
                    return new IGSDBManager();
                default:
                    return null;
                
            }
        }        
    }
}