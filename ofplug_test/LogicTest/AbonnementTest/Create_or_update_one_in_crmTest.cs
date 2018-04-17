using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.AbonnementTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_an_Abonnement()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_empty(4);
			Add_of_abonnement();
			Add_of_contact();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_subscription");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(4, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(5, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_crm_operation(6, Mock.OrganizationServiceMock.Operation.Create, "nrq_subscription");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null, "subscription");
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null, "contact");
			Assert_number_of_operations(2, 7);
		}

		[TestMethod]
		public void Nothing_happens_when_no_abonnement_could_be_found()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_of_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 1);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_abonnement_id_InArgument", 0 },
			};

			return input;
		}

		private ofplug.Logic.Abonnement.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_in_crm creator = new ofplug.Logic.Abonnement.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
