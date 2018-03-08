namespace ofplug.of.connector
{
	public class Agreements : Abstract_id_collection
	{
		public Agreements(string url, string token, ISender sender) : base(url, token, "agreements", sender)
		{
		}
	}
}
