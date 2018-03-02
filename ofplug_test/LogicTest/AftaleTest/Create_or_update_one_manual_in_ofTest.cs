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
			Add_crm_aftale(aftale => aftale.nrq_bidragyder = new EntityReference("contact", Guid.Empty));
			Add_crm_contact();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = int.MaxValue });
			Add_of_empty(2);

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.Retrieve, "nrq_bidragsaftale");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_of_operation(1, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Agreement));
			Assert_number_of_operations(2, 3);
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
