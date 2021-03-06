﻿using System;
using System.Collections.Generic;

namespace ofplug.of.connector
{
	public class Subscription : Abstract_data_exchange
	{
		public Subscription(ISender sender, string url, string token, string path) : base(sender, url, token, path)
		{
		}

		public data.Subscription Get(int id)
		{
			return Get<data.Subscription>(id);
		}

		public data.Subscription Get(Guid id)
		{
			return Get<data.Subscription>(1, id.ToString().ToLower());
		}

		public data.IdResponse Patch(int id, data.Subscription of_subscription, List<string> parameters = null)
		{
			return base.Patch(id, of_subscription, parameters);
		}

		public data.IdResponse Put(int id, data.Subscription of_subscription)
		{
			return base.Put(id, of_subscription);
		}

		public data.IdResponse Post(data.Subscription of_subscription)
		{
			return base.Post(of_subscription);
		}
	}
}
