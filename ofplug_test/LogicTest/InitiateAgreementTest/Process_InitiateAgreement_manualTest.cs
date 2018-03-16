using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.InitiateAgreementTest
{
	[TestClass]
	public class Process_InitiateAgreement_manualTest : Abstract_InitiateAgreement
	{
		[TestMethod]
		public void Creates_data_in_of_and_updates_crm()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_manual creator = Arrange_creator();
			Add_crm_config();
			Add_crm_start_aftale();
			Arrange_crm_data();
			Arrange_of_data();
			Dictionary<string, object> input = Arrange_input();

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "StartAftale");
			BaseAssert(2);
			Assert_number_of_operations(9, 13);
		}

		private ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_manual Arrange_creator()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_manual creator = new ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_manual()
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
				{ "StartAftaleEntityReference", new EntityReference("StartAftale", Guid.NewGuid()) },
			};

			return input;
		}
	}
}
