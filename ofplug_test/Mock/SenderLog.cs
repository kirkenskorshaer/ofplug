namespace ofplug_test.Mock
{
	public class SenderLog
	{
		public string Url;
		public object Request;
		public SenderMock.Operation Operation;

		public SenderLog(SenderMock.Operation operation, string url, object request)
		{
			Operation = operation;
			Url = url;
			Request = request;
		}
	}
}
