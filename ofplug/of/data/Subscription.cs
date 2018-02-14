using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Subscription : AbstractData
	{
		[DataMember(Name = "ID")]
		public int? Id; // "1704"

		[DataMember(Name = "status")]
		public string Status; // "complete"

		[DataMember(Name = "subscription_customer_no")]
		public int? Subscription_customer_no; // "1234"

		[DataMember(Name = "bse_guid")]
		public Guid? Bse_guid; // "4D943EA2-5376-AEFA-CF61-D6E8A6ADED03"

		[DataMember(Name = "contact_id")]
		public int? Contact_id; // "1703"

		[DataMember(Name = "order_id")]
		public string Order_id; // "020001704"

		[DataMember(Name = "created_ts")]
		public string Created_ts; // "2018-01-30 13:40:45"
		public DateTime? Created_ts_value { get { return GetDate(Created_ts); } set { Created_ts = SetDate(value); } }

		[DataMember(Name = "state")]
		public string State; // "subscribing"

		[DataMember(Name = "payment_gateway")]
		public string Payment_gateway; // "of"

		[DataMember(Name = "payment_media")]
		public string Payment_media; // "pbs"

		[DataMember(Name = "payment_media_type")]
		public string Payment_media_type; // "pbs"

		[DataMember(Name = "msisdn")]
		public string Msisdn; // "30951964"

		[DataMember(Name = "bank_account_no")]
		public string Bank_account_no; // "1234567890"

		[DataMember(Name = "bank_sort_code")]
		public string Bank_sort_code; // "1234
	}
}
