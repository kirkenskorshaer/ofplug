using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ofplug_test.LogicTest.AftaleTest
{
	[TestClass]
	public class MaintainTest : Abstract.AbstractTest
	{
		[TestMethod]
		public void Update_of_aftale()
		{
			Add_of_abonnement(of_abonnement => of_abonnement.Crm_id = Guid.Empty.ToString().ToLower());
			ofplug.Logic.Aftale.Maintain maintain = Arrange_maintain();

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

		private ofplug.Logic.Aftale.Maintain Arrange_maintain()
		{
			ofplug.of.Connection of_connection = Arrange_of_connection();
			ofplug.crm.Config config = new ofplug.crm.Config(_service, _tracingService, false) { Nrq_of_token = "", Nrq_of_url = "" };
			ofplug.Logic.Aftale.Maintain maintain = new ofplug.Logic.Aftale.Maintain(_service, _tracingService, config, of_connection);
			return maintain;
		}
	}
}
