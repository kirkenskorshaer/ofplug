using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug.Logic.Aftale;
using ofplug_test.Abstract;
using Microsoft.Xrm.Sdk;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class Create_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Create_in_crm_Creates_an_aftale()
		{
			AddConfig();
			AddEmpty();

			Create_or_update_all_in_crm create = new Create_or_update_all_in_crm()
			{
				IsTest = true
			};
			create.Set_test(_tracingService, _service);

			create.Execute_in_test(null);

			Assert.AreEqual("nrq_bidragsaftale", ((Entity)_service.Log[0].Value).LogicalName);
		}
	}
}
