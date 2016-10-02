using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HoloComm
{
	public class OCRClass
	{
		public OCRClass()
		{
			
		}

		public async Task<String> MakeRequest(String pic)
		{
			Console.WriteLine("at the beginning");
			var client = new HttpClient();
			//var queryString = HttpUtility.ParseQueryString(string.Empty);

			// Request headers
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "82c85e1cde384aa598c4eb9910045b1c");

			// Request parameters
			//queryString["language"] = "unk";
			//queryString["detectOrientation "] = "true";
			var uri = "https://api.projectoxford.ai/vision/v1/ocr?language=unk&detectOrientation =true&language=unk&detectOrientation =true";


			HttpResponseMessage response;
			Console.WriteLine(uri.ToString());

			// Request body
			byte[] byteData = Encoding.UTF8.GetBytes("{ \"Url\": \"" + pic + "\"}");
			Console.WriteLine(byteData);

			using (var content = new ByteArrayContent(byteData))
			{
				Console.WriteLine("entering here?");
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				response = await client.PostAsync(uri, content).ConfigureAwait(false);
				Console.WriteLine("anything?/?");
				Console.WriteLine(response.ToString());


				/*Console.WriteLine("am i here");
				String json_Text = response.Content.ToString();
				Console.WriteLine(json_Text);*/
				return "random";
			}



		}
	}
}
