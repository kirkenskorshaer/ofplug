using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using ofplug.Logic.Abstract;
using Microsoft.Xrm.Sdk;
using CrmContact = ofplug.crm.Contact;
using OfContact = ofplug.of.data.Contact;

namespace ofplug.Logic.Contact
{
	public class Create_or_update_one_in_of : AbstractCodeActivity
	{
		[Input("Contact")]
		public InArgument<EntityReference> ContactEntityReference { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			EntityReference aftaleEntityReference = ContactEntityReference.Get<EntityReference>(codeActivityContext);

			CrmContact crm_contact = new CrmContact(_service);
			crm_contact.Get_by_reference(aftaleEntityReference);

			OfContact of_contact = null;

			if (crm_contact.of_id != 0)
			{
				of_contact = _of_connection.Contact.Get(crm_contact.of_id);
			}

			if (of_contact == null)
			{
				Create_of_contact(crm_contact);
			}
			else if (Needs_update_at_of(crm_contact, of_contact))
			{
				Update_of_aftale(crm_contact, of_contact);
			}
		}

		private void Update_of_aftale(CrmContact crm_contact, OfContact of_contact)
		{//todo felter
			of_contact.Id = int.Parse(crm_contact.firstname);
		}

		private bool Needs_update_at_of(CrmContact crm_contact, OfContact of_contact)
		{//todo felter
			if (crm_contact.firstname != of_contact.Id.ToString())
			{
				return true;
			}

			return false;
		}

		private void Update_of_contact(CrmContact crm_contact, OfContact of_contact)
		{//todo felter
			of_contact.Id = int.Parse(crm_contact.firstname);

			_of_connection.Contact.Patch(crm_contact.of_id, of_contact);
		}

		private void Create_of_contact(CrmContact crm_contact)
		{//todo felter
			OfContact of_contact = new OfContact()
			{
				Id = int.Parse(crm_contact.firstname),
			};

			_of_connection.Contact.Post(of_contact);
		}
	}
}
