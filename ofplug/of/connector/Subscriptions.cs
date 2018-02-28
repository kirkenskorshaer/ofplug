namespace ofplug.of.connector
{
	public class Subscriptions : Abstract_id_collection
	{
		public Subscriptions(string url, int step, ISender sender) : base(url, "subscriptions", step, sender)
		{
		}
	}
}
