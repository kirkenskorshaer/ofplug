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

		public data.IdResponse Patch(int id, data.Subscription of_subscription)
		{
			return base.Patch(id, of_subscription);
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
