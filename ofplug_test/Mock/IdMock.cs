using System;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class IdMock
	{
		private Random _random = new Random();
		private Dictionary<string, int> _random_cache = new Dictionary<string, int>();

		public int Get_id(string key)
		{
			if (_random_cache.ContainsKey(key) == false)
			{
				_random_cache.Add(key, _random.Next(int.MinValue, int.MaxValue));
			}

			return _random_cache[key];
		}
	}
}
