using System.Activities;

namespace ofplug.Logic.Abonnement
{
	public class Create_or_update_all_in_crm : Abstract.AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Update_subscriptions_in_crm();
		}
	}
}
