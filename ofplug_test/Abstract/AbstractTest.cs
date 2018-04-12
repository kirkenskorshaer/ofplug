using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ofplug_test.Mock;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

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

		protected void Arrange_input_parameter(ofplug.crm.AbstractCrm crm_entity)
		{
			crm_entity.CrmEntity = new Entity(crm_entity.Logical_name);
			crm_entity.Fill_fields();

			_pluginExecutionContext.InputParameters = new ParameterCollection
			{
				{ "Target", crm_entity.CrmEntity }
			};
		}

		protected void Add_crm_config()
		{
			ofplug.crm.Config config = new ofplug.crm.Config(_service, _tracingService, false)
			{
				CrmEntity = new Entity("nrq_configuration"),
				Nrq_of_token = "",
				Nrq_of_url = "",
			};

			config.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { config.CrmEntity });
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

		protected void Add_crm_start_aftale()
		{
			Add_crm_start_aftale(crm_start_aftale => { });
		}

		protected void Add_crm_start_aftale(Action<ofplug.crm.AgreementRequest> adjust_start_aftale)
		{
			ofplug.crm.AgreementRequest crm_start_aftale = new ofplug.crm.AgreementRequest(_service, _tracingService)
			{
				Nrq_amount = new Money(100)
			};

			adjust_start_aftale(crm_start_aftale);

			Add_crm_start_aftale(crm_start_aftale);
		}

		protected void Add_crm_start_aftale(ofplug.crm.AgreementRequest crm_start_aftale)
		{
			crm_start_aftale.CrmEntity = new Entity("StartAftale");//todo norriq navn

			crm_start_aftale.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { crm_start_aftale.CrmEntity });
		}


		protected void Add_crm_abonnement()
		{
			Add_crm_abonnement(crm_abonnement => { });
		}

		protected void Add_crm_abonnement(Action<ofplug.crm.Abonnement> adjust_abonnement)
		{
			ofplug.crm.Abonnement crm_abonnement = new ofplug.crm.Abonnement(_service, _tracingService)
			{
			};

			adjust_abonnement(crm_abonnement);

			Add_crm_abonnement(crm_abonnement);
		}

		protected void Add_crm_abonnement(ofplug.crm.Abonnement crm_abonnement)
		{
			crm_abonnement.CrmEntity = new Entity("Abonnement");//todo norriq name

			crm_abonnement.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { crm_abonnement.CrmEntity });
		}

		protected void Add_crm_indbetaling()
		{
			Add_crm_indbetaling(crm_indbetaling => { });
		}

		protected void Add_crm_indbetaling(Action<ofplug.crm.Indbetaling> adjust_indbetaling)
		{
			ofplug.crm.Indbetaling crm_indbetaling = new ofplug.crm.Indbetaling(_service, _tracingService)
			{
			};

			adjust_indbetaling(crm_indbetaling);

			Add_crm_indbetaling(crm_indbetaling);
		}

		protected void Add_crm_indbetaling(ofplug.crm.Indbetaling crm_indbetaling)
		{
			crm_indbetaling.CrmEntity = new Entity("new_indbetaling");

			crm_indbetaling.Fill_fields();

			_service.entitiesToReturn.Enqueue(new List<Entity> { crm_indbetaling.CrmEntity });
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

		protected void Add_of_indbetaling()
		{
			Add_of_indbetaling(of_indbetaling => { });
		}

		protected void Add_of_indbetaling(Action<ofplug.of.data.Payment> adjust_indbetaling)
		{
			ofplug.of.data.Payment of_indbetaling = new ofplug.of.data.Payment()
			{
				Of_id = _id.Get_id("of_contact_id")
			};

			adjust_indbetaling(of_indbetaling);

			_sender.data_to_return.Enqueue(of_indbetaling);
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

		protected void Add_of_abonnement()
		{
			Add_of_abonnement(of_abonnement => { });
		}

		protected void Add_of_abonnement(Action<ofplug.of.data.Subscription> adjust_of_abonnement)
		{
			ofplug.of.data.Subscription of_abonnement = new ofplug.of.data.Subscription()
			{
				Of_id = _id.Get_id("of_abonnement_id"),
				Contact_id = _id.Get_id("of_contact_id"),
			};

			adjust_of_abonnement(of_abonnement);

			_sender.data_to_return.Enqueue(of_abonnement);
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

			string actual_entity_name = string.Empty;
			if (log.Key == OrganizationServiceMock.Operation.RetrieveMultiple)
			{
				actual_entity_name = ((QueryExpression)log.Value).EntityName;
			}
			else
			{
				actual_entity_name = ((Entity)log.Value).LogicalName;
			}

			Assert.AreEqual(operation + " " + entity_name, log.Key + " " + actual_entity_name, " (" + log_index.ToString() + ") ");
		}

		protected void Assert_of_operation(int log_index, SenderMock.Operation operation, Type type, string url_part = null)
		{
			SenderLog log = _sender.Log[log_index];

			//Assert.AreEqual(operation, log.Operation, " (" + log_index.ToString() + ") " + log.Request?.GetType().Name + " - " + log.Url);
			//Assert.AreEqual(type, log.Request?.GetType(), " (" + log_index.ToString() + ") " + log.Operation.ToString() + " - " + log.Url);
			Assert.AreEqual(operation + " " + type?.Name, log.Operation + " " + log.Request?.GetType()?.Name, " (" + log_index.ToString() + ") " + log.Url);

			if (url_part != null)
			{
				Assert.IsTrue(log.Url.Contains(url_part), " (" + log_index.ToString() + ") " + log.Request?.GetType().Name + " - " + log.Operation.ToString());
			}
		}

		protected void Assert_no_writes()
		{
			Assert_no_crm_writes();
			Assert_no_of_writes();
		}

		protected void Assert_no_crm_writes()
		{
			List<OrganizationServiceMock.Operation> forbidden_crm_operations = new List<OrganizationServiceMock.Operation>()
			{
				OrganizationServiceMock.Operation.Associate,
				OrganizationServiceMock.Operation.Create,
				OrganizationServiceMock.Operation.Delete,
				OrganizationServiceMock.Operation.Disassociate,
				OrganizationServiceMock.Operation.Execute,
				OrganizationServiceMock.Operation.Update,
			};

			bool crm_manipulation = _service.Log.Any(log => forbidden_crm_operations.Contains(log.Key));

			Assert.IsFalse(crm_manipulation);
		}

		protected void Assert_no_of_writes()
		{
			List<SenderMock.Operation> forbidden_of_operations = new List<SenderMock.Operation>()
			{
				SenderMock.Operation.Delete,
				SenderMock.Operation.Patch,
				SenderMock.Operation.Post,
				SenderMock.Operation.Put,
			};

			bool of_manipulation = _sender.Log.Any(log => forbidden_of_operations.Contains(log.Operation));

			Assert.IsFalse(of_manipulation);
		}

		protected void Assert_number_of_operations(int of_operations, int crm_operations)
		{
			Assert.AreEqual(of_operations, _sender.Log.Count);
			Assert.AreEqual(crm_operations, _service.Log.Count);
		}

		protected ofplug.of.Connection Arrange_of_connection()
		{
			ofplug.of.Connection of_connection = new ofplug.of.Connection(string.Empty, string.Empty);

			of_connection.Replace_sender(_sender);

			return of_connection;
		}
	}
}
