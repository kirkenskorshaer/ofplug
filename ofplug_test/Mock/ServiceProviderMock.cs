using System;

namespace ofplug_test.Mock
{
	public class ServiceProviderMock : IServiceProvider
	{
		public object Service;

		public object GetService(Type serviceType)
		{
			return Service;
		}
	}
}
