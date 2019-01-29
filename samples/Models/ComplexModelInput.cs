using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
	[DataContract(Name = "CheckRequestData ", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    [Serializable]
    //[XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
    [XmlRoot("CheckRequestData", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7", IsNullable = false)]
    public class CheckRequestData
    {

        [DataMember(Name = "CheckDate", IsRequired = true)]
        [XmlElement("CheckDate", DataType = "date", Type = typeof(DateTime))]
        public DateTime CheckDate {get; set;}

        [DataMember(Name = "CheckPointCode", IsRequired = true)]
        [XmlElement("CheckPointCode", DataType = "int", Type = typeof(int))]
        public int CheckPointCode { get; set; }

        [DataMember(Name = "VehicleRegNumber", IsRequired = true)]
        [XmlElement("VehicleRegNumber", DataType = "string", Type = typeof(string))]
        public string VehicleRegNumber { get; set; }

        [DataMember(Name = "Direction", IsRequired = true)]
        [XmlElement("Direction", DataType = "int", Type = typeof(int))]
        public int Direction { get; set; }

        [DataMember(Name = "Latitude", IsRequired = true)]
        [XmlElement("Latitude", DataType = "decimal", Type = typeof(decimal))]
        public decimal Latitude { get; set; }

        [DataMember(Name = "LatitudeSpecified", IsRequired = true)]
        [XmlElement("LatitudeSpecified", DataType = "boolean", Type = typeof(bool))]
        public bool LatitudeSpecified { get; set; }

        [DataMember(Name = "Longitude", IsRequired = true)]
        [XmlElement("Longitude", DataType = "decimal", Type = typeof(decimal))]
        public decimal Longitude { get; set; }

        [DataMember(Name = "LongitudeSpecified")]
        [XmlElement("LongitudeSpecified", DataType = "boolean", Type = typeof(bool))]
        public bool LongitudeSpecified { get; set; }

        [DataMember(Name = "TotalWeight")]
        [XmlElement("TotalWeight", DataType = "decimal", Type = typeof(decimal))]
        public decimal TotalWeight { get; set; }

        [DataMember(Name = "AxlesCount")]
        [XmlArray("AxlesCount")]
        public int[] AxlesCount { get; set; }

        [DataMember(Name = "AxlesLoads")]
        [XmlArray("AxlesLoads")]
        public decimal[] AxlesLoads { get; set; }

        [DataMember(Name = "AxlesInvervals")]
        [XmlArray("AxlesInvervals")]
        public decimal[] AxlesInvervals { get; set; }

        [DataMember(Name = "TotalSize")]
        [XmlElement("TotalSize")]
        public CheckRequestDataTotalSize TotalSize { get; set; }
    }

    [Serializable]
    public partial class CheckRequestDataTotalSize
    {
        [DataMember(Name = "Length")]
        [XmlElement("Length", DataType = "decimal", Type = typeof(decimal))]
        public decimal Length { get; set; }

        [DataMember(Name = "Width")]
        [XmlElement("Width", DataType = "decimal", Type = typeof(decimal))]
        public decimal Width { get; set; }


        /// <remarks/>
        [DataMember(Name = "Height")]
        [XmlElement("Height", DataType = "decimal", Type = typeof(decimal))]
        public decimal Height { get; set; }
    }
}
