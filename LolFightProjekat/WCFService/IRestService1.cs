using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestServis1" in both code and config file together.
    [ServiceContract]
    public interface IRestService1
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/DoWork")]
        String DoWork();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Xml)]
        Employee GetEmployee();
    }
}
