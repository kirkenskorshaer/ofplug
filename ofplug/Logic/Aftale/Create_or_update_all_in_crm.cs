using System.Activities;
using ofplug.Logic.Abstract;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_all_in_crm : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			Update_agreements_in_crm_from_of_data();
		}

		private void Update_agreements_in_crm_from_of_data()
		{
			of.connector.Agreements agreements = new of.connector.Agreements(_config.Url, _config.Aggrement_step);
			foreach (int id in agreements)
			{
				crm.Aftale crm_aftale = new crm.Aftale(_service);
				crm_aftale.Get_entity_by_of_id(_service, id);
				of.data.Agreement of_agreement = _of_connection.Agreement.Get(id);

				if (crm_aftale.CrmEntity == null)
				{
					Create_crm_aftale(of_agreement);
				}
				else if (Needs_update_in_crm(crm_aftale, of_agreement))
				{
					crm_aftale.Update();
				}
				//todo remove
				break;
			}
		}

		public bool Needs_update_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{//todo felter
			if (crm_aftale.nrq_beloeb != of_aftale.Amount)
			{
				return true;
			}

			return false;
		}

		private void Create_crm_aftale(of.data.Agreement of_agreement)
		{
			crm.Aftale aftale = new crm.Aftale(_service)
			{
				//todo felter
			};

			crm.Contact contact = Get_or_create_contact(of_agreement.Contact_id);

			aftale.Create(contact);
		}
	}
}
