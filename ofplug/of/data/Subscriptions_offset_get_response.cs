using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Subscriptions_offset_get_response
	{
		[DataMember(Name = "ids", EmitDefaultValue = false)]
		public List<string> Ids { get; set; }
	}
}
