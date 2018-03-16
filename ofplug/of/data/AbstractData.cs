using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public abstract class AbstractData
	{
		public int? Of_id;

		[DataMember(Name = "ID", EmitDefaultValue = false)]
		public int? Id { get; set; }

		[DataMember(Name = "custom_1", EmitDefaultValue = false)]
		public string Crm_id { get; set; }

		[DataMember(Name = "custom_2", EmitDefaultValue = false)]
		public string Unused_custom_2 { get; set; }

		[DataMember(Name = "custom_3", EmitDefaultValue = false)]
		public string Unused_custom_3 { get; set; }

		protected DateTime? GetDate(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}
			return DateTime.ParseExact(input, "yyyy-MM-dd", CultureInfo.CurrentCulture);
		}

		protected string SetDate(DateTime? value)
		{
			if (value.HasValue == false)
			{
				return null;
			}

			return value.Value.ToString("yyyy-MM-dd");
		}

		protected DateTime? GetDateTime(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return null;
			}
			return DateTime.ParseExact(input, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
		}

		protected string SetDateTime(DateTime? value)
		{
			if (value.HasValue == false)
			{
				return null;
			}

			return value.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
