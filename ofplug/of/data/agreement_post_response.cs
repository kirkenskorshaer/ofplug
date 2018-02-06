using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Agreement_post_response
	{
		[DataMember(Name = "ID")]
		public int ID { get; set; }
	}
}
