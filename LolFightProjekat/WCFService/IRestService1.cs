using LolFightProjekat.Models;
using System;
using System.Collections.Generic;
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
            UriTemplate = "/GetSkillsByChampion?championId={championId}")]
        string GetSkillsByChampion(int championId);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/RandomEnemy?championId={championId}")]
        int RandomEnemy(int championId);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/RankFarm")]
        List<int> RankFarm();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/RankSteal")]
        List<int> RankSteal();

        /*
         [OperationContract]
         [WebInvoke(
             Method = "GET",
             BodyStyle = WebMessageBodyStyle.Wrapped,
             RequestFormat = WebMessageFormat.Xml,
             ResponseFormat = WebMessageFormat.Xml,
             UriTemplate = "/PosaljiPoruku")]
         void PosaljiPoruku(int idChampiona, String imePrimaoca, String naslov, String tekst);
        
         [OperationContract]
         [WebInvoke(
             Method = "GET",
             BodyStyle = WebMessageBodyStyle.Wrapped,
             RequestFormat = WebMessageFormat.Xml,
             ResponseFormat = WebMessageFormat.Xml,
             UriTemplate = "/PosaljiPorukuById")]
         void PosaljiPorukuById(int idChampiona, int idPrimaoca, String naslov, String tekst);
         
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/PosaljiPorukuAdminu?idChampiona={idChampiona}&naslov={naslov}&tekst={tekst}")]
        void PosaljiPorukuAdminu(int idChampiona, String naslov, String tekst); 
        */
    }
}
