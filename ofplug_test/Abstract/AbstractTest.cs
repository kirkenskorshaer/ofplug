using Microsoft.Xrm.Sdk;
using ofplug_test.Mock;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.Abstract
{
	public class AbstractTest
	{
		protected TracingServiceTest _tracingService;
		protected OrganizationServiceTest _service;
		protected CodeActivityContext _codeActivityContext;

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

		protected void Add_aftale()
		{
			Entity entity = new Entity("nrq_bidragsaftale");
			_service.entitiesToReturn.Enqueue(new List<Entity> { entity });
		}

		protected void Add_empty()
		{
			_service.entitiesToReturn.Enqueue(new List<Entity>());
		}

		protected void Add_contact(ofplug.crm.Contact contact)
		{
			contact.CrmEntity = new Entity("contact");

			contact.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { contact.CrmEntity });
		}
	}
}
