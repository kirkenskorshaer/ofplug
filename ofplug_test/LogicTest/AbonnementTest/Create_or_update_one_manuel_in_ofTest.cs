using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.AbonnementTest
{
	[TestClass]
	public class Create_or_update_one_manuel_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Creates_an_Abonnement()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_manuel_in_of creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_crm_config();
			Add_crm_abonnement(abonnement => abonnement.Nrq_contact = new EntityReference("contact", Guid.Empty));
			Add_crm_contact();
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_contact_id") });
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("abonnement id") });

			WorkflowInvoker.Invoke(creator, input);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.Retrieve, "Abonnement");//todo norriq navn på Abonnement
			Assert_crm_operation(2, Mock.OrganizationServiceMock.Operation.Retrieve, "contact");
			Assert_crm_operation(3, Mock.OrganizationServiceMock.Operation.Update, "contact");
			Assert_crm_operation(4, Mock.OrganizationServiceMock.Operation.Update, "Abonnement");//todo norriq navn på Abonnement
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Contact));
			Assert_of_operation(1, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.Subscription));
			Assert_number_of_operations(2, 5);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "AbonnementEntityReference", new EntityReference("Abonnement", Guid.NewGuid()) },//todo norriq name
			};

			return input;
		}

		private ofplug.Logic.Abonnement.Create_or_update_one_manuel_in_of Arrange_creator()
		{
			ofplug.Logic.Abonnement.Create_or_update_one_manuel_in_of creator = new ofplug.Logic.Abonnement.Create_or_update_one_manuel_in_of()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
