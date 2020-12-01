namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AWSVMManager : ICloudProviderVMService{
        private ICredentials _credential;
        private IVMWare _vmware;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public AWSVMManager(){

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
                 Console.WriteLine("aws vm create");
            }            
            else{
                Console.WriteLine("aws properties null");
            }            
        }

         public void deleteVM()
        {
            Console.WriteLine("Deleting VM instance...");
        }

        public void updateVM()
        {
            Console.WriteLine("Updating VM instance...");
        }

        
    }
}