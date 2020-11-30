namespace CloudManager.Decorators{
    
    using System;
    using CloudManager.Models;

    public class AzureVMDecorator : VMWareDecorator
    {

        public AzureVMDecorator(IVMware _vmware) : base(_vmware){}
        
                
    }
}