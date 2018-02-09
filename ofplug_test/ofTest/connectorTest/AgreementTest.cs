using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ofplug_test.ofTest.connectorTest
{
	[TestClass]
	public class AgreementTest
	{
		[TestMethod]
		public void GetTest()
		{
			ofplug.of.Connection connection = new ofplug.of.Connection("http://of.devflowtwo.com/kirkenskorshaer/api/v2/");
			ofplug.of.data.Agreement response = connection.Agreement.Get(1702);
			//Agreement_id_get_response response = Agreement.Get("http://127.0.0.1:5000/echo/", 1702);

			Console.Out.WriteLine(response.Amount);
		}
	}
}
