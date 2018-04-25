using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ofplug_test.ofTest.connectorTest
{
	[TestClass]
	public class ContactTest : Abstract.AbstractTest
	{
		[TestMethod]
		[Ignore]
		public void Contact_can_change_name()
		{
			ofplug.of.Connection connection = new ofplug.of.Connection("http://of.devflowtwo.com/kirkenskorshaer/api/v2/", "");
			ofplug.of.data.Contact of_contact = connection.Contact.Get(1703);

			string first_name_before = of_contact.First_name;
			string unmodified_first_name = of_contact.First_name;
			string modified_first_name = of_contact.First_name + "_test";

			of_contact = To_crm_and_back(of_contact, crm_contact => crm_contact.firstname = modified_first_name);

			connection.Contact.Patch(of_contact.Of_id.Value, of_contact);
			of_contact = connection.Contact.Get(of_contact.Of_id.Value);

			string first_name_After = of_contact.First_name;

			of_contact = To_crm_and_back(of_contact, crm_contact => crm_contact.firstname = unmodified_first_name);
			connection.Contact.Patch(of_contact.Of_id.Value, of_contact);

			Assert.AreEqual(modified_first_name, first_name_After);
		}

		private ofplug.of.data.Contact To_crm_and_back(ofplug.of.data.Contact of_contact, Action<ofplug.crm.Contact> modify_while_crm)
		{
			ofplug.crm.Contact crm_contact = new ofplug.crm.Contact(_service, _tracingService);
			ofplug.Mapping.Contact.To_crm(crm_contact, of_contact, _tracingService);

			modify_while_crm(crm_contact);

			ofplug.of.data.Contact new_of_contact = new ofplug.of.data.Contact();
			ofplug.Mapping.Contact.To_of(crm_contact, new_of_contact);

			return new_of_contact;
		}
	}
}
