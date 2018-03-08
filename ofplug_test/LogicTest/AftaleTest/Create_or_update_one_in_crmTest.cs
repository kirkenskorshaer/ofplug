using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug_test.Abstract;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Activities;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Creates_an_aftale()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_empty(4);
			Add_of_aftale();
			Add_of_contact();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_bidragsaftale");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(4, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(5, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_crm_operation(6, Mock.OrganizationServiceMock.Operation.Create, "nrq_bidragsaftale");
		}

		[TestMethod]
		public void Nothing_happens_when_no_aftale_could_be_found()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_of_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 1);
		}

		[TestMethod]
		public void Associates_a_Contact()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_aftale();
			Add_crm_contact();
			Add_of_aftale();
			Add_of_contact();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_bidragsaftale");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			KeyValuePair<Mock.OrganizationServiceMock.Operation, object> result = _service.Log[3];
			Assert.AreEqual("contact", ((EntityReference)((Entity)result.Value)["nrq_bidragyder"]).LogicalName);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_aftale_id_InArgument", 1744 },
			};

			return input;
		}

		private ofplug.Logic.Aftale.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = new ofplug.Logic.Aftale.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
