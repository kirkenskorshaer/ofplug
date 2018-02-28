namespace ofplug.of.connector
{
	public class Agreements : Abstract_id_collection
	{
		public Agreements(string url, int step, ISender sender) : base(url, "agreements", step, sender)
		{
		}
	}
}
