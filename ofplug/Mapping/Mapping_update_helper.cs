using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Mapping_update_helper
	{
		public static void Add_if_unequal<CompareType>(List<string> parameters_to_update, string name, CompareType a, CompareType b)
		{
			if (a == null && b == null)
			{
				return;
			}

			if (a == null || b == null)
			{
				parameters_to_update.Add(name);
				return;
			}

			if (a.Equals(b) == false)
			{
				parameters_to_update.Add(name);
			}
		}
	}
}
