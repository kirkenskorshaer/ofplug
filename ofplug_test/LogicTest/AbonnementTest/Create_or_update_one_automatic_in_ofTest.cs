using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;

namespace ofplug_test.LogicTest.AbonnementTest
{
	[TestClass]
	public class Create_or_update_one_automatic_in_ofTest : Abstract.AbstractTest
	{
		/*
		[TestMethod]
		public void Creates_an_Abonnement()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Abonnement(_service, _tracingService) { Nrq_contact = new EntityReference("contact", Guid.Empty) });
			Add_crm_config();
			Add_crm_contact();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_contact_id") });
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("abonnement id") });

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.Update, "nrq_subscription");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_of_operation(1, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Subscription));
			Assert_number_of_operations(2, 4);
		}

		[TestMethod]
		public void Nothing_happens_if_there_are_no_context_entity()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		[TestMethod]
		public void Nothing_happens_if_context_entity_is_the_wrong_type()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of creator = Arrange_creator();
			Arrange_input_parameter(new ofplug.crm.Contact(_service, _tracingService) { });
			Add_crm_config();

			creator.Execute(_serviceProvider);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_number_of_operations(0, 1);
		}

		private ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of Arrange_creator()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of creator = new ofplug.Logic.Abonnement.Create_or_update_one_automatic_in_of()
			{
			};

			creator.Set_test(_tracingService, _service, _sender, _pluginExecutionContext);

			return creator;
		}
		*/
	}
}
