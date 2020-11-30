namespace CloudManager.Models
{
    using System;

    public interface ICloudProvider{
        string name {get; set;}

        string response { get; set; }

    }
}