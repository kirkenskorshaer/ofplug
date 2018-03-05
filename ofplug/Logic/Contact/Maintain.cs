using Microsoft.Xrm.Sdk;
using ofplug.crm;
using ofplug.of;

namespace ofplug.Logic.Contact
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, Config config, Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Create_or_update_one_contact_in_crm(int? of_contact_id, of.data.Contact of_contact)
		{
			crm.Contact crm_contact = new crm.Contact(_service, _tracingService);
			crm_contact.Get_contact_from_of_contact_id(_service, of_contact_id.Value);

			if (crm_contact.CrmEntity == null)
			{
				Create_contact_in_crm(crm_contact, of_contact);
			}
			else if (Mapping.Contact.Needs_update_in_crm(crm_contact, of_contact))
			{
				Update_contact_in_crm(crm_contact, of_contact);
			}
		}

		private void Update_contact_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			Mapping.Contact.To_crm(crm_contact, of_contact);

			crm_contact.Update();
		}

		private void Create_contact_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			Mapping.Contact.To_crm(crm_contact, of_contact);

			crm_contact.Create();
		}

		public void Create_or_update_one_in_of(crm.Contact crm_contact)
		{
			of.data.Contact of_contact = Get_or_create_of_contact(crm_contact);

			if (Mapping.Contact.Needs_update_in_of(crm_contact, of_contact))
			{
				Update_of_contact(crm_contact, of_contact);
			}
		}

		public void Update_all_medlemsnr_in_of()
		{
			of.connector.Contacts contacts = _of_connection.Get_contacts();
			foreach (int id in contacts)
			{
				crm.Contact crm_contact = new crm.Contact(_service, _tracingService);

				of.data.Contact of_contact = _of_connection.Contact.Get(id);
				crm_contact.Get_contact_from_basis_information(_service, of_contact.Of_id.ToString());//todo felter

				if (crm_contact.CrmEntity == null)
				{
					continue;
				}

				if (Needs_medlemsnr_update_in_of(crm_contact, of_contact))
				{
					//todo sæt medlemsnr
					of_contact.Of_id = int.Parse(crm_contact.firstname);
				}
				//todo remove
				break;
			}
		}

		private bool Needs_medlemsnr_update_in_of(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			//todo skal se om medlemsnr er udfyldt
			if (crm_contact.firstname != of_contact.Of_id.ToString())
			{
				return true;
			}

			return false;
		}

		private void Update_of_contact(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			Mapping.Contact.To_of(crm_contact, of_contact);

			_of_connection.Contact.Patch(of_contact.Of_id.Value, of_contact);
		}
	}
}
