using ofplug.Logic.Abstract;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using CrmContact = ofplug.crm.Contact;
using OfContact = ofplug.of.data.Contact;

namespace ofplug.Logic.Contact
{
	public class Create_or_update_one_in_crm : AbstractCodeActivity
	{
		[Input("Of_contact_id")]
		public InArgument<int> Of_contact_id_InArgument { get; set; }

		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			int of_contact_id = Of_contact_id_InArgument.Get<int>(codeActivityContext);

			OfContact of_contact = _of_connection.Contact.Get(of_contact_id);

			if (of_contact == null)
			{
				return;
			}

			CrmContact crm_contact = new CrmContact(_service);
			crm_contact.Get_by_of_id(_service, of_contact_id);

			if (crm_contact.CrmEntity == null)
			{
				Create_in_crm(crm_contact, of_contact);
			}
			else if (Needs_update_in_crm(crm_contact, of_contact))
			{
				Update_in_crm(crm_contact, of_contact);
			}
			//List<CrmAftale> aftaler = CrmAftale.GetAll(_service);
		}

		private void Update_in_crm(CrmContact crm_contact, OfContact of_contact)
		{
			//todo felter
			crm_contact.firstname = of_contact.Id.ToString();

			crm_contact.Update();
		}

		private bool Needs_update_in_crm(CrmContact crm_contact, OfContact of_contact)
		{
			//todo felter
			if (crm_contact.firstname != of_contact.Id.ToString())
			{
				return true;
			}

			return false;
		}

		private void Create_in_crm(CrmContact crm_contact, OfContact of_contact)
		{
			crm_contact.firstname = of_contact.Id.ToString();
			//todo felter

			crm_contact.Create();
		}
	}
}
