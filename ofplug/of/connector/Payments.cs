namespace ofplug.of.connector
{
	public class Payments : Abstract_id_collection
	{
		internal Payments(string url, int step, ISender sender) : base(url, "Payments", step, sender)
		{
		}
	}
}
