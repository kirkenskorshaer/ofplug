using ofplug.Logic.Abstract;
using System.Activities;

namespace ofplug.Logic.Indbetaling
{
	public class Create_or_update_all_in_crm : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_all_indbetaling_in_crm();
		}
	}
}
