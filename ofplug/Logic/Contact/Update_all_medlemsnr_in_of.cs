using ofplug.Logic.Abstract;
using System.Activities;
using CrmContact = ofplug.crm.Contact;

namespace ofplug.Logic.Contact
{
	public class Update_all_medlemsnr_in_of : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			of.connector.Contacts contacts = new of.connector.Contacts(_config.Url, _config.Aggrement_step);
			foreach (int id in contacts)
			{
				CrmContact crm_contact = new CrmContact(_service);

				of.data.Contact of_contact = _of_connection.Contact.Get(id);
				crm_contact.Get_contact_from_basis_information(_service, of_contact.Id.ToString());//todo felter

				if (crm_contact.CrmEntity == null)
				{
					continue;
				}

				if (Needs_update_in_of(crm_contact, of_contact))
				{
					//todo sæt medlemsnr
					of_contact.Id = int.Parse(crm_contact.firstname);
				}
				//todo remove
				break;
			}
		}

		private bool Needs_update_in_of(CrmContact crm_contact, of.data.Contact of_contact)
		{
			//todo skal se om medlemsnr er udfyldt
			if (crm_contact.firstname != of_contact.Id.ToString())
			{
				return true;
			}

			return false;
		}
	}
}
