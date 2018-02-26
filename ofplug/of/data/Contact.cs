using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Contact : AbstractData
	{
		[DataMember(Name = "ID")]
		public int? Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; } // "Christian Laugesen",

		[DataMember(Name = "email")]
		public string Email { get; set; } // "c.laugesen@gmail.com",

		[DataMember(Name = "cpr")]
		public string Cpr { get; set; } // "1111111118",

		[DataMember(Name = "address")]
		public string Address { get; set; } // "Houmanns Allé 4, 3. tv.",

		[DataMember(Name = "postcode")]
		public string Postcode { get; set; } // "2400",

		[DataMember(Name = "city")]
		public string City { get; set; } // "København NV",

		[DataMember(Name = "country")]
		public string Country { get; set; } // "DK",

		[DataMember(Name = "gender")]
		public string Gender { get; set; } // "female",

		[DataMember(Name = "birthday")]
		public string Birthday { get; set; } // "11. nov. 2011",

		[DataMember(Name = "birthday_stamp")]
		public string Birthday_stamp { get; set; } // "2011-11-11",
		public DateTime? Birthday_stamp_value { get { return GetDate(Birthday_stamp); } set { Birthday_stamp = SetDate(value); } }

		[DataMember(Name = "dawa_id")]
		public string Dawa_id { get; set; } // "0a3f509e-c57c-32b8-e044-0003ba298018",

		[DataMember(Name = "lat")]
		public double? Lat { get; set; } // "55.70414287",

		[DataMember(Name = "long")]
		public double? Long { get; set; } // "12.52861942",

		[DataMember(Name = "valid_adr_ts")] //
		public string Valid_adr_ts { get; set; } // "2018-01-30 12:40:45",
		public DateTime? Valid_adr_ts_value { get { return GetDateTime(Valid_adr_ts); } set { Valid_adr_ts = SetDateTime(value); } }

		[DataMember(Name = "external_id")]
		public string External_id { get; set; } // "1234",

		[DataMember(Name = "first_name")]
		public string First_name { get; set; } // "Christian",

		[DataMember(Name = "last_name")]
		public string Last_name { get; set; } // "Laugesen",

		[DataMember(Name = "msisdn")]
		public string Msisdn { get; set; } // "30951964"
	}
}
