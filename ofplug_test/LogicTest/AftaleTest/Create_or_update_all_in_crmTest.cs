using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class Create_or_update_all_in_crmTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_an_aftale()
		{
			ofplug.Logic.Aftale.Create_or_update_all_in_crm creator = Arrange_creator();
			Add_crm_empty(4);
			_sender.data_to_return.Enqueue(new List<int> { int.MaxValue });
			Add_of_aftale();
			Add_of_contact();

			WorkflowInvoker.Invoke(creator);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_bidragsaftale");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(4, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_crm_operation(5, Mock.OrganizationServiceMock.Operation.Create, "nrq_bidragsaftale");
		}

		private ofplug.Logic.Aftale.Create_or_update_all_in_crm Arrange_creator()
		{
			ofplug.Logic.Aftale.Create_or_update_all_in_crm creator = new ofplug.Logic.Aftale.Create_or_update_all_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
