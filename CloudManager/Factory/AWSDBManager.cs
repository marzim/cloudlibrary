namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public class AWSDBManager : ICloudProviderDBService{
        private ICredentials _credential;
        private IVMWare _vmware;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public AWSDBManager(){

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
                Console.WriteLine("aws DB create");
            }            
            else{
                Console.WriteLine("aws properties null");
            }                           
        }

        public void deleteDB()
        {
            Console.WriteLine("Deleting DB...");
        }

        public void updateDB()
        {
            Console.WriteLine("Updating DB...");
        }

       
    }
}