using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug.of.connector;
using System.Linq;

namespace ofplug_test.ofTest.connectorTest
{
	[TestClass]
	public class AgreementsTest
	{
		[TestMethod]
		public void Agreements_can_get_data()
		{
			Agreements agreements = new Agreements("http://of.devflowtwo.com/kirkenskorshaer/api/v2/", 50);

			Assert.IsTrue(agreements.Any());
		}
	}
}
