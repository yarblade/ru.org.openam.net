using System.Xml.Serialization;

namespace OpenAM.Core.Entities.Auth.Callbacks
{
    public class PagePropertiesCallback : CallbackBase
    {
        [XmlAttribute("isErrorState")]
        public bool IsErrorState { get; set; }

        [XmlElement("ModuleName")]
        public string ModuleName { get; set; }

        [XmlElement("HeaderValue")]
        public string HeaderValue { get; set; }

        [XmlElement("ImageName")]
        public string ImageName { get; set; }

        [XmlElement("PageTimeOutValue")]
        public int PageTimeOutValue { get; set; }

        [XmlElement("TemplateName")]
        public string TemplateName { get; set; }

        [XmlElement("PageState")]
        public int PageState { get; set; }

        [XmlElement("AttributeList")]
        public string AttributeList { get; set; }

        [XmlElement("RequiredList")]
        public string RequiredList { get; set; }

        [XmlElement("InfoTextList")]
        public string InfoTextList { get; set; }
    }
}