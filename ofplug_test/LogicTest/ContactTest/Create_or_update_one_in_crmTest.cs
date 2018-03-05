using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug_test.Abstract;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Contact_can_be_created()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_contact();
			Add_crm_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Contact_can_be_updated()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_contact();
			Add_crm_contact(new ofplug.crm.Contact(_service, _tracingService) { firstname = "tsts_frst_nm" });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Nothing_happens_if_no_of_contact_can_be_found()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 0);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_contact_id_InArgument", 1703 },
			};

			return input;
		}

		private ofplug.Logic.Contact.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = new ofplug.Logic.Contact.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
