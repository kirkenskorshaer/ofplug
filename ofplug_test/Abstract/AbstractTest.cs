using ofplug_test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ofplug_test.Abstract
{
	public class AbstractTest
	{
		protected TracingServiceTest _tracingService;
		protected OrganizationServiceTest _organizationService;

		public AbstractTest()
		{
			_tracingService = new TracingServiceTest();
			_organizationService = new OrganizationServiceTest();
		}
	}
}
