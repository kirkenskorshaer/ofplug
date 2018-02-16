using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.Contact
{
	public class Create_or_update_one_manual_in_of : AbstractCodeActivity
	{
		[ReferenceTarget("contact")]
		[RequiredArgument]
		[Input("Contact")]
		public InArgument<EntityReference> ContactEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			EntityReference aftaleEntityReference = ContactEntityReference.Get<EntityReference>(codeActivityContext);

			crm.Contact crm_contact = new crm.Contact(_service);
			crm_contact.Get_by_reference(aftaleEntityReference);

			Maintain maintain = new Maintain(_service, _config, _of_connection);
			maintain.Create_or_update_one_in_of(crm_contact);
		}
	}
}
