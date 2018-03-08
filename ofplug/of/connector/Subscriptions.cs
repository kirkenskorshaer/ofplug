namespace ofplug.of.connector
{
	public class Subscriptions : Abstract_id_collection
	{
		public Subscriptions(string url, string token, ISender sender) : base(url, token, "subscriptions", sender)
		{
		}
	}
}
