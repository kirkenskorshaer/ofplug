using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug.Aftale;
using ofplug_test.Abstract;
using Microsoft.Xrm.Sdk;

namespace ofplug_test.AftaleTest
{
	[TestClass]
	public class Create_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Create_in_crm_Creates_an_aftale()
		{
			Create_in_crm create = new Create_in_crm()
			{
				IsTest = true
			};
			create.SetTest(_tracingService, _organizationService);

			create.ExecuteInTest(null);

			Assert.AreEqual("nrq_bidragsaftale", ((Entity)_organizationService.Log[0].Value).LogicalName);
		}
	}
}
