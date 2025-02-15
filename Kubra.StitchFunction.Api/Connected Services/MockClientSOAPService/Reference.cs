﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MockClientSOAPService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://tempuri.org/")]
    public partial class Response : object
    {
        
        private decimal AmountDueField;
        
        private System.DateTime DueDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal AmountDue
        {
            get
            {
                return this.AmountDueField;
            }
            set
            {
                this.AmountDueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime DueDate
        {
            get
            {
                return this.DueDateField;
            }
            set
            {
                this.DueDateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentPostRequest", Namespace="http://tempuri.org/")]
    public partial class PaymentPostRequest : object
    {
        
        private string PaymentIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string PaymentId
        {
            get
            {
                return this.PaymentIdField;
            }
            set
            {
                this.PaymentIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MockClientSOAPService.ISoapService")]
    public interface ISoapService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/Balance", ReplyAction="*")]
        System.Threading.Tasks.Task<MockClientSOAPService.BalanceResponse> BalanceAsync(MockClientSOAPService.BalanceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/PostPayment", ReplyAction="*")]
        System.Threading.Tasks.Task<MockClientSOAPService.PostPaymentResponse> PostPaymentAsync(MockClientSOAPService.PostPaymentRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BalanceRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Balance", Namespace="http://tempuri.org/", Order=0)]
        public MockClientSOAPService.BalanceRequestBody Body;
        
        public BalanceRequest()
        {
        }
        
        public BalanceRequest(MockClientSOAPService.BalanceRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BalanceRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int accountNumber;
        
        public BalanceRequestBody()
        {
        }
        
        public BalanceRequestBody(int accountNumber)
        {
            this.accountNumber = accountNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class BalanceResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="BalanceResponse", Namespace="http://tempuri.org/", Order=0)]
        public MockClientSOAPService.BalanceResponseBody Body;
        
        public BalanceResponse()
        {
        }
        
        public BalanceResponse(MockClientSOAPService.BalanceResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class BalanceResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public MockClientSOAPService.Response BalanceResult;
        
        public BalanceResponseBody()
        {
        }
        
        public BalanceResponseBody(MockClientSOAPService.Response BalanceResult)
        {
            this.BalanceResult = BalanceResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PostPaymentRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PostPayment", Namespace="http://tempuri.org/", Order=0)]
        public MockClientSOAPService.PostPaymentRequestBody Body;
        
        public PostPaymentRequest()
        {
        }
        
        public PostPaymentRequest(MockClientSOAPService.PostPaymentRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PostPaymentRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public MockClientSOAPService.PaymentPostRequest request;
        
        public PostPaymentRequestBody()
        {
        }
        
        public PostPaymentRequestBody(MockClientSOAPService.PaymentPostRequest request)
        {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PostPaymentResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PostPaymentResponse", Namespace="http://tempuri.org/", Order=0)]
        public MockClientSOAPService.PostPaymentResponseBody Body;
        
        public PostPaymentResponse()
        {
        }
        
        public PostPaymentResponse(MockClientSOAPService.PostPaymentResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PostPaymentResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool PostPaymentResult;
        
        public PostPaymentResponseBody()
        {
        }
        
        public PostPaymentResponseBody(bool PostPaymentResult)
        {
            this.PostPaymentResult = PostPaymentResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface ISoapServiceChannel : MockClientSOAPService.ISoapService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class SoapServiceClient : System.ServiceModel.ClientBase<MockClientSOAPService.ISoapService>, MockClientSOAPService.ISoapService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SoapServiceClient() : 
                base(SoapServiceClient.GetDefaultBinding(), SoapServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ISoapService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SoapServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SoapServiceClient.GetBindingForEndpoint(endpointConfiguration), SoapServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SoapServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SoapServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SoapServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SoapServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MockClientSOAPService.BalanceResponse> MockClientSOAPService.ISoapService.BalanceAsync(MockClientSOAPService.BalanceRequest request)
        {
            return base.Channel.BalanceAsync(request);
        }
        
        public System.Threading.Tasks.Task<MockClientSOAPService.BalanceResponse> BalanceAsync(int accountNumber)
        {
            MockClientSOAPService.BalanceRequest inValue = new MockClientSOAPService.BalanceRequest();
            inValue.Body = new MockClientSOAPService.BalanceRequestBody();
            inValue.Body.accountNumber = accountNumber;
            return ((MockClientSOAPService.ISoapService)(this)).BalanceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MockClientSOAPService.PostPaymentResponse> MockClientSOAPService.ISoapService.PostPaymentAsync(MockClientSOAPService.PostPaymentRequest request)
        {
            return base.Channel.PostPaymentAsync(request);
        }
        
        public System.Threading.Tasks.Task<MockClientSOAPService.PostPaymentResponse> PostPaymentAsync(MockClientSOAPService.PaymentPostRequest request)
        {
            MockClientSOAPService.PostPaymentRequest inValue = new MockClientSOAPService.PostPaymentRequest();
            inValue.Body = new MockClientSOAPService.PostPaymentRequestBody();
            inValue.Body.request = request;
            return ((MockClientSOAPService.ISoapService)(this)).PostPaymentAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISoapService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISoapService_soap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:7041/Service.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SoapServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SoapServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ISoapService_soap,
        }
    }
}
