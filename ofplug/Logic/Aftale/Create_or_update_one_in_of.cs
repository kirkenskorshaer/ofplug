using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using System.Activities;
using CrmAftale = ofplug.crm.Aftale;
using CrmConfig = ofplug.crm.Config;
using OfAgreement = ofplug.of.data.Agreement;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_one_in_of : AbstractCodeActivity
	{
		[Input("Aftale")]
		public InArgument<EntityReference> AftaleEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			EntityReference aftaleEntityReference = AftaleEntityReference.Get<EntityReference>(codeActivityContext);

			CrmAftale crm_aftale = new CrmAftale(_service);
			crm_aftale.Get_by_reference(aftaleEntityReference);

			CrmConfig config = new CrmConfig(_service);

			OfAgreement of_aftale = null;

			if (crm_aftale.of_id != 0)
			{
				of_aftale = _of_connection.Agreement.Get(crm_aftale.of_id);
			}

			if (of_aftale == null)
			{
				Create_of_aftale(config, crm_aftale);
			}
			else if (Needs_update_at_of(config, crm_aftale, of_aftale))
			{
				Update_of_aftale(crm_aftale, of_aftale);
			}
		}

		private void Update_of_aftale(CrmAftale crm_aftale, OfAgreement of_aftale)
		{//todo felter
			of_aftale.Amount = crm_aftale.nrq_beloeb;
		}

		private bool Needs_update_at_of(CrmConfig config, CrmAftale crm_aftale, OfAgreement of_aftale)
		{//todo felter
			if (crm_aftale.nrq_beloeb != of_aftale.Amount)
			{
				return true;
			}

			return false;
		}

		private void Update_of_aftale(CrmConfig config, CrmAftale crm_aftale, OfAgreement of_aftale)
		{//todo felter
			of_aftale.Amount = crm_aftale.nrq_beloeb;

			_of_connection.Agreement.Patch(crm_aftale.of_id, of_aftale);
		}

		private void Create_of_aftale(CrmConfig config, CrmAftale crm_aftale)
		{//todo felter
			OfAgreement of_aftale = new OfAgreement()
			{
				Amount = crm_aftale.nrq_beloeb
			};

			_of_connection.Agreement.Post(of_aftale);
		}
	}
}

