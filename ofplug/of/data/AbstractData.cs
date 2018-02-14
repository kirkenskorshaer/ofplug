using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public abstract class AbstractData
	{
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
			return value.GetValueOrDefault().ToString("yyyy-MM-dd");
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
			return value.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
