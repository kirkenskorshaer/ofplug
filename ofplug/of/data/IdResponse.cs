using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class IdResponse
	{
		[DataMember(Name = "ID", EmitDefaultValue = false)]
		public int Id { get; set; }
	}
}
