namespace CloudManager.Models{
    using System;

    public class CloudProvider : ICloudProvider{

        private string _name;
        private string _response;

        private string _accessToken;

        public string name{
            get{ return _name; } 
            set{ _name = value; }
        }

        public string response{
            get{ return _response; } 
            set{ _response = value; }
        }

         public string accessToken{
            get{ return _accessToken; } 
            set{ _accessToken = value; }
        }
    }
}