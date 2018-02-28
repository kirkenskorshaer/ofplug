namespace ofplug.of.connector
{
	public class Contacts : Abstract_id_collection
	{
		public Contacts(string url, int step, ISender sender) : base(url, "contacts", step, sender)
		{
		}
	}
}
