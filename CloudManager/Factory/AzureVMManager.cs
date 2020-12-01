namespace CloudManager.Factory{
    using System;
    using CloudManager.Models;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    public class AzureVMManager : ICloudProviderVMService{
        private ICredentials _credential;
        private IAzure _azure;
        private IVMWare _vmware;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        public AzureVMManager(){

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
                authenticate();
                createResourceGroup();
                createVNWare();
            }            
        }
        private void authenticate(){
           var credentials = SdkContext.AzureCredentialsFactory
                            .FromServicePrincipal(_credential.clientID,
                                _credential.clientSecret,
                                _credential.tenantID,
                                AzureEnvironment.AzureGlobalCloud);
            _azure = Azure
                        .Configure()
                        .Authenticate(credentials)
                        .WithSubscription(_credential.subscriptionID);
           
        }     

        private void createResourceGroup(){
            var resourceGroup = _azure.ResourceGroups.Define(_resourceGroup.groupName)
                .WithRegion(_resourceGroup.location)
                .Create();
        }

        private void createVNWare(){
             var network = _azure.Networks.Define(_vmware.vNetName)
                .WithRegion(_resourceGroup.location)
                .WithExistingResourceGroup(_resourceGroup.groupName)
                .WithAddressSpace(_vmware.vNetAddress)
                .WithSubnet(_vmware.subnetName, _vmware.subnetAddress)
                .Create();

            var nic = _azure.NetworkInterfaces.Define(_vmware.nicName)                
                .WithRegion(_resourceGroup.location)                
                .WithExistingResourceGroup(_resourceGroup.groupName)                
                .WithExistingPrimaryNetwork(network)                
                .WithSubnet(_vmware.subnetName)                
                .WithPrimaryPrivateIPAddressDynamic()                
                .Create();

            _azure.VirtualMachines.Define(_vmware.Name)                
                .WithRegion(_resourceGroup.location)                
                .WithExistingResourceGroup(_resourceGroup.groupName)               
                .WithExistingPrimaryNetworkInterface(nic)                
                .WithLatestWindowsImage("MicrosoftWindowsServer", "WindowsServer","2012-R2-Datacenter")
                .WithAdminUsername(_vmware.adminUser)
                .WithAdminPassword(_vmware.adminPassword)
                .WithComputerName(_vmware.Name)
                .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                .Create();                
        }

        public void deleteVM(){}

        public void updateVM(){}
    }
}