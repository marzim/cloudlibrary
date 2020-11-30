namespace CloudManager.Decorators{
    
    using System;
    using CloudManager.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    

    public class AzureVMDecorator : VMWareDecorator
    {

        private ICredentials _credential;
        public AzureVMDecorator(IVMWare _vmware) : base(_vmware)
        {
            _credential = new Credentials();
            _credential.clientID = "client1";
            _credential.clientSecret = "this is very secret";
            _credential.subscriptionID = "1234";
            _credential.tenantID = "tenant1";
            GetAuthorizationToken();
            _vmware.adminUser = ""; 
            
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