using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
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
			try
			{
				Initialize(codeActivityContext);

				EntityReference startAftaleEntityReference = StartAftaleEntityReference.Get<EntityReference>(codeActivityContext);

				crm.AgreementRequest crm_start_aftale = new crm.AgreementRequest(_service, _tracingService);
				crm_start_aftale.Get_by_reference(startAftaleEntityReference);

				Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
				maintain.Process_InitiateAgreement(crm_start_aftale);
			}
			catch(Exception exception)
			{
				Write_exception(exception);
			}
		}
	}
}
