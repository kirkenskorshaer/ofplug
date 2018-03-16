using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class InitiateAgreementResponse
	{
		[DataMember(Name = "agreement_id", EmitDefaultValue = false)]
		public int Agreement_id { get; set; }

		[DataMember(Name = "subscription_id", EmitDefaultValue = false)]
		public int Subscription_id { get; set; }

		[DataMember(Name = "contact_id", EmitDefaultValue = false)]
		public int Contact_id { get; set; }
	}
}
