using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Update_status_manual_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Updates_status()
		{
			ofplug.Logic.Indbetaling.Update_status_manual_in_of creator = Arrange_creator();
			Add_crm_config();
			Add_crm_indbetaling(crm_indbetaling => crm_indbetaling.Nrq_of_id = _id.Get_id("indbetaling id"));
			Dictionary<string, object> input = Arrange_input();
			Add_of_indbetaling(of_indbetaling => of_indbetaling.State = "not updated");
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("indbetaling id") });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "new_indbetaling");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Payment));
			Assert_number_of_operations(2, 2);
		}

		private ofplug.Logic.Indbetaling.Update_status_manual_in_of Arrange_creator()
		{
			ofplug.Logic.Indbetaling.Update_status_manual_in_of creator = new ofplug.Logic.Indbetaling.Update_status_manual_in_of()
			{
				IsTest = true,
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "IndbetalingEntityReference", new EntityReference("new_indbetaling", Guid.NewGuid()) },
			};

			return input;
		}
	}
}
