namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class IGSVMManager : ICloudProviderVMService{
        private ICredentials _credential;
        private IVMWare _vmware;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public IGSVMManager(){

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
              Console.WriteLine("IGS vm create");
            }            
            else{
                Console.WriteLine("IGS properties null");
            }               
        }

        public void deleteVM(){}

        public void updateVM(){}

      
    }
}