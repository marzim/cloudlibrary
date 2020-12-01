namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    
    public class AzureDBManager : ICloudProviderDBService{
       private ICredentials _credential;
        private IDatabase _database;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public AzureDBManager(){

        }
        public IDatabase database
        {
             set{ _database = value; }  
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
            if( _credential != null && _resourceGroup != null && _database != null){
                Console.WriteLine("Azure DB create");
            }            
            else{
                Console.WriteLine("Azure properties null");
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