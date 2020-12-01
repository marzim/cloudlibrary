


## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Using the library](#Using-the-library)

## General info
CloudLibrary - is a simple library that manage cloud infrastructure. For now it caters Creating/Deleting VM and Databases. No actual function yet in connecting to actual cloud provider but the framework is already in place. 
	
## Technologies
Project is created with:
* Visual Studio Code with installed C# extensions
* Microsoft.Azure.Management.Compute.Fluent.Models;
* Microsoft.Azure.Management.Fluent;
* Microsoft.Azure.Management.ResourceManager.Fluent;

## Setup

```
$ git clone https://github.com/marzim/cloudlibrary.git
$ cd cloudlibrary
start your Visual Studio Code and open cloudlibrary folder
Open terminal on your VSCode and run dotnet build
```

## Using the library
Considering you add the dll(CloudManager.dll) reference into your csproj file.

```
sample.csproj
<ItemGroup>
    <Reference Include="CloudManager">
      <HintPath>..\cloudlibrary\CloudManager\bin\Debug\netstandard2.0\CloudManager.dll</HintPath>
    </Reference>
  </ItemGroup>

Program.cs
using System;
using CloudManager.Factory;
using CloudManager.Models;
namespace sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cloudProviderFactory = CloudProviderFactory.CreateCloudProviderFactory("IGS");
            var cloudProviderService = (IGSVMManager) cloudProviderFactory.GetCloudProviderServices("IGSManageVMWare");
            var credential = new Credentials();
            credential.clientID = "client1";
            credential.clientSecret = "this is very secret";
            credential.subscriptionID = "1234";
            credential.tenantID = "tenant1";
           
            var resourceGroup = new ResourceGroup();
            resourceGroup.groupName = "ResourceGroupName";
            resourceGroup.location = "eastus";   

            var vmware = new VMWare();
            vmware.adminUser = "user1"; 
            vmware.adminPassword = "Secretp@ssword";
            vmware.Name = "WinVM";
            vmware.vNetName = "VNET";            
            vmware.vNetAddress = "10.10.0.0/16";
            vmware.nicName = "NIC";
            vmware.subnetAddress = "10.10.0.0/24";
            vmware.subnetName = "Subnet";

            cloudProviderService.vmware = vmware;
            cloudProviderService.credentials = credential;
            cloudProviderService.resourceGroup = resourceGroup;
            cloudProviderService.createVM();
          
        }
    }
}
```
