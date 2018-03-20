using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ofplug_test.LogicTest.AbonnementTest
{
	[TestClass]
	public class MaintaintTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Create_or_update_one_abonnement_in_of_will_do_nothing_if_a_fully_updated_subscription_exists()
		{
			Add_of_abonnement(of_abonnement => of_abonnement.Crm_id = Guid.Empty.ToString().ToLower());
			ofplug.Logic.Abonnement.Maintain maintain = Arrange_maintain();
			ofplug.crm.Abonnement crm_abonnoment = new ofplug.crm.Abonnement(_service, _tracingService)
			{
				Nrq_of_subscription_id = _id.Get_id("of_subscription_id"),
				Id = Guid.Empty,
				Nrq_of_contact_id = _id.Get_id("of_contact_id"),
			};

			maintain.Create_or_update_one_abonnement_in_of(crm_abonnoment);

			Assert_no_writes();
		}

		[TestMethod]
		public void Create_or_update_one_abonnement_in_of_can_patch_a_subscription()
		{
			Add_of_abonnement(of_abonnement => of_abonnement.Crm_id = Guid.Empty.ToString().ToLower());
			ofplug.Logic.Abonnement.Maintain maintain = Arrange_maintain();
			_sender.data_to_return.Enqueue(new List<int> { _id.Get_id("abonnement_id") });
			ofplug.crm.Abonnement crm_abonnoment = new ofplug.crm.Abonnement(_service, _tracingService)
			{
				Nrq_of_subscription_id = _id.Get_id("of_subscription_id"),
				Id = Guid.Empty,
			};

			maintain.Create_or_update_one_abonnement_in_of(crm_abonnoment);

			Assert.IsTrue(_sender.Log.Single(log =>
				log.Operation == Mock.SenderMock.Operation.Patch).Request.GetType() == typeof(ofplug.of.data.Subscription));
		}

		private ofplug.Logic.Abonnement.Maintain Arrange_maintain()
		{
			ofplug.of.Connection of_connection = Arrange_of_connection();
			ofplug.crm.Config config = new ofplug.crm.Config(_service, _tracingService, false) { Nrq_of_token = "", Nrq_of_url = "" };
			ofplug.Logic.Abonnement.Maintain maintain = new ofplug.Logic.Abonnement.Maintain(_service, _tracingService, config, of_connection);
			return maintain;
		}
	}
}
