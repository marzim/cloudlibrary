namespace CloudManager.Models{
    public interface ICredentials{
        string clientID {get; set;}
        string clientSecret {get; set;}
        string tenantID {get; set;}
        string subscriptionID {get; set;}
       
    }
}