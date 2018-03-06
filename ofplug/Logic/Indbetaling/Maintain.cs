using Microsoft.Xrm.Sdk;
using ofplug.crm;
using ofplug.of;

namespace ofplug.Logic.Indbetaling
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, Config config, Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Create_or_update_all_indbetaling_in_crm()
		{
			foreach (int id in _of_connection.Get_payments())
			{
				of.data.Payment of_indbetaling = _of_connection.Payment.Get(id);

				Create_or_update_one_indbetaling_in_crm(of_indbetaling.Of_id.Value, of_indbetaling);

				//todo remove
				break;
			}
		}

		public void Create_or_update_one_indbetaling_in_crm(int of_indbetaling_id, of.data.Payment of_indbetaling)
		{
			crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service, _tracingService);

			crm_indbetaling.Get_by_of_id(of_indbetaling_id);

			if (crm_indbetaling.CrmEntity == null)
			{
				Create_in_crm(crm_indbetaling, of_indbetaling);
			}
			else if (Mapping.Indbetaling.Needs_update_in_crm(crm_indbetaling, of_indbetaling))
			{
				Update_in_crm(crm_indbetaling, of_indbetaling);
			}
		}

		private void Update_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			Mapping.Indbetaling.To_crm(crm_indbetaling, of_payment);

			crm_indbetaling.Update();
		}

		private void Create_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_indbetaling)
		{
			Mapping.Indbetaling.To_crm(crm_indbetaling, of_indbetaling);

			if (of_indbetaling.Agreement_id.HasValue)
			{
				of.data.Agreement of_aftale = _of_connection.Agreement.Get(of_indbetaling.Agreement_id.Value);

				Create_or_update_one_aftale_in_crm(of_aftale);
			}

			if (of_indbetaling.Contact_id.HasValue)
			{
				of.data.Contact of_contact = _of_connection.Contact.Get(of_indbetaling.Contact_id.Value);

				Create_or_update_one_contact_in_crm(of_indbetaling.Contact_id, of_contact);
			}

			crm_indbetaling.Create();
		}
	}
}
