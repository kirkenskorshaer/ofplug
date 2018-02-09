namespace ofplug.of.connector
{
	public class Payment : Abstract_data_exchange
	{
		public Payment(Sender sender, string url, string path) : base(sender, url, path)
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
