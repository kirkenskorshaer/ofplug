using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Payment : AbstractData
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "amount")]
		public int? Amount { get; set; } //: "200",

		[DataMember(Name = "amount_type")]
		public string Amount_type { get; set; } //: "donation",

		[DataMember(Name = "currency")]
		public string Currency { get; set; } //: "208",

		[DataMember(Name = "ocr")]
		public string Ocr { get; set; } //: "000000100016245",

		[DataMember(Name = "agreement_id")]
		public int? Agreement_id { get; set; } //: "59",

		[DataMember(Name = "subscription_id")]
		public int? Subscription_id { get; set; } //: "60",

		[DataMember(Name = "contact_id")]
		public int? Contact_id { get; set; } //: "58",

		[DataMember(Name = "form_id")]
		public int? Form_id { get; set; } //: "18",

		[DataMember(Name = "project_id")]
		public int? Project_id { get; set; } //: "17",

		[DataMember(Name = "order_id")]
		public int? Order_id { get; set; } //: "010001624",

		[DataMember(Name = "created_ts")]
		public string Created_ts { get; set; } //: "2018-01-21 09:53:00",
		public DateTime? Created_ts_value { get { return GetDateTime(Created_ts); } set { Created_ts = SetDateTime(value); } }

		[DataMember(Name = "payment_due_ts")]
		public string Payment_due_ts { get; set; } //: "2018-02-01 12:00:00",
		public DateTime? Payment_due_ts_value { get { return GetDateTime(Payment_due_ts); } set { Payment_due_ts = SetDateTime(value); } }

		[DataMember(Name = "state")]
		public string State { get; set; } //: "expired",

		[DataMember(Name = "payment_gateway")]
		public string Payment_gateway { get; set; } //: "of",

		[DataMember(Name = "payment_media")]
		public string Payment_media { get; set; } //: "pbs",

		[DataMember(Name = "payment_method")]
		public string Payment_method { get; set; } //: "agreement",

		[DataMember(Name = "payment_media_type")]
		public string Payment_media_type { get; set; } //: "pbs",

		[DataMember(Name = "gateway_subscription_id")]
		public int? Gateway_subscription_id { get; set; } //: "916766530"
	}
}
