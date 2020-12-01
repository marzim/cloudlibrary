namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    public abstract class CloudProviderFactory{
        public abstract ICloudProvider GetCloudProviderServices(string cloudProvider);

        public static CloudProviderFactory CreateCloudProviderFactory(string factoryType){
            switch(factoryType){
                case "Azure":
                    return new AzureFactory();
                                
                case "AWS":
                    return new AWSFactory();
                
                default:
                    return new IGSFactory();
                
            }
        }
    }
}