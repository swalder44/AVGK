using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Models
{
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
}
