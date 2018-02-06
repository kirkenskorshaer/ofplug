using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Subscription
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}
