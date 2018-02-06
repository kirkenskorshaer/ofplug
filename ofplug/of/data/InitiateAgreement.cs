using System.Runtime.Serialization;

namespace ofplug.of.data.Abstract
{
	[DataContract]
	public class InitiateAgreement
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "first_name")]
		public string First_name { get; set; }

		[DataMember(Name = "middle_name")]
		public string Middle_name { get; set; }

		[DataMember(Name = "last_name")]
		public string Last_name { get; set; }

		[DataMember(Name = "address")]
		public string Address { get; set; }

		[DataMember(Name = "postcode")]
		public string Postcode { get; set; }

		[DataMember(Name = "city")]
		public string City { get; set; }

		[DataMember(Name = "country")]
		public string Country { get; set; }

		[DataMember(Name = "msisdn")]
		public string Msisdn { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "cpr")]
		public string Cpr { get; set; }

		[DataMember(Name = "cvr")]
		public string Cvr { get; set; }

		[DataMember(Name = "bank_sort_code")]
		public int Bank_sort_code { get; set; }

		[DataMember(Name = "bank_account_no")]
		public int Bank_account_no { get; set; }

		[DataMember(Name = "external_id")]
		public string External_id { get; set; }

		[DataMember(Name = "payment_media")]
		public string Payment_media { get; set; }

		[DataMember(Name = "amount")]
		public int Amount { get; set; }

		[DataMember(Name = "frequency")]
		public string Frequency { get; set; }

		[DataMember(Name = "project_id")]
		public string Project_id { get; set; }
	}
}
