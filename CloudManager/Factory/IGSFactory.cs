namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class IGSFactory : CloudProviderFactory{
        public override ICloudProvider GetCloudProviderServices(string cloudProviderServices){
            switch(cloudProviderServices){
                case "ManageVMWare":
                    return new IGSVMManager();                
                case "ManageDatabase":
                    return new IGSDBManager();
                default:
                    return null;
                
            }
        }        
    }
}