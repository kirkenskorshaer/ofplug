using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.Abstract
{
	public abstract class Abstract_maintain
	{
		protected of.Connection _of_connection;
		protected crm.Config _config;
		protected IOrganizationService _service;

		public Abstract_maintain(IOrganizationService service, crm.Config config, of.Connection of_connection)
		{
			_of_connection = of_connection;
			_config = config;
			_service = service;
		}

		protected crm.Contact Get_or_create_contact(int of_contact_id)
		{
			of.data.Contact of_contact = _of_connection.Contact.Get(of_contact_id);

			crm.Contact contact = new crm.Contact(_service);
			contact.Get_contact(_service, of_contact.Id, of_contact.Id.Value, of_contact.Email);

			if (contact.CrmEntity == null)
			{
				Mapping.Contact.To_crm(contact, of_contact);

				contact.Create();
			}

			return contact;
		}
	}
}
