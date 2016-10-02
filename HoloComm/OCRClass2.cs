using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


namespace HoloComm
{
	public class OCRClass2
	{
		public OCRClass2()
		{
		}

		public static async void MakeRequest(OCRClass2 instance)
		{
			var client = new HttpClient();

			// Request headers
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "82c85e1cde384aa598c4eb9910045b1c");

			// Request parameters
			var uri = "https://api.projectoxford.ai/vision/v1/ocr?language=unk&detectOrientation =true&language=unk&detectOrientation =true";

			HttpResponseMessage response;

			Console.WriteLine("ksjdhfkjshdf");
			// Request body
			byte[] byteData = Encoding.UTF8.GetBytes("{ \"Url\": \"http://s3.favim.com/orig/42/arthur-book-library-card-quote-quotes-Favim.com-361567.jpg\"}");

			using (var content = new ByteArrayContent(byteData))
			{
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				response = await client.PostAsync(uri, content);
				Console.WriteLine("hello");
				//return response.ToString();
			}

		}
	}
}
