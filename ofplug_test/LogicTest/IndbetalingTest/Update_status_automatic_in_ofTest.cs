using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Update_status_automatically_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Updates_status()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Indbetaling(_service, _tracingService) { of_indbetaling_id = _id.Get_id("indbetaling id") });
			Add_crm_config();
			Add_of_indbetaling(of_indbetaling => of_indbetaling.State = "not updated");
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("indbetaling id") });

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Payment));
			Assert_number_of_operations(2, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_there_are_no_context_entity()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = Arrange_creator();
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_context_entity_is_the_wrong_type()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Aftale(_service, _tracingService) { nrq_beloeb = new Money(100), nrq_bidragyder = new EntityReference("contact", Guid.Empty) });
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_indbetaling_has_no_of_id()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Indbetaling(_service, _tracingService) { of_indbetaling_id = null });
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void If_status_is_already_updated_no_new_status_will_be_set()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Indbetaling(_service, _tracingService) { of_indbetaling_id = _id.Get_id("indbetaling id"), nrq_tekst = "updated" });//todo forkert felt
			Add_crm_config();
			Add_of_indbetaling(of_indbetaling => of_indbetaling.State = "updated");

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(1, 1);
		}

		private ofplug.Logic.Indbetaling.Update_status_automatic_in_of Arrange_creator()
		{
			ofplug.Logic.Indbetaling.Update_status_automatic_in_of creator = new ofplug.Logic.Indbetaling.Update_status_automatic_in_of()
			{
			};

			creator.Set_test(_tracingService, _service, _sender, _pluginExecutionContext);

			return creator;
		}
	}
}
