namespace ofplug.of.connector
{
	public class Contact : Abstract_data_exchange
	{
		public Contact(ISender sender, string url, string path) : base(sender, url, path)
		{
		}

		public data.Contact Get(int id)
		{
			return Get<data.Contact>(id);
		}

		public data.IdResponse Patch(int id, data.Contact of_contact)
		{
			return base.Patch(id, of_contact);
		}

		public data.IdResponse Put(int id, data.Contact of_contact)
		{
			return base.Put(id, of_contact);
		}

		public data.IdResponse Post(data.Contact of_contact)
		{
			return base.Post(of_contact);
		}
	}
}
