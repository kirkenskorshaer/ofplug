﻿namespace ofplug.of.connector
{
	public class Agreement : Abstract_data_exchange
	{
		public Agreement(Sender sender, string url, string path) : base(sender, url, path)
		{
		}

		public data.Agreement Get(int id)
		{
			return Get<data.Agreement>(id);
		}

		public data.IdResponse Patch(int id, data.Agreement of_agreement)
		{
			return base.Patch(id, of_agreement);
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