namespace CloudManager.Models{
    using System;

    public interface IResourceGroup{
        string groupName {get; set;}
        string location {get; set;}
    }
}