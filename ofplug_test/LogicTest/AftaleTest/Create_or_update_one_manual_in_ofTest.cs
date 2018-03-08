using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class Create_or_update_one_manual_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_an_aftale()
		{
			ofplug.Logic.Aftale.Create_or_update_one_manual_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_aftale(aftale => aftale.nrq_bidragyder = new EntityReference("contact", Guid.Empty));
			Add_crm_contact();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("contact id") });
			Add_of_empty(2);

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "nrq_bidragsaftale");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_of_operation(1, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Agreement));
			Assert_number_of_operations(2, 4);
		}

		[TestMethod]
		public void Does_not_create_a_contact_if_no_contact_is_attached_to_aftale()
		{
			ofplug.Logic.Aftale.Create_or_update_one_manual_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_aftale();
			Add_of_empty(1);

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "nrq_bidragsaftale");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Agreement));
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Updates_aftale_in_of_if_it_already_exists()
		{
			ofplug.Logic.Aftale.Create_or_update_one_manual_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_of_aftale();
			Add_crm_aftale(aftale => aftale.nrq_type = _id.Get_id("of_contact_id").ToString());
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_contact_id") });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "nrq_bidragsaftale");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Agreement));
			Assert_number_of_operations(2, 2);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "AftaleEntityReference", new EntityReference("nrq_bidragsaftale", Guid.NewGuid()) },
			};

			return input;
		}

		private ofplug.Logic.Aftale.Create_or_update_one_manual_in_of Arrange_creator()
		{
			ofplug.Logic.Aftale.Create_or_update_one_manual_in_of creator = new ofplug.Logic.Aftale.Create_or_update_one_manual_in_of()
			{
				IsTest = true,
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
