using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Contact
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}
