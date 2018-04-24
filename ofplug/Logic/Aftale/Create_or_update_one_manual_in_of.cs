using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using System;
using System.Activities;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_one_manual_in_of : AbstractCodeActivity
	{
		[ReferenceTarget("nrq_bidragsaftale")]
		[RequiredArgument]
		[Input("Aftale")]
		public InArgument<EntityReference> AftaleEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			try
			{
				Initialize(codeActivityContext);

				EntityReference aftaleEntityReference = AftaleEntityReference.Get<EntityReference>(codeActivityContext);

				crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);
				crm_aftale.Get_by_reference(aftaleEntityReference);

				Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
				maintain.Create_or_update_one_in_of(crm_aftale);
			}
			catch (Exception exception)
			{
				Write_exception(exception);
			}
		}
	}
}

