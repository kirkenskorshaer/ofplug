using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ofplug_test.LogicTest.InitiateAgreementTest
{
	[TestClass]
	public class Process_InitiateAgreement_automaticTest : Abstract_InitiateAgreement
	{
		/*
		[TestMethod]
		public void Creates_data_in_of_and_updates_crm()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.AgreementRequest(_service, _tracingService) { Nrq_amount = new Microsoft.Xrm.Sdk.Money(100) });
			Add_crm_config();
			Arrange_crm_data();
			Arrange_of_data();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			BaseAssert(1);
			Assert_number_of_operations(9, 12);
		}

		[TestMethod]
		public void Nothing_happens_if_there_are_no_context_entity()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic creator = Arrange_creator();
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_entity_is_already_imported()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic creator = Arrange_creator();

			ofplug.crm.AgreementRequest request = new ofplug.crm.AgreementRequest(_service, _tracingService)
			{
				Nrq_amount = new Microsoft.Xrm.Sdk.Money(100),
			};
			request.Nrq_processstatus.Select("Processed");

			Arrange_input_parameter(request);
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_context_entity_is_the_wrong_type()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Contact(_service, _tracingService) { });
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		private ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic Arrange_creator()
		{
			ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic creator = new ofplug.Logic.InitiateAgreement.Process_InitiateAgreement_automatic()
			{
			};

			creator.Set_test(_tracingService, _service, _sender, _pluginExecutionContext);

			return creator;
		}
		*/
	}
}
