using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class SelectedDictionary : Dictionary<int, string>
	{
		public int? SelectedKey { get; private set; }
		public string SelectedValue
		{
			get
			{
				if (SelectedKey.HasValue == false)
				{
					return null;
				}
				return this[SelectedKey.Value];
			}
		}

		public void Select(int? key)
		{
			if (key == null || ContainsKey(key.Value))
			{
				SelectedKey = key;
			}
			else
			{
				throw new Exception("unknown key: " + key.ToString());
			}
		}

		public void Select(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				SelectedKey = null;
				return;
			}

			if (ContainsValue(value))
			{
				SelectedKey = this.First(element => element.Value == value).Key;
			}
			else
			{
				throw new Exception("no element with value: " + value.ToString());
			}
		}
	}
}
