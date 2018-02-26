using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Payment : AbstractData
	{
		[DataMember(Name = "id", EmitDefaultValue = false)]
		public int Id { get; set; }

		[DataMember(Name = "amount", EmitDefaultValue = false)]
		public int? Amount { get; set; } //: "200",

		[DataMember(Name = "amount_type", EmitDefaultValue = false)]
		public string Amount_type { get; set; } //: "donation",

		[DataMember(Name = "currency", EmitDefaultValue = false)]
		public string Currency { get; set; } //: "208",

		[DataMember(Name = "ocr", EmitDefaultValue = false)]
		public string Ocr { get; set; } //: "000000100016245",

		[DataMember(Name = "agreement_id", EmitDefaultValue = false)]
		public int? Agreement_id { get; set; } //: "59",

		[DataMember(Name = "subscription_id", EmitDefaultValue = false)]
		public int? Subscription_id { get; set; } //: "60",

		[DataMember(Name = "contact_id", EmitDefaultValue = false)]
		public int? Contact_id { get; set; } //: "58",

		[DataMember(Name = "form_id", EmitDefaultValue = false)]
		public int? Form_id { get; set; } //: "18",

		[DataMember(Name = "project_id", EmitDefaultValue = false)]
		public int? Project_id { get; set; } //: "17",

		[DataMember(Name = "order_id", EmitDefaultValue = false)]
		public int? Order_id { get; set; } //: "010001624",

		[DataMember(Name = "created_ts", EmitDefaultValue = false)]
		public string Created_ts { get; set; } //: "2018-01-21 09:53:00",
		public DateTime? Created_ts_value { get { return GetDateTime(Created_ts); } set { Created_ts = SetDateTime(value); } }

		[DataMember(Name = "payment_due_ts", EmitDefaultValue = false)]
		public string Payment_due_ts { get; set; } //: "2018-02-01 12:00:00",
		public DateTime? Payment_due_ts_value { get { return GetDateTime(Payment_due_ts); } set { Payment_due_ts = SetDateTime(value); } }

		[DataMember(Name = "state", EmitDefaultValue = false)]
		public string State { get; set; } //: "expired",

		[DataMember(Name = "payment_gateway", EmitDefaultValue = false)]
		public string Payment_gateway { get; set; } //: "of",

		[DataMember(Name = "payment_media", EmitDefaultValue = false)]
		public string Payment_media { get; set; } //: "pbs",

		[DataMember(Name = "payment_method", EmitDefaultValue = false)]
		public string Payment_method { get; set; } //: "agreement",

		[DataMember(Name = "payment_media_type", EmitDefaultValue = false)]
		public string Payment_media_type { get; set; } //: "pbs",

		[DataMember(Name = "gateway_subscription_id", EmitDefaultValue = false)]
		public int? Gateway_subscription_id { get; set; } //: "916766530"
	}
}
