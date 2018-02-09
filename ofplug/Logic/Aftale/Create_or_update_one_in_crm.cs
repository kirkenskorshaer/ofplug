using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using System.Activities;
using CrmAftale = ofplug.crm.Aftale;
using CrmContact = ofplug.crm.Contact;
using OfAgreement = ofplug.of.data.Agreement;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[Input("Aftale")]
		public InArgument<int> Of_aftale_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_aftale_id = Of_aftale_id_InArgument.Get<int>(codeActivityContext);

			OfAgreement of_aftale = _of_connection.Agreement.Get(of_aftale_id);

			if (of_aftale == null)
			{
				return;
			}

			CrmAftale crm_aftale = new CrmAftale(_service);
			crm_aftale.Get_entity_by_of_id(_service, of_aftale_id);

			if (crm_aftale.CrmEntity == null)
			{
				Create_in_crm(crm_aftale, of_aftale);
			}
			else if (Needs_update_in_crm(crm_aftale, of_aftale))
			{
				Update_in_crm(crm_aftale, of_aftale);
			}
			//List<CrmAftale> aftaler = CrmAftale.GetAll(_service);
		}

		private void Update_in_crm(CrmAftale crm_aftale, OfAgreement of_aftale)
		{
			//todo felter
			crm_aftale.nrq_beloeb = of_aftale.Amount;

			crm_aftale.Update();
		}

		private bool Needs_update_in_crm(CrmAftale crm_aftale, OfAgreement of_aftale)
		{
			//todo felter
			if (crm_aftale.nrq_beloeb != of_aftale.Amount)
			{
				return true;
			}

			return false;
		}

		private void Create_in_crm(CrmAftale crm_aftale, OfAgreement of_aftale)
		{
			crm_aftale.nrq_beloeb = of_aftale.Amount;
			//todo felter

			CrmContact crm_contact = new CrmContact(_service);
			Get_or_create_contact(of_aftale.Contact_id);

			crm_aftale.Create(crm_contact);
		}
	}
}
