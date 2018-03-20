using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Subscription : AbstractData
	{
		[DataMember(Name = "status", EmitDefaultValue = false)]
		public string Status { get; set; } // "complete"

		[DataMember(Name = "subscription_customer_no", EmitDefaultValue = false)]
		public int? Subscription_customer_no { get; set; } // "1234"

		[DataMember(Name = "bse_guid", EmitDefaultValue = false)]
		public Guid? Bse_guid { get; set; } // "4D943EA2-5376-AEFA-CF61-D6E8A6ADED03"

		[DataMember(Name = "contact_id", EmitDefaultValue = false)]
		public int? Contact_id { get; set; } // "1703"

		[DataMember(Name = "order_id", EmitDefaultValue = false)]
		public string Order_id { get; set; } // "020001704"

		[DataMember(Name = "created_ts", EmitDefaultValue = false)]
		public string Created_ts; // "2018-01-30 13:40:45"
		public DateTime? Created_ts_value { get { return GetDate(Created_ts); } set { Created_ts = SetDate(value); } }

		[DataMember(Name = "state", EmitDefaultValue = false)]
		public string State { get; set; } // "subscribing"

		[DataMember(Name = "payment_gateway", EmitDefaultValue = false)]
		public string Payment_gateway { get; set; } // "of"

		[DataMember(Name = "payment_media", EmitDefaultValue = false)]
		public string Payment_media { get; set; } // "pbs"

		[DataMember(Name = "payment_media_type", EmitDefaultValue = false)]
		public string Payment_media_type { get; set; } // "pbs"

		[DataMember(Name = "msisdn", EmitDefaultValue = false)]
		public string Msisdn { get; set; } // "30951964"

		[DataMember(Name = "bank_account_no", EmitDefaultValue = false)]
		public string Bank_account_no { get; set; } // "1234567890"

		[DataMember(Name = "bank_sort_code", EmitDefaultValue = false)]
		public string Bank_sort_code { get; set; } // "1234
	}
}
