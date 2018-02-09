using Microsoft.Xrm.Sdk;
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
		protected OrganizationServiceTest _service;

		public AbstractTest()
		{
			_tracingService = new TracingServiceTest();
			_service = new OrganizationServiceTest();
		}

		protected void AddConfig()
		{
			Entity configEntity = new Entity("nrq_settings");
			configEntity["nrq_url"] = "http://of.devflowtwo.com/kirkenskorshaer/api/v2/";
			configEntity["nrq_aggrement_step"] = 50;
			_service.entitiesToReturn.Enqueue(new List<Entity> { configEntity });
		}

		protected void AddAftale()
		{
			Entity entity = new Entity("nrq_bidragsaftale");
			_service.entitiesToReturn.Enqueue(new List<Entity> { entity });
		}

		protected void AddEmpty()
		{
			_service.entitiesToReturn.Enqueue(new List<Entity>());
		}
	}
}
