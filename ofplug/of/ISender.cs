namespace ofplug.of
{
	public interface ISender
	{
		Response Get<Response>(string url, string token) where Response : class;

		Response Post<Request, Response>(string url, string token, Request request) where Response : class;

		Response Put<Request, Response>(string url, string token, Request request) where Response : class;

		Response Patch<Request, Response>(string url, string token, Request request) where Response : class;

		Response Delete<Request, Response>(string url, string token, Request request) where Response : class;
	}
}
