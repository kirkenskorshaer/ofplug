using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.Abstract
{
	public abstract class Abstract_maintain
	{
		protected of.Connection _of_connection;
		protected crm.Config _config;
		protected IOrganizationService _service;
		protected ITracingService _tracingService;

		public Abstract_maintain(IOrganizationService service, ITracingService tracingService, crm.Config config, of.Connection of_connection)
		{
			_of_connection = of_connection;
			_config = config;
			_service = service;
			_tracingService = tracingService;
		}

		protected crm.Contact Get_or_create_crm_contact(int of_contact_id)
		{
			of.data.Contact of_contact = _of_connection.Contact.Get(of_contact_id);

			crm.Contact contact = new crm.Contact(_service, _tracingService);
			contact.Get_contact(_service, of_contact.Of_id, of_contact.Of_id.Value, of_contact.Email);

			if (contact.CrmEntity == null)
			{
				Mapping.Contact.To_crm(contact, of_contact);

				contact.Create();
			}

			return contact;
		}

		protected crm.Contact Get_crm_contact_from_crm_aftale(crm.Aftale crm_aftale)
		{
			if (crm_aftale.nrq_bidragyder != null)
			{
				crm.Contact crm_contact = new crm.Contact(_service, _tracingService);
				crm_contact.Get_by_reference(crm_aftale.nrq_bidragyder);

				if (crm_contact.CrmEntity != null)
				{
					return crm_contact;
				}
			}

			return null;
		}

		protected of.data.Contact Get_or_create_of_contact(crm.Contact crm_contact)
		{
			of.data.Contact of_contact = null;

			if (crm_contact.new_ofcontactid.HasValue)
			{
				of_contact = _of_connection.Contact.Get(crm_contact.new_ofcontactid.Value);
			}
			else
			{
				of_contact = new of.data.Contact();
				Mapping.Contact.To_of(crm_contact, of_contact);

				of.data.IdResponse response = _of_connection.Contact.Post(of_contact);

				crm.Contact update_crm_contact = new crm.Contact(_service, _tracingService)
				{
					new_ofcontactid = response.Id,
					Id = crm_contact.Id
				};
				update_crm_contact.Update();
			}

			return of_contact;
		}
	}
}
