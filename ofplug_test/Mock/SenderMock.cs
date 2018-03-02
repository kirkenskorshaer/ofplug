using ofplug.of;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class SenderMock : ISender
	{
		public List<SenderLog> Log = new List<SenderLog>();
		public Queue<object> data_to_return = new Queue<object>();

		public enum Operation
		{
			Delete = 1,
			Get = 2,
			Patch = 3,
			Post = 4,
			Put = 5,
		}

		public Response Delete<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new SenderLog(Operation.Delete, url, request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Get<Response>(string url) where Response : class
		{
			Log.Add(new SenderLog(Operation.Get, url, null));
			return data_to_return.Dequeue() as Response;
		}

		public Response Patch<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new SenderLog(Operation.Patch, url, request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Post<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new SenderLog(Operation.Post, url, request));
			return data_to_return.Dequeue() as Response;
		}

		public Response Put<Request, Response>(string url, Request request) where Response : class
		{
			Log.Add(new SenderLog(Operation.Put, url, request));
			return data_to_return.Dequeue() as Response;
		}
	}
}
