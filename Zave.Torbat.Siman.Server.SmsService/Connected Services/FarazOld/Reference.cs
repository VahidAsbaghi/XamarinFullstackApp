//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarazOld
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:smsserver", ConfigurationName="FarazOld.smsserverPortType")]
    public interface smsserverPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="sendPatternSms", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<FarazOld.sendPatternSmsResponse> sendPatternSmsAsync(FarazOld.sendPatternSmsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPatternSms", WrapperNamespace="http://188.0.240.110/class/sms/csharpservice/server.php", IsWrapped=true)]
    public partial class sendPatternSmsRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string fromNum;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string toNum;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string user;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
        public string pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=4)]
        public string pattern_code;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=5)]
        public string input_data;
        
        public sendPatternSmsRequest()
        {
        }
        
        public sendPatternSmsRequest(string fromNum, string toNum, string user, string pass, string pattern_code, string input_data)
        {
            this.fromNum = fromNum;
            this.toNum = toNum;
            this.user = user;
            this.pass = pass;
            this.pattern_code = pattern_code;
            this.input_data = input_data;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendPatternSmsResponse", WrapperNamespace="http://188.0.240.110/class/sms/csharpservice/server.php", IsWrapped=true)]
    public partial class sendPatternSmsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string @return;
        
        public sendPatternSmsResponse()
        {
        }
        
        public sendPatternSmsResponse(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    public interface smsserverPortTypeChannel : FarazOld.smsserverPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    public partial class smsserverPortTypeClient : System.ServiceModel.ClientBase<FarazOld.smsserverPortType>, FarazOld.smsserverPortType
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public smsserverPortTypeClient() : 
                base(smsserverPortTypeClient.GetDefaultBinding(), smsserverPortTypeClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.smsserverPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public smsserverPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(smsserverPortTypeClient.GetBindingForEndpoint(endpointConfiguration), smsserverPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public smsserverPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(smsserverPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public smsserverPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(smsserverPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public smsserverPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FarazOld.sendPatternSmsResponse> FarazOld.smsserverPortType.sendPatternSmsAsync(FarazOld.sendPatternSmsRequest request)
        {
            return base.Channel.sendPatternSmsAsync(request);
        }
        
        public System.Threading.Tasks.Task<FarazOld.sendPatternSmsResponse> sendPatternSmsAsync(string fromNum, string toNum, string user, string pass, string pattern_code, string input_data)
        {
            FarazOld.sendPatternSmsRequest inValue = new FarazOld.sendPatternSmsRequest();
            inValue.fromNum = fromNum;
            inValue.toNum = toNum;
            inValue.user = user;
            inValue.pass = pass;
            inValue.pattern_code = pattern_code;
            inValue.input_data = input_data;
            return ((FarazOld.smsserverPortType)(this)).sendPatternSmsAsync(inValue);
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
            if ((endpointConfiguration == EndpointConfiguration.smsserverPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.smsserverPort))
            {
                return new System.ServiceModel.EndpointAddress("http://188.0.240.110/class/sms/csharpservice/server.php");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return smsserverPortTypeClient.GetBindingForEndpoint(EndpointConfiguration.smsserverPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return smsserverPortTypeClient.GetEndpointAddress(EndpointConfiguration.smsserverPort);
        }
        
        public enum EndpointConfiguration
        {
            
            smsserverPort,
        }
    }
}
