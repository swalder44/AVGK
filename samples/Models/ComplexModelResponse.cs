using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [DataContract(Name = "CheckResultData ", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    [Serializable()]
    //[XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    [XmlRoot("CheckResultData", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    public partial class CheckResultData
    {
        [DataMember(Name = "Resolution")]
        [XmlElement("Resolution", Type = typeof(CheckResultDataCheckResultDataItemResolution))]
        public CheckResultDataCheckResultDataItemResolution Resolution { get; set; }

        [DataMember(Name = "TripCount")]
        [XmlElement("TripCount", DataType = "int", Type = typeof(int))]
        public int TripCount { get; set; }

        [DataMember(Name = "LeftTripCount")]
        [XmlElement("LeftTripCount", DataType = "int", Type = typeof(int))]
        public int LeftTripCount { get; set; }

        [DataMember(Name = "Route")]
        [XmlElement("Route", DataType = "string", Type = typeof(string))]
        public string Route { get; set; }

        [DataMember(Name = "RouteCheck")]
        [XmlElement("RouteCheck", Type = typeof(CheckResultDataCheckResultDataItemRouteCheck))]
        public CheckResultDataCheckResultDataItemRouteCheck RouteCheck { get; set; }

        [DataMember(Name = "DateFrom")]
        [XmlElement("DateFrom", DataType = "date", Type = typeof(DateTime))]
        public DateTime DateFrom { get; set; }

        [DataMember(Name = "DateTo")]
        [XmlElement("DateTo", DataType = "date", Type = typeof(DateTime))]
        public DateTime DateTo { get; set; }

        [DataMember(Name = "VehicleRegNumber")]
        [XmlElement("VehicleRegNumber", DataType = "string", Type = typeof(string))]
        public string VehicleRegNumber { get; set; }

        [DataMember(Name = "Transporter")]
        [XmlElement("Transporter", DataType = "string", Type = typeof(string))]
        public string Transporter { get; set; }

        [DataMember(Name = "TransporterAddress")]
        [XmlElement("TransporterAddress", DataType = "string", Type = typeof(string))]
        public string TransporterAddress { get; set; }

        [DataMember(Name = "TotalWeight", IsRequired = true)]
        [XmlElement("TotalWeight", DataType = "decimal", Type = typeof(decimal))]
        public decimal FullWeight { get; set;  }

        [DataMember(Name = "Dimensions")]
        [XmlElement("Dimensions")]
        public CheckResultDataCheckResultDataItemDimensions Dimensions { get; set; }

        [DataMember(Name = "AxlesLoads")]
        [XmlArray("AxlesLoads")]
        public decimal[] AxlesLoads { get; set; }

        [DataMember(Name = "AxlesInvervals")]
        [XmlArray("AxlesInvervals")]
        public decimal[] AxlesInvervals { get; set; }

        [DataMember(Name = "AxlesWeelsEx")]
        [XmlArray("AxlesWeelsEx")]
        public int[] AxlesWeelsEx { get; set; }

        [DataMember(Name = "ShippingType")]
        [XmlElement("ShippingType", Type = typeof(CheckResultDataCheckResultDataItemShippingType))]
        public CheckResultDataCheckResultDataItemShippingType ShippingType { get; set; }
    }

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    public partial class CheckResultDataCheckResultDataItemResolution
    {
        [DataMember(Name = "DocumentNumber")]
        [XmlElement("DocumentNumber", DataType = "string", Type = typeof(string))]
        public string DocumentNumber { get; set; }

        [DataMember(Name = "DocumentDate")]
        [XmlElement("DocumentDate", DataType = "date", Type = typeof(DateTime))]
        public DateTime DocumentDateSign { get; set; }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    public enum CheckResultDataCheckResultDataItemShippingType
    {
        [XmlEnum(Name = "International")]
        International,
        [XmlEnum(Name = "Interregional")]
        Interregional,
        [XmlEnum(Name = "Local")]
        Local,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    public partial class CheckResultDataCheckResultDataItemRouteCheck
    {
        [XmlIgnore]
        public EnumResolutionAnswer Code;

        [DataMember(Name = "Code")]
        [XmlElement("Code", DataType = "int", Type = typeof(int))]
        public int CodeToInt {
            get {
                return (int)Code;
            }
            set {
                Code = (EnumResolutionAnswer)value;
            }
        }

        [DataMember(Name = "Message")]
        [XmlElement("Message", DataType = "string", Type = typeof(string))]
        public string Message { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    public partial class CheckResultDataCheckResultDataItemDimensions
    {
        [DataMember(Name = "Length", IsRequired = true)]
        [XmlElement("Length", DataType = "decimal", Type = typeof(decimal))]
        public decimal Length { get; set; }

        [DataMember(Name = "Width", IsRequired = true)]
        [XmlElement("Width", DataType = "decimal", Type = typeof(decimal))]
        public decimal Width { get; set; }

        [DataMember(Name = "Height", IsRequired = true)]
        [XmlElement("Height", DataType = "decimal", Type = typeof(decimal))]
        public decimal Height { get; set; }
    }

    public enum EnumResolutionAnswer
    {
        CheckOkRouteTrue = 1,
        CheckOkRouteFalse = 2,
        CheckFalseRouteNotGis = 3,
        CheckFalse = 4
    }
}
