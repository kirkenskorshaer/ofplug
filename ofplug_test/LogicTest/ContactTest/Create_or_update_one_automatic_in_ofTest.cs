using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Create_or_update_one_automatic_in_ofTest : Abstract.AbstractTest
	{
		/*
		[TestMethod]
		public void Creates_a_contact()
		{
			ofplug.Logic.Contact.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Contact(_service, _tracingService) { });
			Add_crm_config();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("contact id") });

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_number_of_operations(1, 2);
		}

		[TestMethod]
		public void Nothing_happens_if_there_are_no_context_entity()
		{
			ofplug.Logic.Contact.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_context_entity_is_the_wrong_type()
		{
			ofplug.Logic.Contact.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Aftale(_service, _tracingService) { nrq_beloeb = new Money(100), nrq_bidragyder = new EntityReference("contact", Guid.Empty) });
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		private ofplug.Logic.Contact.Create_or_update_one_automatic_in_of Arrange_creator()
		{
			ofplug.Logic.Contact.Create_or_update_one_automatic_in_of creator = new ofplug.Logic.Contact.Create_or_update_one_automatic_in_of()
			{
			};

			creator.Set_test(_tracingService, _service, _sender, _pluginExecutionContext);

			return creator;
		}
		*/
	}
}
