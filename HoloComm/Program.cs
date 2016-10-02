using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using HoloComm;
using System.Threading.Tasks;

namespace CSHttpClientSample
{
	class OCRProgram
	{
		public static void Main(String[] args)
		{
			 Request();
		}

		public static void Request()
		{
			SparkPostClass test = new SparkPostClass();
			test.SendEmail();
			//Console.WriteLine(json);		
		}
			



	}
}