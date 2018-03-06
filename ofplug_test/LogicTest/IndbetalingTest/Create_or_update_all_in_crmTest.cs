using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.IndbetalingTest
{
	[TestClass]
	public class Create_or_update_all_in_crmTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_an_indbetaling()
		{
			ofplug.Logic.Indbetaling.Create_or_update_all_in_crm creator = Arrange_creator();
			_sender.data_to_return.Enqueue(new List<int> { _id.Get_id("indbetaling_id") });
			Add_of_indbetaling();
			Add_crm_empty();

			WorkflowInvoker.Invoke(creator);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "new_indbetaling");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Create, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(2, 2);
		}

		private ofplug.Logic.Indbetaling.Create_or_update_all_in_crm Arrange_creator()
		{
			ofplug.Logic.Indbetaling.Create_or_update_all_in_crm creator = new ofplug.Logic.Indbetaling.Create_or_update_all_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
