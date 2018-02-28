namespace ofplug.of.connector
{
	public class Subscriptions : Abstract_id_collection
	{
		public Subscriptions(string url, ISender sender) : base(url, "subscriptions", sender)
		{
		}
	}
}
