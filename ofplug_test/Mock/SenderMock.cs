using ofplug.of;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class SenderMock : ISender
	{
		public List<KeyValuePair<string, object>> Log = new List<KeyValuePair<string, object>>();
		public Queue<object> data_to_return = new Queue<object>();

		public Response Delete<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new KeyValuePair<string, object>("Delete", request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Get<Response>(string url) where Response : class
		{
			Log.Add(new KeyValuePair<string, object>("Get", null));
			return data_to_return.Dequeue() as Response;
		}

		public Response Patch<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new KeyValuePair<string, object>("Patch", request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Post<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new KeyValuePair<string, object>("Patch", request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Put<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new KeyValuePair<string, object>("Patch", request));
			return data_to_return.Dequeue() as Response;
		}
	}
}
