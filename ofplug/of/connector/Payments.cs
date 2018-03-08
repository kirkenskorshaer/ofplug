namespace ofplug.of.connector
{
	public class Payments : Abstract_id_collection
	{
		internal Payments(string url, string token, ISender sender) : base(url, token, "Payments", sender)
		{
		}
	}
}
