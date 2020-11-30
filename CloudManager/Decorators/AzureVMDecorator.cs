namespace CloudManager.Decorators{
    
    using System;
    using CloudManager.Models;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class AzureVMDecorator : VMWareDecorator
    {

        private ICredentials _credential;
        private CloudManager.Models.IResourceGroup _resourceGroup;
        private IAzure _azure;
        public AzureVMDecorator(IVMWare _vmware) : base(_vmware)
        {
            _credential = new Credentials();
            _credential.clientID = "client1";
            _credential.clientSecret = "this is very secret";
            _credential.subscriptionID = "1234";
            _credential.tenantID = "tenant1";
            
            _vmware.adminUser = "sampluser"; 
            _vmware.adminPassword = "secretpassword";
            _vmware.Name = "WinVM";
            _vmware.vNetName = "az204VNET";            
            _vmware.vNetAddress = "10.10.0.0/16";
            _vmware.nicName = "az204NIC";
            _vmware.subnetAddress = "10.10.0.0/24";
            _vmware.subnetName = "az204Subnet";

            _resourceGroup = new ResourceGroup();
            _resourceGroup.groupName = "resourceGroupName1";
            _resourceGroup.location = "eastus";            
        }

        public override string create(ICredentials _credential)
        {
            authenticate();
            createResourceGroup();
            createVNWare();
            return string.Empty;
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

        

    }
}