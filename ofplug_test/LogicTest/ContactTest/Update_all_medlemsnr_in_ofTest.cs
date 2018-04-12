using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Update_all_medlemsnr_in_ofTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Medlemsnr_will_be_updated()
		{
			ofplug.Logic.Contact.Update_all_medlemsnr_in_of creator = Arrange_creator();
			_sender.data_to_return.Enqueue(new List<int>() { _id.Get_id("contact_id_1") });
			Add_crm_config();
			Add_of_contact();
			Add_of_empty();
			Add_crm_contact(contact =>
			{
				contact.nrq_of_id = _id.Get_id("contact_id_1");
				contact.new_kkadminmedlemsnr = _id.Get_id("medlemsnr");
			});

			WorkflowInvoker.Invoke(creator);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(2, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Contact));
			Assert_number_of_operations(3, 2);
		}

		[TestMethod]
		public void Medlemsnr_will_not_be_updated_if_it_is_already_up_to_date()
		{
			ofplug.Logic.Contact.Update_all_medlemsnr_in_of creator = Arrange_creator();
			_sender.data_to_return.Enqueue(new List<int>() { _id.Get_id("contact_id_1") });
			Add_crm_config();
			Add_of_contact(of_contact => of_contact.External_id = _id.Get_id("medlemsnr").ToString());
			Add_of_empty();
			Add_crm_contact(contact =>
			{
				contact.nrq_of_id = _id.Get_id("contact_id_1");
				contact.new_kkadminmedlemsnr = _id.Get_id("medlemsnr");
			});

			WorkflowInvoker.Invoke(creator);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(2, 2);
		}

		[TestMethod]
		public void If_no_crm_contact_can_be_found_nothing_happens()
		{
			ofplug.Logic.Contact.Update_all_medlemsnr_in_of creator = Arrange_creator();
			_sender.data_to_return.Enqueue(new List<int>() { _id.Get_id("contact_id_1") });
			Add_crm_config();
			Add_of_contact();
			_sender.data_to_return.Enqueue(new List<int>() { });
			Add_crm_empty();

			WorkflowInvoker.Invoke(creator);

			Assert_crm_operation(0, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_configuration");
			Assert_crm_operation(1, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_of_operation(0, Mock.SenderMock.Operation.Get, null);
			Assert_number_of_operations(3, 2);
		}

		private ofplug.Logic.Contact.Update_all_medlemsnr_in_of Arrange_creator()
		{
			ofplug.Logic.Contact.Update_all_medlemsnr_in_of creator = new ofplug.Logic.Contact.Update_all_medlemsnr_in_of()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
