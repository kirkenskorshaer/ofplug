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
		protected ServiceProviderMock _serviceProvider;
		protected PluginExecutionContextMock _pluginExecutionContext;
		protected SenderMock _sender = new SenderMock();
		protected IdMock _id = new IdMock();

		public AbstractTest()
		{
			_tracingService = new TracingServiceTest();
			_service = new OrganizationServiceMock();
			_serviceProvider = new ServiceProviderMock()
			{
				Service = _service
			};
			_pluginExecutionContext = new PluginExecutionContextMock();
		}

		protected void AddConfig()
		{
			Entity configEntity = new Entity("nrq_settings");
			configEntity["nrq_url"] = "http://of.devflowtwo.com/kirkenskorshaer/api/v2/";
			configEntity["nrq_aggrement_step"] = 50;
			_service.entitiesToReturn.Enqueue(new List<Entity> { configEntity });
		}

		protected void Arrange_input_parameter(ofplug.crm.Aftale crm_aftale)
		{
			crm_aftale.CrmEntity = new Entity(crm_aftale.Logical_name);
			crm_aftale.Fill_fields();

			_pluginExecutionContext.InputParameters = new ParameterCollection
			{
				{ "Target", crm_aftale.CrmEntity }
			};
		}

		protected void Arrange_input_parameter(ofplug.crm.Contact crm_contact)
		{
			crm_contact.CrmEntity = new Entity(crm_contact.Logical_name);
			crm_contact.Fill_fields();

			_pluginExecutionContext.InputParameters = new ParameterCollection
			{
				{ "Target", crm_contact.CrmEntity }
			};
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
			Add_crm_contact(contact => { });
		}

		protected void Add_crm_contact(Action<ofplug.crm.Contact> adjust_contact)
		{
			ofplug.crm.Contact crm_contact = new ofplug.crm.Contact(_service, _tracingService);

			adjust_contact(crm_contact);

			Add_crm_contact(crm_contact);
		}

		protected void Add_crm_contact(ofplug.crm.Contact contact)
		{
			contact.CrmEntity = new Entity("contact");

			contact.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { contact.CrmEntity });
		}

		protected void Add_of_contact()
		{
			Add_of_contact(of_contact => { });
		}

		protected void Add_of_contact(Action<ofplug.of.data.Contact> adjust_contact)
		{
			ofplug.of.data.Contact of_contact = new ofplug.of.data.Contact()
			{
				Of_id = _id.Get_id("of_contact_id"),
				First_name = "unittest"
			};

			adjust_contact(of_contact);

			_sender.data_to_return.Enqueue(of_contact);
		}

		protected void Add_of_aftale()
		{
			ofplug.of.data.Agreement of_aftale = new ofplug.of.data.Agreement()
			{
				Of_id = _id.Get_id("of_aftale_id"),
				Contact_id = _id.Get_id("of_contact_id"),
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

		protected void Assert_of_operation(int log_index, SenderMock.Operation operation, Type type)
		{
			SenderLog log = _sender.Log[log_index];

			Assert.AreEqual(operation, log.Operation);
			Assert.AreEqual(type, log.Request?.GetType());
		}

		protected void Assert_number_of_operations(int of_operations, int crm_operations)
		{
			Assert.AreEqual(of_operations, _sender.Log.Count);
			Assert.AreEqual(crm_operations, _service.Log.Count);
		}
	}
}
