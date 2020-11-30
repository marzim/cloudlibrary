namespace CloudManager.Models{
    using System;

    public interface IDatabase{
        string name{ get;set; }
        string adminUser{ get;set; }
        string adminPassword{ get;set; }
        string serverVersion{ get;set; }

    }
}