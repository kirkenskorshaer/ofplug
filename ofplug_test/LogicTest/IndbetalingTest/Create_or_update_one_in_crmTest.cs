using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug_test.Abstract;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.IndbetalingTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Creates_an_indbetaling()
		{
			ofplug.Logic.Indbetaling.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_indbetaling();
			Add_crm_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "new_indbetaling");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Create, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Update_an_indbetaling()
		{
			ofplug.Logic.Indbetaling.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_indbetaling(of_indbetaling => of_indbetaling.Amount = 100);
			Add_crm_indbetaling();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "new_indbetaling");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Update, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void If_a_contact_is_associated_the_contact_will_be_created()
		{
			ofplug.Logic.Indbetaling.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_indbetaling(indbetaling => indbetaling.Contact_id = _id.Get_id("of_contact_id"));
			Add_crm_empty(2);
			Add_of_contact();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "new_indbetaling");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.Create, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(2, 4);
		}

		[TestMethod]
		public void If_an_aftale_is_associated_the_aftale_will_be_created()
		{
			ofplug.Logic.Indbetaling.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_of_indbetaling(indbetaling => indbetaling.Agreement_id = _id.Get_id("of_aftale_id"));
			Add_crm_empty(2);
			Add_crm_contact();
			Add_of_aftale();
			Add_of_contact();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "new_indbetaling");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_bidragsaftale");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.Create, "nrq_bidragsaftale");
			Assert_crm_operation(4, Mock.OrganizationServiceMock.Operation.Create, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(2, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(3, 5);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_indbetaling_id_InArgument", 1624 },
			};

			return input;
		}

		private ofplug.Logic.Indbetaling.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Indbetaling.Create_or_update_one_in_crm creator = new ofplug.Logic.Indbetaling.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
