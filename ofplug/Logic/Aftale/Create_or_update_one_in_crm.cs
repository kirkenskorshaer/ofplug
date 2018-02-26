using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using System.Activities;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[ReferenceTarget("contact")]
		[RequiredArgument]
		[Input("Aftale")]
		public InArgument<int> Of_aftale_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_aftale_id = Of_aftale_id_InArgument.Get<int>(codeActivityContext);

			of.data.Agreement of_aftale = _of_connection.Agreement.Get(of_aftale_id);

			if (of_aftale == null)
			{
				return;
			}

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_one_aftale_in_crm(of_aftale);
		}
	}
}
