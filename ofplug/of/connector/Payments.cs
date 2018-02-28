namespace ofplug.of.connector
{
	public class Payments : Abstract_id_collection
	{
		internal Payments(string url, ISender sender) : base(url, "Payments", sender)
		{
		}
	}
}
