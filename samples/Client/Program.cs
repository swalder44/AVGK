using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;

namespace Client
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
            Console.WriteLine("Press enter to start");
            Console.ReadKey();
            var binding = new BasicHttpBinding();
			var endpoint = new EndpointAddress(new Uri(string.Format("http://{0}:5050/Service.svc", Environment.MachineName)));
			var channelFactory = new ChannelFactory<ISampleService>(binding, endpoint);
			var serviceClient = channelFactory.CreateChannel();
			var result = serviceClient.Ping(1);
			Console.WriteLine("Ping method result: {0}", result);

			var complexModel = new CheckRequestData
            {
                AxlesCount = new int[] {1,2,3},
                AxlesInvervals = new decimal[] { 1.23M,2.34M,3.45M },
                AxlesLoads = new decimal[] { 2.34M, 3.45M, 4.56M },
                CheckDate = DateTime.Now,
                Direction = 1,
                CheckPointCode = 1,
                Latitude = 1,
                LatitudeSpecified = true,
                Longitude = 1,
                LongitudeSpecified = true,
                TotalSize = new CheckRequestDataTotalSize()
                {
                    Height = (decimal)123.23,
                    Length = (decimal)1234.5,
                    Width = (decimal)1.4
                },
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
            Console.WriteLine(StreamToString(memoryStreamAnswer));

            serviceClient.VoidMethod(out var stringValue);
			Console.WriteLine("Void method result: {0}", stringValue);

			var asyncMethodResult = serviceClient.AsyncMethod().Result;
			Console.WriteLine("Async method result: {0}", asyncMethodResult);

			Console.ReadKey();
		}
	}
}
