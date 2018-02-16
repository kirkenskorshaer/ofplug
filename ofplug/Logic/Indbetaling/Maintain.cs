using Microsoft.Xrm.Sdk;
using ofplug.crm;
using ofplug.of;

namespace ofplug.Logic.Indbetaling
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, Config config, Connection of_connection) : base(service, config, of_connection)
		{
		}

		public void Create_or_update_all_indbetaling_in_crm()
		{
			foreach (int id in _of_connection.Get_payments(_config.Payment_step))
			{
				of.data.Payment of_payment = _of_connection.Payment.Get(id);

				crm.Aftale crm_aftale = new crm.Aftale(_service);
				crm_aftale.Get_by_of_id(id);

				if (crm_aftale.CrmEntity == null)
				{
					continue;
				}

				crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service);
				crm_indbetaling.Get_by_of_id(id);

				if (crm_indbetaling.CrmEntity == null)
				{
					Create_in_crm(crm_indbetaling, of_payment);
				}
				else if (Mapping.Indbetaling.Needs_update_in_crm(crm_indbetaling, of_payment))
				{
					Update_in_crm(crm_indbetaling, of_payment);
				}

				//todo remove
				break;
			}
		}

		public void Create_or_update_one_indbetaling_in_crm(int of_indbetaling_id, of.data.Payment of_indbetaling)
		{
			crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service);

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

		private void Create_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			Mapping.Indbetaling.To_crm(crm_indbetaling, of_payment);

			crm_indbetaling.Create();
		}
	}
}
