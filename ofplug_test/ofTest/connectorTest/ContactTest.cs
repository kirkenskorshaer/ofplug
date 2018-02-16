using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ofplug_test.ofTest.connectorTest
{
	[TestClass]
	public class ContactTest
	{
		[TestMethod]
		public void Contact_can_change_birthday()
		{
			ofplug.of.Connection connection = new ofplug.of.Connection("http://of.devflowtwo.com/kirkenskorshaer/api/v2/");
			ofplug.of.data.Contact contact = connection.Contact.Get(1703);

			DateTime? birthBefore = contact.Birthday_stamp_value;
			contact.Valid_adr_ts_value = contact.Birthday_stamp_value.Value.AddDays(1);

			connection.Contact.Patch(contact.Id.Value, contact);
			contact = connection.Contact.Get(1703);

			DateTime? birthAfter = contact.Birthday_stamp_value;

			contact.Valid_adr_ts_value = contact.Birthday_stamp_value.Value.AddDays(-1);
			connection.Contact.Patch(contact.Id.Value, contact);

			Assert.AreEqual(birthBefore.Value.AddDays(-1), birthAfter);
		}
	}
}
