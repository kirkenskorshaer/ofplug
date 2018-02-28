using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Agreement : AbstractData
	{
		[DataMember(Name = "amount", EmitDefaultValue = false)]
		public int? Amount { get; set; }

		[DataMember(Name = "amount_type", EmitDefaultValue = false)]
		public string Amount_type { get; set; }

		[DataMember(Name = "currency", EmitDefaultValue = false)]
		public string Currency { get; set; }

		[DataMember(Name = "frequency", EmitDefaultValue = false)]
		public string Frequency { get; set; }

		[DataMember(Name = "agreement_start_type", EmitDefaultValue = false)]
		public string Agreement_start_type { get; set; }

		[DataMember(Name = "agreement_start_ts", EmitDefaultValue = false)]
		public string Agreement_start_ts { get; set; }
		public DateTime? Agreement_start_ts_value { get { return GetDateTime(Agreement_start_ts); } set { Agreement_start_ts = SetDateTime(value); } }

		[DataMember(Name = "payment_media", EmitDefaultValue = false)]
		public string Payment_media { get; set; }

		[DataMember(Name = "payment_method", EmitDefaultValue = false)]
		public string Payment_method { get; set; }

		[DataMember(Name = "payment_media_type", EmitDefaultValue = false)]
		public string Payment_media_type { get; set; }

		[DataMember(Name = "charge_ts", EmitDefaultValue = false)]
		public string Charge_ts { get; set; }
		public DateTime? Charge_ts_value { get { return GetDateTime(Charge_ts); } set { Charge_ts = SetDateTime(value); } }

		[DataMember(Name = "notification_ts", EmitDefaultValue = false)]
		public string Notification_ts { get; set; }
		public DateTime? Notification_ts_value { get { return GetDateTime(Notification_ts); } set { Notification_ts = SetDateTime(value); } }

		[DataMember(Name = "created_ts", EmitDefaultValue = false)]
		public string Created_ts { get; set; }
		public DateTime? Created_ts_value { get { return GetDateTime(Created_ts); } set { Created_ts = SetDateTime(value); } }

		[DataMember(Name = "state", EmitDefaultValue = false)]
		public string State { get; set; }

		[DataMember(Name = "subscription_id", EmitDefaultValue = false)]
		public int? Subscription_id { get; set; }

		[DataMember(Name = "contact_id", EmitDefaultValue = false)]
		public int? Contact_id { get; set; }

		[DataMember(Name = "project_id", EmitDefaultValue = false)]
		public int? Project_id { get; set; }
	}
}
