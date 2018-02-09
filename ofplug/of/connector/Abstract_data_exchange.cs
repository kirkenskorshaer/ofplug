namespace ofplug.of.connector
{
	public abstract class Abstract_data_exchange
	{
		protected string _path { get; private set; }
		protected string _url { get; private set; }
		protected Sender _sender { get; private set; }

		public Abstract_data_exchange(Sender sender, string url, string path)
		{
			_url = url;
			_sender = sender;

			_path = path;
			if (_path.EndsWith("/") == false)
			{
				_path += "/";
			}
		}

		protected Output Get<Output>(int id)
			where Output : class
		{
			Output response = _sender.Get<Output>(_url + _path + id.ToString() + "/");
			return response;
		}

		public data.IdResponse Patch<Input>(int id, Input input)
		{
			data.IdResponse response = _sender.Patch<Input, data.IdResponse>(_url + _path + id.ToString() + "/", input);
			return response;
		}

		public data.IdResponse Put<Input>(int id, Input input)
		{
			data.IdResponse response = _sender.Put<Input, data.IdResponse>(_url + _path + id.ToString() + "/", input);
			return response;
		}

		public data.IdResponse Post<Input>(Input input)
		{
			data.IdResponse response = _sender.Put<Input, data.IdResponse>(_url + _path, input);
			return response;
		}
	}
}
