namespace ofplug.of.connector
{
	public class Contacts : Abstract_id_collection
	{
		public Contacts(string url, ISender sender) : base(url, "contacts", sender)
		{
		}
	}
}
