using Microsoft.VisualStudio.TestTools.UnitTesting;
using ofplug_test.Abstract;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Activities;
using System;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class Create_or_update_one_in_crmTest : AbstractTest
	{
		[TestMethod]
		public void Creates_an_aftale()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_empty(4);

			WorkflowInvoker.Invoke(creator, input);

			Assert.AreEqual("contact", ((Entity)_service.Log[0].Value).LogicalName);
			Assert.AreEqual("nrq_bidragsaftale", ((Entity)_service.Log[1].Value).LogicalName);
		}

		[TestMethod]
		public void Associates_a_Contact()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = Arrange_creator();
			Dictionary<string, object> input = Arrange_input();
			Add_aftale();
			Add_contact();

			WorkflowInvoker.Invoke(creator, input);

			KeyValuePair<string, object> result = _service.Log[1];
			Assert.AreEqual("associate", result.Key);
		}

		private void Add_contact()
		{
			Entity entity = new Entity("contact");
			_service.entitiesToReturn.Enqueue(new List<Entity> { entity });
		}

		private Dictionary<string, object> Arrange_input()
		{
			Dictionary<string, object> input = new Dictionary<string, object>
			{
				{ "Of_aftale_id_InArgument", 1744 },
			};

			return input;
		}

		private ofplug.Logic.Aftale.Create_or_update_one_in_crm Arrange_creator()
		{
			ofplug.Logic.Aftale.Create_or_update_one_in_crm creator = new ofplug.Logic.Aftale.Create_or_update_one_in_crm()
			{
				IsTest = true
			};

			creator.Set_test(_tracingService, _service, _sender);

			return creator;
		}
	}
}
