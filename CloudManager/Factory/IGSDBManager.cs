namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class IGSDBManager : ICloudProviderDBService{
        private ICredentials _credential;
        private IVMWare _vmware;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public IGSDBManager(){

        }
        public IVMWare vmware
        {
             set{ _vmware = value; }  
        }

        public CloudManager.Models.IResourceGroup resourceGroup
         {
             set{ _resourceGroup = value; }  
        }

        public ICredentials credentials 
        {
             set{ _credential = value; }  
        }
        public void create(){
            if( _credential != null && _resourceGroup != null && _vmware != null){
            }                 
        }

        public void deleteDB(){}

        public void updateDB(){}
    }
}