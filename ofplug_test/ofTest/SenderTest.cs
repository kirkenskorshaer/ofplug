using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug.of;
using ofplug_test.ofTest.dataTest;
using System;

namespace ofplug_test.ofTest
{
	[TestClass]
	public class SenderTest
	{
		private string url = "http://127.0.0.1:5000/echo";

		[TestMethod]
		public void Get()
		{
			Sender sender = new Sender();

			Hello_world hello_world = sender.Get<Hello_world>(url);

			Assert.AreEqual(1, hello_world.Response);
		}

		[DataTestMethod]
		[DataRow("post")]
		[DataRow("put")]
		[DataRow("patch")]
		[DataRow("delete")]
		public void Call_with_data_returned(string methodName)
		{
			Sender sender = new Sender();
			Simple_data data_to_send = new Simple_data()
			{
				StringField = "qwerty"
			};

			Func<string, Simple_data, Simple_data> method = getWebMethod(methodName, sender);
			Simple_data data_received = method(url, data_to_send);

			Assert.AreEqual(data_to_send.ToString(), data_received.ToString());
		}

		private Func<string, Simple_data, Simple_data> getWebMethod(string name, Sender sender)
		{
			switch (name)
			{
				case "post":
					return sender.Post<Simple_data, Simple_data>;
				case "put":
					return sender.Post<Simple_data, Simple_data>;
				case "patch":
					return sender.Post<Simple_data, Simple_data>;
				case "delete":
					return sender.Post<Simple_data, Simple_data>;
				default:
					break;
			}

			throw new ArgumentException("no method named: " + name);
		}
	}
}
