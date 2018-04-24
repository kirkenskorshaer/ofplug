using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace ofplug.Logic.Abonnement
{
	public class Create_or_update_one_manuel_in_of : Abstract.AbstractCodeActivity
	{
		[ReferenceTarget("nrq_subscription")]
		[RequiredArgument]
		[Input("Abonnement")]
		public InArgument<EntityReference> AbonnementEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			try
			{
				Initialize(codeActivityContext);

				EntityReference abonnementEntityReference = AbonnementEntityReference.Get<EntityReference>(codeActivityContext);

				crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService);
				crm_abonnement.Get_by_reference(abonnementEntityReference);

				Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
				maintain.Create_or_update_one_abonnement_in_of(crm_abonnement);
			}
			catch (Exception exception)
			{
				Write_exception(exception);
			}
		}
	}
}
