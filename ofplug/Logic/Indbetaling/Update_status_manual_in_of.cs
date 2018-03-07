using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace ofplug.Logic.Indbetaling
{
	public class Update_status_manual_in_of : Abstract.AbstractCodeActivity
	{
		[ReferenceTarget("new_indbetaling")]
		[RequiredArgument]
		[Input("new_indbetaling")]
		public InArgument<EntityReference> IndbetalingEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			EntityReference aftaleEntityReference = IndbetalingEntityReference.Get<EntityReference>(codeActivityContext);

			crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service, _tracingService);
			crm_indbetaling.Get_by_reference(aftaleEntityReference);

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Update_status_in_of(crm_indbetaling);
		}
	}
}
