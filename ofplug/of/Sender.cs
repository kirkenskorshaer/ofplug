using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ofplug.of
{
	public class Sender : ISender
	{
		public Response Get<Response>(string url)
			where Response : class
		{
			WebClient webClient = new WebClient();
			Set_headers(webClient);
			string data = webClient.DownloadString(url);
			Response response = StringToDataContract<Response>(data);
			webClient.Dispose();

			Move_id(response);

			return response;
		}

		public Response Post<Request, Response>(string url, Request request)
			where Response : class
		{
			return Send_and_expect_response<Request, Response>(url, request, "POST");
		}

		public Response Put<Request, Response>(string url, Request request)
			where Response : class
		{
			return Send_and_expect_response<Request, Response>(url, request, "PUT");
		}

		public Response Patch<Request, Response>(string url, Request request)
			where Response : class
		{
			return Send_and_expect_response<Request, Response>(url, request, "PATCH");
		}

		public Response Delete<Request, Response>(string url, Request request)
			where Response : class
		{
			return Send_and_expect_response<Request, Response>(url, request, "DELETE");
		}

		private Response Send_and_expect_response<Request, Response>(string url, Request request, string method)
			where Response : class
		{
			WebClient webClient = new WebClient();
			Set_headers(webClient);

			byte[] requestBytes = DataContractByteArray(request);

			string preview = DataContractToString(request);
			byte[] responseBytes = null;
			try
			{
				responseBytes = webClient.UploadData(url, method, requestBytes);
			}
			catch (WebException web_exception)
			{
				string error = new StreamReader(web_exception.Response.GetResponseStream()).ReadToEnd();

				throw new System.Exception(error);
			}

			string responseString = Encoding.UTF8.GetString(responseBytes);
			Response response = StringToDataContract<Response>(responseString);
			webClient.Dispose();

			Move_id(response);

			return response;
		}

		private void Set_headers(WebClient webClient)
		{
			webClient.Headers["Authorization"] = "Bearer yz9dsGlEWsRNfQYW81Jk";
			webClient.Headers["content-type"] = "application/json; charset=utf-8";
		}

		private Output StringToDataContract<Output>(string input)
			where Output : class
		{
			MemoryStream memoryStream = GenerateStreamFromString(input);
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Output));
			return dataContractJsonSerializer.ReadObject(memoryStream) as Output;
		}

		private string DataContractToString<Input>(Input input)
		{
			byte[] jsonBytes = DataContractByteArray(input);
			return Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length);
		}

		private byte[] DataContractByteArray<Input>(Input input)
		{
			MemoryStream memoryStream = new MemoryStream();
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Input));
			dataContractJsonSerializer.WriteObject(memoryStream, input);
			byte[] jsonBytes = memoryStream.ToArray();
			return jsonBytes;
		}

		private MemoryStream GenerateStreamFromString(string input)
		{
			MemoryStream stream = new MemoryStream();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(input);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}

		private void Move_id(object response)
		{
			data.AbstractData response_object = response as data.AbstractData;
			if (response_object != null)
			{
				response_object.Of_id = response_object.Id;
				response_object.Id = null;
			}
		}
	}
}
