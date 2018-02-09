using ofplug.Logic.Abstract;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using CrmIndbetaling = ofplug.crm.Indbetaling;
using ofplug.of.data;
using System;

namespace ofplug.Logic.Indbetaling
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[Input("Indbetaling")]
		public InArgument<int> Of_indbetaling_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_indbetaling_id = Of_indbetaling_id_InArgument.Get<int>(codeActivityContext);

			CrmIndbetaling crm_indbetaling = new CrmIndbetaling(_service);

			crm_indbetaling.Get_by_of_id(of_indbetaling_id);
			of.data.Payment of_indbetaling = _of_connection.Payment.Get(of_indbetaling_id);

			if (crm_indbetaling.CrmEntity == null)
			{
				Create_in_crm(crm_indbetaling, of_indbetaling);
			}
			else if (Needs_update_in_crm(crm_indbetaling, of_indbetaling))
			{
				Update_in_crm(crm_indbetaling, of_indbetaling);
			}
		}

		private void Update_in_crm(CrmIndbetaling crm_indbetaling, Payment of_indbetaling)
		{// todo felter
			crm_indbetaling.Id = Guid.Parse(of_indbetaling.Id.ToString());

			crm_indbetaling.Update();
		}

		private bool Needs_update_in_crm(CrmIndbetaling crm_indbetaling, Payment of_indbetaling)
		{// todo felter
			if (crm_indbetaling.Id != Guid.Parse(of_indbetaling.Id.ToString()))
			{
				return true;
			}

			return false;
		}

		private void Create_in_crm(CrmIndbetaling crm_indbetaling, Payment of_indbetaling)
		{//todo felter
			crm_indbetaling.Id = Guid.Parse(of_indbetaling.Id.ToString());

			crm_indbetaling.Create();
		}
	}
}
