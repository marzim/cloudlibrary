using System;

namespace CloudManager.Models
{
    public class ResourceGroup : IResourceGroup
    {

        private string _groupName;
        private string _location;

        public string groupName{
            get{ return _groupName; }
            set{ _groupName = value; }
        }

        public string location{
            get{ return _location; }
            set{ _location = value; }
        }
    }
}
