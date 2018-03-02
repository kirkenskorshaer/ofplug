using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ofplug_test.Mock;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.Abstract
{
	public class AbstractTest
	{
		protected TracingServiceTest _tracingService;
		protected OrganizationServiceMock _service;
		protected CodeActivityContext _codeActivityContext;
		protected SenderMock _sender = new SenderMock();

		public AbstractTest()
		{
			_tracingService = new TracingServiceTest();
			_service = new OrganizationServiceMock();
		}

		protected void AddConfig()
		{
			Entity configEntity = new Entity("nrq_settings");
			configEntity["nrq_url"] = "http://of.devflowtwo.com/kirkenskorshaer/api/v2/";
			configEntity["nrq_aggrement_step"] = 50;
			_service.entitiesToReturn.Enqueue(new List<Entity> { configEntity });
		}

		protected void Add_crm_aftale()
		{
			Add_crm_aftale(crm_aftale => { });
		}

		protected void Add_crm_aftale(Action<ofplug.crm.Aftale> adjust_aftale)
		{
			ofplug.crm.Aftale crm_aftale = new ofplug.crm.Aftale(_service, _tracingService)
			{
				nrq_beloeb = new Money(100)
			};

			adjust_aftale(crm_aftale);

			Add_crm_aftale(crm_aftale);
		}

		protected void Add_crm_aftale(ofplug.crm.Aftale crm_aftale)
		{
			crm_aftale.CrmEntity = new Entity("nrq_bidragsaftale");

			crm_aftale.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { crm_aftale.CrmEntity });
		}

		protected void Add_crm_empty(int number_of_empty_entity_lists = 1)
		{
			for (int index = 0; index < number_of_empty_entity_lists; index++)
			{
				_service.entitiesToReturn.Enqueue(new List<Entity>());
			}
		}

		protected void Add_crm_contact()
		{
			Add_crm_contact(new ofplug.crm.Contact(_service, _tracingService) { });
		}

		protected void Add_crm_contact(ofplug.crm.Contact contact)
		{
			contact.CrmEntity = new Entity("contact");

			contact.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { contact.CrmEntity });
		}

		protected void Add_of_contact()
		{
			ofplug.of.data.Contact of_contact = new ofplug.of.data.Contact()
			{
				Of_id = int.MaxValue,
				First_name = "unittest"
			};

			_sender.data_to_return.Enqueue(of_contact);
		}

		protected void Add_of_aftale()
		{
			ofplug.of.data.Agreement of_aftale = new ofplug.of.data.Agreement()
			{
				Of_id = int.MaxValue,
				Contact_id = int.MaxValue,
				Amount = 100
			};

			_sender.data_to_return.Enqueue(of_aftale);
		}

		protected void Add_of_empty(int number_of_empty_data = 1)
		{
			for (int index = 0; index < number_of_empty_data; index++)
			{
				_sender.data_to_return.Enqueue(null);
			}
		}

		protected void Assert_crm_operation(int log_index, OrganizationServiceMock.Operation operation, string entity_name)
		{
			KeyValuePair<OrganizationServiceMock.Operation, object> log = _service.Log[log_index];

			Assert.AreEqual(operation, log.Key);

			if (operation == OrganizationServiceMock.Operation.RetrieveMultiple)
			{
				Assert.AreEqual(entity_name, ((QueryExpression)log.Value).EntityName);

				return;
			}

			Assert.AreEqual(entity_name, ((Entity)log.Value).LogicalName);
		}
	}
}
