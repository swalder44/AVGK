using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server
{
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
				AxlesInvervals = new decimal[] { 1.23M,2.34M},
                AxlesLoads = new decimal[] { 1.23M, 2.34M, 3.45M },
                AxlesWeelsEx = new int[] { 1,1,1},
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
