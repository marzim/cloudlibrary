namespace CloudManager.Decorators{
    
    using System;
    using CloudManager.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
        public AzureVMDecorator(IVMWare _vmware) : base(_vmware)
        {
            _credential = new Credentials();
            _credential.clientID = "client1";
            _credential.clientSecret = "this is very secret";
            _credential.subscriptionID = "1234";
            _credential.tenantID = "tenant1";
            GetAuthorizationToken();

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
            _resourceGroup.location = "";
            
        }

        public override string create(ICredentials _credential){

            return string.Empty;
        }   

        private void GetAuthorizationToken(){
            var credential = new ClientCredential(_credential.clientID, _credential.clientSecret);
            var context = new AuthenticationContext("https://login.microsoftonline.com/" + _credential.tenantID);
            var result = context.AcquireTokenAsync("https://management.azure.com/", credential);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the Access token");
            }
            _credential.accessToken = result.Result.AccessToken;
        }     

        
    }
}