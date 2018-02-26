using ofplug.Logic.Abstract;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;

namespace ofplug.Logic.Contact
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[RequiredArgument]
		[Input("Of_contact_id")]
		public InArgument<int> Of_contact_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_contact_id = Of_contact_id_InArgument.Get<int>(codeActivityContext);

			of.data.Contact of_contact = _of_connection.Contact.Get(of_contact_id);

			if (of_contact == null)
			{
				return;
			}

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_one_contact_in_crm(of_contact_id, of_contact);
		}
	}
}
