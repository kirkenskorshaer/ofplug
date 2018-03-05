using ofplug.Logic.Abstract;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;

namespace ofplug.Logic.Indbetaling
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[ReferenceTarget("new_indbetaling")]
		[RequiredArgument]
		[Input("Indbetaling")]
		public InArgument<int> Of_indbetaling_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_indbetaling_id = Of_indbetaling_id_InArgument.Get<int>(codeActivityContext);
			of.data.Payment of_indbetaling = _of_connection.Payment.Get(of_indbetaling_id);

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_one_indbetaling_in_crm(of_indbetaling_id, of_indbetaling);
		}
	}
}
