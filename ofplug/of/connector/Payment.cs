﻿namespace ofplug.of.connector
{
	public class Payment : Abstract_data_exchange
	{
		public Payment(ISender sender, string url, string token, string path) : base(sender, url, token, path)
		{
		}

		public data.Payment Get(int id)
		{
			return Get<data.Payment>(id);
		}

		public data.IdResponse Patch(int id, data.Payment of_payment)
		{
			return base.Patch(id, of_payment);
		}

		public data.IdResponse Put(int id, data.Payment of_payment)
		{
			return base.Put(id, of_payment);
		}

		public data.IdResponse Post(data.Payment of_payment)
		{
			return base.Post(of_payment);
		}
	}
}
