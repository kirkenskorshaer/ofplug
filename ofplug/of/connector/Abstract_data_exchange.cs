using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ofplug.of.connector
{
	public abstract class Abstract_data_exchange
	{
		protected string _path { get; private set; }
		protected string _url { get; private set; }
		protected string _token { get; private set; }
		protected ISender _sender { get; private set; }

		public Abstract_data_exchange(ISender sender, string url, string token, string path)
		{
			_url = url;
			_sender = sender;
			_token = token;

			_path = path;
			if (_path.EndsWith("/") == false)
			{
				_path += "/";
			}
		}

		protected Output Get<Output>(int id)
			where Output : class
		{
			Output response = _sender.Get<Output>(_url + _path + id.ToString() + "/", _token);
			return response;
		}

		protected Output Get<Output>(int key, string value)
			where Output : class
		{
			Output response = _sender.Get<Output>(_url + _path + "custom/" + key.ToString() + "/" + value + "/", _token);
			return response;
		}

		public data.IdResponse Patch<Input>(int id, Input input, List<string> parameters = null)
		where Input : new()
		{
			if (parameters != null && parameters.Any())
			{
				Input input_to_patch = new Input();
				Add_wanted_parameters(input, input_to_patch, parameters);
				data.IdResponse response = _sender.Patch<Input, data.IdResponse>(_url + _path + id.ToString() + "/", _token, input_to_patch);
				return response;
			}
			else
			{
				data.IdResponse response = _sender.Patch<Input, data.IdResponse>(_url + _path + id.ToString() + "/", _token, input);
				return response;
			}
		}

		private void Add_wanted_parameters<Input>(Input input_original, Input input_copy, List<string> parameters)
		{
			PropertyInfo[] propertiesInfo = typeof(Input).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (string parameter in parameters)
			{
				PropertyInfo propertyInfo = propertiesInfo.Single(property => property.Name == parameter);
				object value = propertyInfo.GetValue(input_original);
				propertyInfo.SetValue(input_copy, value);
			}
		}

		public data.IdResponse Put<Input>(int id, Input input)
		{
			data.IdResponse response = _sender.Put<Input, data.IdResponse>(_url + _path + id.ToString() + "/", _token, input);
			return response;
		}

		public data.IdResponse Post<Input>(Input input)
		{
			data.IdResponse response = _sender.Post<Input, data.IdResponse>(_url + _path, _token, input);
			return response;
		}
	}
}
