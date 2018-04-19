using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class InitiateAgreement
	{
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string Name { get; set; }

		[DataMember(Name = "first_name", EmitDefaultValue = false)]
		public string First_name { get; set; }

		[DataMember(Name = "middle_name", EmitDefaultValue = false)]
		public string Middle_name { get; set; }

		[DataMember(Name = "last_name", EmitDefaultValue = false)]
		public string Last_name { get; set; }

		[DataMember(Name = "address", EmitDefaultValue = false)]
		public string Address { get; set; }

		[DataMember(Name = "post_code", EmitDefaultValue = false)]
		public string Post_code { get; set; }

		[DataMember(Name = "city", EmitDefaultValue = false)]
		public string City { get; set; }

		[DataMember(Name = "country_code", EmitDefaultValue = false)]
		public string Country { get; set; }

		[DataMember(Name = "msisdn", EmitDefaultValue = false)]
		public string Msisdn { get; set; }

		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string Email { get; set; }

		[DataMember(Name = "national_id", EmitDefaultValue = false)]
		public string National_id { get; set; }

		[DataMember(Name = "business_code", EmitDefaultValue = false)]
		public string Business_code { get; set; }

		[DataMember(Name = "bank_sort_code", EmitDefaultValue = false)]
		public int? Bank_sort_code { get; set; }

		[DataMember(Name = "bank_account_no", EmitDefaultValue = false)]
		public int? Bank_account_no { get; set; }

		[DataMember(Name = "external_id", EmitDefaultValue = false)]
		public string External_id { get; set; }

		[DataMember(Name = "payment_media", EmitDefaultValue = false)]
		public string Payment_media { get; set; }

		[DataMember(Name = "amount", EmitDefaultValue = false)]
		public int Amount { get; set; }

		[DataMember(Name = "frequency", EmitDefaultValue = false)]
		public string Frequency { get; set; }

		[DataMember(Name = "project_id", EmitDefaultValue = false)]
		public int Project_id { get; set; }
	}
}
