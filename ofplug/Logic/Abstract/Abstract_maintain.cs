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

		public void Create_or_update_one_contact_in_of(crm.Contact crm_contact)
		{
			of.data.Contact of_contact = Get_or_create_of_contact(crm_contact);

			if (Mapping.Contact.Needs_update_in_of(crm_contact, of_contact))
			{
				Update_of_contact(crm_contact, of_contact);
			}
		}

		private void Update_of_contact(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			Mapping.Contact.To_of(crm_contact, of_contact);

			_of_connection.Contact.Patch(of_contact.Of_id.Value, of_contact);
		}

		public crm.Abonnement Create_or_update_one_abonnement_in_crm(of.data.Subscription of_abonnement)
		{
			crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService);
			crm_abonnement.Get_by_of_id(of_abonnement.Of_id.Value);

			if (crm_abonnement.CrmEntity == null)
			{
				crm_abonnement = Create_abonnement_in_crm(of_abonnement);
			}
			else if (Mapping.Subscription.Needs_update_in_crm(crm_abonnement, of_abonnement))
			{
				Update_abonnement_in_crm(crm_abonnement, of_abonnement);
			}

			return crm_abonnement;
		}

		private void Update_abonnement_in_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			Mapping.Subscription.To_crm(crm_abonnement, of_abonnement);

			Add_crm_contact_to_abonnement(crm_abonnement, of_abonnement);

			crm_abonnement.Update();
		}

		private crm.Abonnement Create_abonnement_in_crm(of.data.Subscription of_abonnement)
		{
			crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService);

			Mapping.Subscription.To_crm(crm_abonnement, of_abonnement);

			Add_crm_contact_to_abonnement(crm_abonnement, of_abonnement);

			crm_abonnement.Create();

			return crm_abonnement;
		}

		private void Add_crm_contact_to_abonnement(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			crm.Contact crm_contact = Get_or_create_crm_contact(of_abonnement.Contact_id.Value);

			crm_abonnement.Nrq_contact = crm_contact.Get_entity_reference();
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

		public void Create_or_update_one_aftale_in_crm(of.data.Agreement of_aftale)
		{
			crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);
			crm_aftale.Get_by_of_id(of_aftale.Of_id.Value);

			if (crm_aftale.CrmEntity == null)
			{
				Create_crm_aftale(of_aftale);
			}
			else if (Mapping.Aftale.Needs_update_in_crm(crm_aftale, of_aftale))
			{
				Update_aftale_in_crm(crm_aftale, of_aftale);
			}
		}

		private void Create_crm_aftale(of.data.Agreement of_agreement)
		{
			crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);

			Mapping.Aftale.To_crm(crm_aftale, of_agreement);

			Add_contact_to_aftale(crm_aftale, of_agreement);

			crm_aftale.Create();
		}

		private void Update_aftale_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			Mapping.Aftale.To_crm(crm_aftale, of_aftale);

			Add_contact_to_aftale(crm_aftale, of_aftale);

			crm_aftale.Update();
		}

		private void Add_contact_to_aftale(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			crm.Contact crm_contact = Get_or_create_crm_contact(of_aftale.Contact_id.Value);

			crm_aftale.nrq_bidragyder = crm_contact.Get_entity_reference();
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
