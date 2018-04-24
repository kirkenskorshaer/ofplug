using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace ofplug.Logic.Abonnement
{
	public class Create_or_update_one_in_crm : Abstract.AbstractCodeActivity
	{
		[RequiredArgument]
		[Input("Abonnement")]
		public InArgument<int> Of_abonnement_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			try
			{
				Initialize(codeActivityContext);

				int of_aftale_id = Of_abonnement_id_InArgument.Get<int>(codeActivityContext);
				of.data.Subscription of_abonnement = _of_connection.Subscription.Get(of_aftale_id);

				_tracingService.Trace($"of_id: {of_aftale_id}");

				if (of_abonnement == null)
				{
					return;
				}

				Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
				maintain.Create_or_update_one_abonnement_in_crm(of_abonnement);
			}
			catch (Exception exception)
			{
				Write_exception(exception);
			}
		}
	}
}
