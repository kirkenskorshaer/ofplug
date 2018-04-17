using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Linq;

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

			Update_of_contact(crm_contact, of_contact);
		}

		private void Update_of_contact(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			List<string> parameters_to_update = Mapping.Contact.Needs_update_in_of(crm_contact, of_contact);
			if (parameters_to_update.Any() == false)
			{
				return;
			}

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
			else
			{
				Update_abonnement_in_crm(crm_abonnement, of_abonnement);
			}

			return crm_abonnement;
		}

		private void Update_abonnement_in_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			Mapping.Subscription.To_crm(crm_abonnement, of_abonnement);

			Add_crm_contact_to_abonnement(crm_abonnement, of_abonnement);

			crm_abonnement.Update(Mapping.Subscription.Needs_update_in_crm(crm_abonnement, of_abonnement));
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

		public crm.Aftale Create_or_update_one_aftale_in_crm(of.data.Agreement of_aftale)
		{
			crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);
			crm_aftale.Get_by_of_id(of_aftale.Of_id.Value);

			if (crm_aftale.CrmEntity == null)
			{
				crm_aftale = Create_crm_aftale(of_aftale);
			}
			else
			{
				Update_aftale_in_crm(crm_aftale, of_aftale);
			}

			return crm_aftale;
		}

		private crm.Aftale Create_crm_aftale(of.data.Agreement of_agreement)
		{
			crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);

			Mapping.Aftale.To_crm(crm_aftale, of_agreement);

			Add_contact_to_aftale(crm_aftale, of_agreement);

			crm_aftale.Create();

			return crm_aftale;
		}

		private void Update_aftale_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			List<string> parameters_to_update = Mapping.Aftale.Needs_update_in_crm(crm_aftale, of_aftale);
			if (parameters_to_update.Any() == false)
			{
				return;
			}

			Mapping.Aftale.To_crm(crm_aftale, of_aftale);

			bool update_nrq_bidragyder = Add_contact_to_aftale(crm_aftale, of_aftale);
			if (parameters_to_update.Contains("nrq_bidragyder") == false && update_nrq_bidragyder)
			{
				parameters_to_update.Add("nrq_bidragyder");
			}
			crm_aftale.Update(parameters_to_update);
		}

		private bool Add_contact_to_aftale(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			crm.Contact crm_contact = Get_or_create_crm_contact(of_aftale.Contact_id.Value);

			bool update_nrq_bidragyder = false;
			if (crm_aftale.nrq_bidragyder == null || crm_aftale.nrq_bidragyder.Id != crm_contact.Id)
			{
				update_nrq_bidragyder = true;
			}

			crm_aftale.nrq_bidragyder = crm_contact.Get_entity_reference();

			return update_nrq_bidragyder;
		}

		public crm.Contact Create_or_update_one_contact_in_crm(int? of_contact_id, of.data.Contact of_contact)
		{
			crm.Contact crm_contact = new crm.Contact(_service, _tracingService);
			crm_contact.Get_contact_from_of_contact_id(_service, of_contact_id.Value);

			if (crm_contact.CrmEntity == null)
			{
				Create_contact_in_crm(crm_contact, of_contact);
			}
			else
			{
				Update_contact_in_crm(crm_contact, of_contact);
			}

			return crm_contact;
		}

		private void Update_contact_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			List<string> parameters_to_update = Mapping.Contact.Needs_update_in_crm(crm_contact, of_contact);
			if (parameters_to_update.Any() == false)
			{
				return;
			}

			Mapping.Contact.To_crm(crm_contact, of_contact);

			crm_contact.Update(parameters_to_update);
		}

		private void Create_contact_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			Mapping.Contact.To_crm(crm_contact, of_contact);

			crm_contact.Create();
		}

		protected of.data.Contact Get_or_create_of_contact(crm.Contact crm_contact)
		{
			of.data.Contact of_contact = null;

			if (crm_contact.nrq_of_id.HasValue)
			{
				of_contact = _of_connection.Contact.Get(crm_contact.nrq_of_id.Value);
			}
			else
			{
				of_contact = new of.data.Contact();
				Mapping.Contact.To_of(crm_contact, of_contact);

				of.data.IdResponse response = _of_connection.Contact.Post(of_contact);

				crm.Contact update_crm_contact = new crm.Contact(_service, _tracingService)
				{
					nrq_of_id = response.Id,
					Id = crm_contact.Id
				};
				update_crm_contact.Update();
			}

			return of_contact;
		}
	}
}
