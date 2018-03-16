using System;

namespace ofplug_test.LogicTest.InitiateAgreementTest
{
	public abstract class Abstract_InitiateAgreement : Abstract.AbstractTest
	{
		protected void BaseAssert(int offset)
		{
			Assert_crm_operation(0 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "nrq_bidragsaftale");//todo norriq navne
			Assert_crm_operation(1 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(2 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(3 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(4 + offset, Mock.OrganizationServiceMock.Operation.Create, "contact");
			Assert_crm_operation(5 + offset, Mock.OrganizationServiceMock.Operation.Create, "nrq_bidragsaftale");//todo norriq navne
			Assert_crm_operation(6 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(7 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "Abonnement");
			Assert_crm_operation(8 + offset, Mock.OrganizationServiceMock.Operation.RetrieveMultiple, "contact");
			Assert_crm_operation(9 + offset, Mock.OrganizationServiceMock.Operation.Create, "Abonnement");
			Assert_crm_operation(10 + offset, Mock.OrganizationServiceMock.Operation.Update, "StartAftale");
			Assert_of_operation(0, Mock.SenderMock.Operation.Post, typeof(ofplug.of.data.InitiateAgreement));
			Assert_of_operation(1, Mock.SenderMock.Operation.Get, null, typeof(ofplug.of.data.Agreement).Name.ToLower());
			Assert_of_operation(2, Mock.SenderMock.Operation.Get, null, typeof(ofplug.of.data.Contact).Name.ToLower());
			Assert_of_operation(3, Mock.SenderMock.Operation.Get, null, typeof(ofplug.of.data.Subscription).Name.ToLower());
			Assert_of_operation(4, Mock.SenderMock.Operation.Get, null, typeof(ofplug.of.data.Contact).Name.ToLower());
			Assert_of_operation(5, Mock.SenderMock.Operation.Get, null, typeof(ofplug.of.data.Contact).Name.ToLower());
			Assert_of_operation(6, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Agreement));
			Assert_of_operation(7, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Contact));
			Assert_of_operation(8, Mock.SenderMock.Operation.Patch, typeof(ofplug.of.data.Subscription));
		}

		protected void Arrange_of_data()
		{
			_sender.data_to_return.Enqueue(new ofplug.of.data.InitiateAgreementResponse()
			{
				Agreement_id = _id.Get_id("of_aftale_id"),
				Contact_id = _id.Get_id("of_contact_id"),
				Subscription_id = _id.Get_id("of_subscription_id"),
			});

			Add_of_aftale();
			Add_of_contact();
			Add_of_abonnement();
			Add_of_contact();
			Add_of_contact();

			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_aftale_id") });
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_contact_id") });
			_sender.data_to_return.Enqueue(new ofplug.of.data.IdResponse() { Id = _id.Get_id("of_subscription_id") });

			Add_of_contact();
		}

		protected void Arrange_crm_data()
		{
			Add_crm_empty(4);
			Add_crm_contact(contact => { contact.firstname = "unittest"; contact.new_ofcontactid = _id.Get_id("of_contact_id"); });
			Add_crm_empty(1);
			Add_crm_contact(contact => { contact.firstname = "unittest"; contact.new_ofcontactid = _id.Get_id("of_contact_id"); });
		}
	}
}
