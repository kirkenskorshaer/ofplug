namespace ofplug.of.connector
{
	public class Contacts : Abstract_id_collection
	{
		public Contacts(string url, string token, ISender sender) : base(url, token, "contacts", sender)
		{
		}
	}
}
