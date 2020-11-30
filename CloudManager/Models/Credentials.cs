namespace CloudManager.Models{
    public class Credentials : ICredentials{
        private string _clientID;
        private string _clientSecret;
        private string _tenantID;
        private string _subscriptionID;
        private string _response;
        private string _accessToken;

        public string clientID
        {
            get{ return _clientID; } 
            set{ _clientID = value; }
        }

        public string clientSecret
        {
            get{ return _clientSecret; } 
            set{ _clientSecret = value; }
        }

        public string tenantID
        {
            get{ return _tenantID; } 
            set{ _tenantID = value; }
        }

        public string subscriptionID
        {
            get{ return _subscriptionID; } 
            set{ _subscriptionID = value; }
        }

        public string response
        {
            get{ return _response; } 
            set{ _response = value; }
        }

        public string accessToken
        {
            get{ return _accessToken; } 
            set{ _accessToken = value; }
        }
    }
}