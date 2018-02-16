using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using ofplug_test.Abstract;
using System.Activities;
using System.Collections.Generic;

namespace ofplug_test.LogicTest.ContactTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Contact_can_be_created()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_empty();

			WorkflowInvoker.Invoke(creator, input);

			Assert.AreEqual("contact", ((Entity)_service.Log[0].Value).LogicalName);
		}

		[TestMethod]
		public void Contact_can_be_updated()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_contact(new ofplug.crm.Contact(_service) { firstname = "tsts_frst_nm" });

			WorkflowInvoker.Invoke(creator, input);

			Assert.AreEqual("contact", ((Entity)_service.Log[0].Value).LogicalName);
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_contact_id_InArgument", 1703 },
			};

			return input;
		}

		private ofplug.Logic.Contact.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Contact.Create_or_update_one_in_crm creator = new ofplug.Logic.Contact.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service);

			return creator;
		}
	}
}
