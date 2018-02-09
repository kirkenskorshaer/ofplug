using ofplug.Logic.Abstract;
using System;
using System.Activities;
using CrmAftale = ofplug.crm.Aftale;
using CrmIndbetaling = ofplug.crm.Indbetaling;
using ofplug.of.data;

namespace ofplug.Logic.Indbetaling
{
	public class Create_or_update_all_in_crm : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			foreach (int id in _of_connection.Get_payments(_config.Payment_step))
			{
				of.data.Payment of_payment = _of_connection.Payment.Get(id);

				CrmAftale crm_aftale = new CrmAftale(_service);
				crm_aftale.Get_by_of_id(id);

				if (crm_aftale.CrmEntity == null)
				{
					continue;
				}

				CrmIndbetaling crm_indbetaling = new CrmIndbetaling(_service);
				crm_indbetaling.Get_by_of_id(id);

				if (crm_indbetaling.CrmEntity == null)
				{
					Create_in_crm(crm_indbetaling, of_payment);
				}
				else if (Needs_update_in_crm(crm_indbetaling, of_payment))
				{
					Update_in_crm(crm_indbetaling, of_payment);
				}

				//todo remove
				break;
			}
		}

		private void Update_in_crm(CrmIndbetaling crm_indbetaling, Payment of_payment)
		{//todo felter
			crm_indbetaling.Id = Guid.Parse(of_payment.Id.ToString());

			crm_indbetaling.Update();
		}

		private bool Needs_update_in_crm(CrmIndbetaling crm_indbetaling, Payment of_payment)
		{//todo felter
			if (crm_indbetaling.Id != Guid.Parse(of_payment.Id.ToString()))
			{
				return true;
			}

			return false;
		}

		private void Create_in_crm(CrmIndbetaling crm_indbetaling, Payment of_payment)
		{//todo felter
			crm_indbetaling.Id = Guid.Parse(of_payment.Id.ToString());

			crm_indbetaling.Create();
		}
	}
}
