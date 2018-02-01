using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class TracingServiceTest : ITracingService
	{
		public List<KeyValuePair<String, object[]>> Log = new List<KeyValuePair<String, object[]>>();
		public void Trace(string format, params object[] args)
		{
			Log.Add(new KeyValuePair<string, object[]>(format, args));
		}
	}
}
