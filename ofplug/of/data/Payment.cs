using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Payment
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}
