using ofplug.Logic.Abstract;
using System.Activities;

namespace ofplug.Logic.Contact
{
	public class Update_all_medlemsnr_in_of : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			Maintain maintain = new Maintain(_service, _config, _of_connection);
			maintain.Update_all_medlemsnr_in_of();
		}
	}
}
