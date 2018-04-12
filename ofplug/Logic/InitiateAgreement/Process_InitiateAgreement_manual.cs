using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace ofplug.Logic.InitiateAgreement
{
	public class Process_InitiateAgreement_manual : Abstract.AbstractCodeActivity
	{
		[ReferenceTarget("nrq_agreement_request")]
		[RequiredArgument]
		[Input("Betalingsaftaleanmodning")]
		public InArgument<EntityReference> StartAftaleEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			EntityReference startAftaleEntityReference = StartAftaleEntityReference.Get<EntityReference>(codeActivityContext);

			crm.StartAftale crm_start_aftale = new crm.StartAftale(_service, _tracingService);
			crm_start_aftale.Get_by_reference(startAftaleEntityReference);

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Process_InitiateAgreement(crm_start_aftale);
		}
	}
}
