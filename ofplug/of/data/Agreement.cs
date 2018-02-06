using System;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Agreement
	{
		[DataMember(Name = "amount")]
		public int Amount { get; set; }

		[DataMember(Name = "amount_type")]
		public string Amount_type { get; set; }

		[DataMember(Name = "currency")]
		public string Currency { get; set; }

		[DataMember(Name = "frequency")]
		public string Frequency { get; set; }

		[DataMember(Name = "agreement_start_type")]
		public string Agreement_start_type { get; set; }

		[DataMember(Name = "agreement_start_ts")]
		public string Agreement_start_ts { get; set; }
		public DateTime Agreement_start_ts_value
		{
			get
			{
				return DateTime.Parse(Agreement_start_ts);
			}
			set
			{
				Agreement_start_ts = value.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		[DataMember(Name = "payment_media")]
		public string Payment_media { get; set; }

		[DataMember(Name = "charge_ts")]
		public string Charge_ts { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "subscription_id")]
		public int Subscription_id { get; set; }

		[DataMember(Name = "contact_id")]
		public int Contact_id { get; set; }

		[DataMember(Name = "project_id")]
		public int Project_id { get; set; }
	}
}
