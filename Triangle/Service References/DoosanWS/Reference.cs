﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Triangle.DoosanWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DoosanWS.IDoosanAPI")]
    public interface IDoosanAPI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetProducts", ReplyAction="http://tempuri.org/IDoosanAPI/GetProductsResponse")]
        System.Data.DataSet GetProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetProducts", ReplyAction="http://tempuri.org/IDoosanAPI/GetProductsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetProductDetails", ReplyAction="http://tempuri.org/IDoosanAPI/GetProductDetailsResponse")]
        System.Data.DataSet GetProductDetails(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetProductDetails", ReplyAction="http://tempuri.org/IDoosanAPI/GetProductDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetProductDetailsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/Allthree", ReplyAction="http://tempuri.org/IDoosanAPI/AllthreeResponse")]
        System.Data.DataSet Allthree(string tid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/Allthree", ReplyAction="http://tempuri.org/IDoosanAPI/AllthreeResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> AllthreeAsync(string tid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundles", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundlesResponse")]
        System.Data.DataSet GetBundles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundles", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundlesResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetBundlesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundleDetails", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundleDetailsResponse")]
        System.Data.DataSet GetBundleDetails(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundleDetails", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundleDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetBundleDetailsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundProd", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundProdResponse")]
        System.Data.DataSet GetBundProd(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/GetBundProd", ReplyAction="http://tempuri.org/IDoosanAPI/GetBundProdResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetBundProdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDelivery", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryResponse")]
        System.Data.DataSet getDelivery(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDelivery", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDeliveryFullDetails", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsResponse")]
        System.Data.DataSet getDeliveryFullDetails(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDeliveryFullDetails", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryFullDetailsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsByCompany", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsByCompanyResponse")]
        System.Data.DataSet getDeliveryFullDetailsByCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsByCompany", ReplyAction="http://tempuri.org/IDoosanAPI/getDeliveryFullDetailsByCompanyResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryFullDetailsByCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/changeDeliveryStatusDelivered", ReplyAction="http://tempuri.org/IDoosanAPI/changeDeliveryStatusDeliveredResponse")]
        int changeDeliveryStatusDelivered(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/changeDeliveryStatusDelivered", ReplyAction="http://tempuri.org/IDoosanAPI/changeDeliveryStatusDeliveredResponse")]
        System.Threading.Tasks.Task<int> changeDeliveryStatusDeliveredAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/Getallinvoice", ReplyAction="http://tempuri.org/IDoosanAPI/GetallinvoiceResponse")]
        System.Data.DataSet Getallinvoice();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoosanAPI/Getallinvoice", ReplyAction="http://tempuri.org/IDoosanAPI/GetallinvoiceResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetallinvoiceAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDoosanAPIChannel : Triangle.DoosanWS.IDoosanAPI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DoosanAPIClient : System.ServiceModel.ClientBase<Triangle.DoosanWS.IDoosanAPI>, Triangle.DoosanWS.IDoosanAPI {
        
        public DoosanAPIClient() {
        }
        
        public DoosanAPIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DoosanAPIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DoosanAPIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DoosanAPIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetProducts() {
            return base.Channel.GetProducts();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetProductsAsync() {
            return base.Channel.GetProductsAsync();
        }
        
        public System.Data.DataSet GetProductDetails(int id) {
            return base.Channel.GetProductDetails(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetProductDetailsAsync(int id) {
            return base.Channel.GetProductDetailsAsync(id);
        }
        
        public System.Data.DataSet Allthree(string tid) {
            return base.Channel.Allthree(tid);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AllthreeAsync(string tid) {
            return base.Channel.AllthreeAsync(tid);
        }
        
        public System.Data.DataSet GetBundles() {
            return base.Channel.GetBundles();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetBundlesAsync() {
            return base.Channel.GetBundlesAsync();
        }
        
        public System.Data.DataSet GetBundleDetails(int id) {
            return base.Channel.GetBundleDetails(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetBundleDetailsAsync(int id) {
            return base.Channel.GetBundleDetailsAsync(id);
        }
        
        public System.Data.DataSet GetBundProd(int id) {
            return base.Channel.GetBundProd(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetBundProdAsync(int id) {
            return base.Channel.GetBundProdAsync(id);
        }
        
        public System.Data.DataSet getDelivery(int id) {
            return base.Channel.getDelivery(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryAsync(int id) {
            return base.Channel.getDeliveryAsync(id);
        }
        
        public System.Data.DataSet getDeliveryFullDetails(int id) {
            return base.Channel.getDeliveryFullDetails(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryFullDetailsAsync(int id) {
            return base.Channel.getDeliveryFullDetailsAsync(id);
        }
        
        public System.Data.DataSet getDeliveryFullDetailsByCompany(int id) {
            return base.Channel.getDeliveryFullDetailsByCompany(id);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getDeliveryFullDetailsByCompanyAsync(int id) {
            return base.Channel.getDeliveryFullDetailsByCompanyAsync(id);
        }
        
        public int changeDeliveryStatusDelivered(string id) {
            return base.Channel.changeDeliveryStatusDelivered(id);
        }
        
        public System.Threading.Tasks.Task<int> changeDeliveryStatusDeliveredAsync(string id) {
            return base.Channel.changeDeliveryStatusDeliveredAsync(id);
        }
        
        public System.Data.DataSet Getallinvoice() {
            return base.Channel.Getallinvoice();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetallinvoiceAsync() {
            return base.Channel.GetallinvoiceAsync();
        }
    }
}
