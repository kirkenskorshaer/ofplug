using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug.of.connector;
using System.Linq;
using System;
using ofplug_test.Mock;
using System.Collections.Generic;

namespace ofplug_test.ofTest.connectorTest
{
	[TestClass]
	public class AgreementsTest
	{
		[TestMethod]
		public void Agreements_can_get_data()
		{
			SenderMock sender = Arrange_sender();
			Agreements agreements = new Agreements("http://of.devflowtwo.com/kirkenskorshaer/api/v2/", 50, sender);

			Assert.IsTrue(agreements.Any());
		}

		private SenderMock Arrange_sender()
		{
			SenderMock sender = new SenderMock();

			sender.data_to_return.Enqueue(new List<int> { 1 });

			return sender;
		}
	}
}
