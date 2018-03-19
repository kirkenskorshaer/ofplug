using System;
using System.Collections.Generic;

namespace ofplug.of.connector
{
	public class Agreement : Abstract_data_exchange
	{
		public Agreement(ISender sender, string url, string token, string path) : base(sender, url, token, path)
		{
		}

		public data.Agreement Get(int id)
		{
			return Get<data.Agreement>(id);
		}

		public data.Agreement Get(Guid id)
		{
			return Get<data.Agreement>(1, id.ToString().ToLower());
		}

		public data.IdResponse Patch(int id, data.Agreement of_agreement, List<string> parameters = null)
		{
			return base.Patch(id, of_agreement, parameters);
		}

		public data.IdResponse Put(int id, data.Agreement of_agreement)
		{
			return base.Put(id, of_agreement);
		}

		public data.IdResponse Post(data.Agreement of_agreement)
		{
			return base.Post(of_agreement);
		}
	}
}
