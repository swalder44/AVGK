using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Program
    {
        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        public static void Main(string[] args)
        {
           //var client = new ServiceReference1.Service1Client();
            //var answer = client.GetData(1);
            //var client = new ServiceReference2.SampleServiceClient();
            //var request = new ServiceReference2.CheckRequestData()
            //{
            //    AxlesCount = new int?[] { 1, 2, 3 },
            //    AxlesInvervals = new decimal?[] { 1.23M, 2.34M, 3.45M },
            //    AxlesLoads = new decimal?[] { 2.34M, 3.45M, 4.56M },
            //    CheckDate = DateTime.Now,
            //    Direction = 1,
            //    CheckPointCode = 1,
            //    Latitude = 1,
            //    Longitude = 1,
            //    TotalSize = new ServiceReference2.CheckRequestDataTotalSize()
            //    {
            //        Height = (decimal)123.23,
            //        Length = (decimal)1234.5,
            //        Width = (decimal)1.4
            //    },
            //    TotalWeight = 1,
            //    VehicleRegNumber = "123"

            //};
            //var answer = client.CheckRequestData(request);
            Console.WriteLine("Press enter to start");
            Console.ReadKey();
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(new Uri(string.Format("http://{0}:5050/Service.svc", Environment.MachineName)));
            var channelFactory = new ChannelFactory<ISampleService>(binding, endpoint);
            //var channelFactory = new ChannelFactory<ISampleService>(binding, endpoint);
            var serviceClient = channelFactory.CreateChannel();
            //var result = serviceClient.Ping(1);
            //Console.WriteLine("Ping method result: {0}", result);

            var complexModel = new CheckRequestData()
            {
                //AxlesCount = new int[] { 1, 2, 3 },
                //AxlesInvervals = new decimal[] { 1.23M, 2.34M, 3.45M },
                //AxlesLoads = new decimal[] { 2.34M, 3.45M, 4.56M },
                CheckDate = DateTime.Now,
                Direction = 1,
                CheckPointCode = 1,
                Latitude = 1,
                Longitude = 1,
                //TotalSize = new CheckRequestDataTotalSize()
                //{
                //    Height = (decimal)123.23,
                //    Length = (decimal)1234.5,
                //    Width = (decimal)1.4
                //},
                TotalWeight = 1,
                VehicleRegNumber = "123"
            };
            XmlSerializer formatter = new XmlSerializer(typeof(CheckRequestData));
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, complexModel);
            Console.WriteLine(StreamToString(memoryStream));

            var complexResult = serviceClient.CheckRequestData(complexModel);
            Console.WriteLine("Answer");
            XmlSerializer formatterAnswer = new XmlSerializer(typeof(CheckResultData));
            MemoryStream memoryStreamAnswer = new MemoryStream();
            formatterAnswer.Serialize(memoryStreamAnswer, complexResult);
           

            //var asyncMethodResult = serviceClient.AsyncMethod().Result;
            //Console.WriteLine("Async method result: {0}", asyncMethodResult);

            Console.ReadKey();
        }

        [DataContract(Name = "CheckRequestData ", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
        [Serializable]
        //[XmlType(AnonymousType = true, Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7")]
        [XmlRoot("CheckRequestData", Namespace = "http://gucmp.ru/services/smev/pvk/resolutions/1.0.7", IsNullable = false)]
        public class CheckRequestData
        {

            [DataMember(Name = "CheckDate", IsRequired = true)]
            [XmlElement("CheckDate")]
            public DateTime CheckDate { get; set; }

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

            [DataMember(Name = "Longitude", IsRequired = true)]
            [XmlElement("Longitude", DataType = "decimal", Type = typeof(decimal))]
            public decimal Longitude { get; set; }

            [DataMember(Name = "TotalWeight")]
            [XmlElement("TotalWeight", DataType = "decimal", Type = typeof(decimal))]
            public decimal TotalWeight { get; set; }

            //[DataMember(Name = "AxlesCount")]
            //[XmlElement("AxlesCount")]
            //public int[] AxlesCount { get; set; }

            //[DataMember(Name = "AxlesLoads")]
            //[XmlElement("AxlesLoads")]
            //public decimal[] AxlesLoads { get; set; }

            //[DataMember(Name = "AxlesInvervals")]
            //[XmlElement("AxlesInvervals")]
            //public decimal[] AxlesInvervals { get; set; }

            //[DataMember(Name = "TotalSize")]
            //[XmlElement("TotalSize")]
            //public CheckRequestDataTotalSize TotalSize { get; set; }
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
            //[XmlElement("DateFrom", DataType = "date", Type = typeof(DateTime))]
            [XmlElement("DateFrom")]
            public DateTime DateFrom { get; set; }

            [DataMember(Name = "DateTo")]
            //[XmlElement("DateTo", DataType = "date", Type = typeof(DateTime))]
            [XmlElement("DateTo")]
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
            public decimal FullWeight { get; set; }

            [DataMember(Name = "Dimensions")]
            [XmlElement("Dimensions")]
            public CheckResultDataCheckResultDataItemDimensions Dimensions { get; set; }

            [DataMember(Name = "AxlesLoads")]
            [XmlElement("AxlesLoads")]
            public decimal[] AxlesLoads { get; set; }

            [DataMember(Name = "AxlesInvervals")]
            [XmlElement("AxlesInvervals")]
            public decimal[] AxlesInvervals { get; set; }

            [DataMember(Name = "AxlesWeelsEx")]
            [XmlElement("AxlesWeelsEx")]
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
            [XmlElement("DocumentDate")]
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
            public int CodeToInt
            {
                get
                {
                    return (int)Code;
                }
                set
                {
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

        [ServiceContract]
        public interface ISampleService
        {
            [OperationContract]
            string Ping(int s);

            [OperationContract]
            CheckResultData CheckRequestData(CheckRequestData inputModel);

            [OperationContract]
            void VoidMethod(out string s);

            [OperationContract]
            Task<int> AsyncMethod();

            [OperationContract]
            int? NullableMethod(bool? arg);
        }

        public class SampleService : ISampleService
        {
            public string Ping(int s)
            {
                Console.WriteLine("Exec ping method");
                return s.ToString();
            }

            public static string StreamToString(Stream stream)
            {
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }

            public CheckResultData CheckRequestData(CheckRequestData inputModel)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(CheckRequestData));
                MemoryStream memoryStream = new MemoryStream();
                formatter.Serialize(memoryStream, inputModel);
                Console.WriteLine(StreamToString(memoryStream));
                //Console.WriteLine("Input data. IntProperty: {0}, StringProperty: {1}", inputModel, inputModel);
                return new CheckResultData
                {
                    AxlesInvervals = new decimal[] { 1.23M, 2.34M },
                    AxlesLoads = new decimal[] { 1.23M, 2.34M, 3.45M },
                    AxlesWeelsEx = new int[] { 1, 1, 1 },
                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now,
                    Dimensions = new CheckResultDataCheckResultDataItemDimensions()
                    {
                        Height = 1.2M,
                        Length = 2.4M,
                        Width = 5.6M,
                    },
                    LeftTripCount = 1,
                    Resolution = new CheckResultDataCheckResultDataItemResolution()
                    {
                        DocumentDateSign = DateTime.Now,
                        DocumentNumber = "123"
                    },
                    Route = "Маршрут",
                    RouteCheck = new CheckResultDataCheckResultDataItemRouteCheck()
                    {
                        Code = EnumResolutionAnswer.CheckFalse,
                        Message = "Прошел"
                    },
                    ShippingType = CheckResultDataCheckResultDataItemShippingType.Local,
                    FullWeight = 1.23M,
                    Transporter = "Перевозчик",
                    TransporterAddress = "Адрес перевозчика",
                    TripCount = 3,
                    VehicleRegNumber = "123"
                };
            }

            public void VoidMethod(out string s)
            {
                s = "Value from server";
            }

            public Task<int> AsyncMethod()
            {
                return Task.Run(() => 42);
            }

            public int? NullableMethod(bool? arg)
            {
                return null;
            }
        }

    }
}
