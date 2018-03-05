using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Create_or_update_one_manual_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_a_contact()
		{
			ofplug.Logic.Contact.Create_or_update_one_manual_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_contact();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("contact id") });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Updates_contact_in_of_if_it_already_exists()
		{
			ofplug.Logic.Contact.Create_or_update_one_manual_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_contact();
			Add_crm_contact(contact => contact.new_ofcontactid = _id.Get_id("of_contact_id"));
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_contact_id") });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Contact));
			Assert_number_of_operations(2, 1);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "ContactEntityReference", new EntityReference("contact", Guid.NewGuid()) },
			};

			return input;
		}

		private ofplug.Logic.Contact.Create_or_update_one_manual_in_of Arrange_creator()
		{
			ofplug.Logic.Contact.Create_or_update_one_manual_in_of creator = new ofplug.Logic.Contact.Create_or_update_one_manual_in_of()
			{
				IsTest = true,
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
