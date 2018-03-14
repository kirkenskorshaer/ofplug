using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.Abonnement
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, crm.Config config, of.Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Update_subscriptions_in_crm()
		{
			of.connector.Subscriptions subscriptions = _of_connection.Get_subscriptions();
			foreach (int id in subscriptions)
			{
				of.data.Subscription of_subscription = _of_connection.Subscription.Get(id);

				Create_or_update_one_abonnement_in_crm(of_subscription);

				//todo remove
				break;
			}
		}

		public void Create_or_update_one_abonnement_in_crm(of.data.Subscription of_abonnement)
		{
			crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService);
			crm_abonnement.Get_by_of_id(of_abonnement.Of_id.Value);

			if (crm_abonnement.CrmEntity == null)
			{
				Create_abonnement_in_crm(of_abonnement);
			}
			else if (Mapping.Subscription.Needs_update_in_crm(crm_abonnement, of_abonnement))
			{
				Update_abonnement_in_crm(crm_abonnement, of_abonnement);
			}
		}

		private void Update_abonnement_in_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			Mapping.Subscription.To_crm(crm_abonnement, of_abonnement);

			Add_crm_contact_to_abonnement(crm_abonnement, of_abonnement);

			crm_abonnement.Update();
		}

		private void Create_abonnement_in_crm(of.data.Subscription of_abonnement)
		{
			crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService);

			Mapping.Subscription.To_crm(crm_abonnement, of_abonnement);

			Add_crm_contact_to_abonnement(crm_abonnement, of_abonnement);

			crm_abonnement.Create();
		}

		private void Add_crm_contact_to_abonnement(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			crm.Contact crm_contact = Get_or_create_crm_contact(of_abonnement.Contact_id.Value);

			crm_abonnement.Nrq_contact = crm_contact.Get_entity_reference();
		}

		public void Create_or_update_one_abonnement_in_of(crm.Abonnement crm_abonnement)
		{
			of.data.Subscription of_abonnement = null;

			if (crm_abonnement.Nrq_of_subscription_id.HasValue)
			{
				of_abonnement = _of_connection.Subscription.Get(crm_abonnement.Nrq_of_subscription_id.Value);
			}

			if (of_abonnement == null)
			{
				Create_of_abonnement(crm_abonnement);
			}
			else if (Mapping.Subscription.Needs_update_in_of(crm_abonnement, of_abonnement))
			{
				Update_of_abonnement(crm_abonnement, of_abonnement);
			}
		}

		private void Update_of_abonnement(crm.Abonnement crm_abonnement, of.data.Subscription of_abonnement)
		{
			Mapping.Subscription.To_of(crm_abonnement, of_abonnement);

			Attach_of_contact_if_missing(crm_abonnement);

			_of_connection.Subscription.Patch(of_abonnement.Of_id.Value, of_abonnement);
		}

		private void Create_of_abonnement(crm.Abonnement crm_abonnement)
		{
			of.data.Subscription of_abonnement = new of.data.Subscription();

			Mapping.Subscription.To_of(crm_abonnement, of_abonnement);

			Attach_of_contact_if_missing(crm_abonnement);

			of.data.IdResponse id_response = _of_connection.Subscription.Post(of_abonnement);

			crm.Abonnement crm_abonnement_update = new crm.Abonnement(_service, _tracingService)
			{
				Id = crm_abonnement.Id,
				Nrq_of_subscription_id = id_response.Id
			};
			crm_abonnement_update.Update();
		}

		private void Attach_of_contact_if_missing(crm.Abonnement crm_abonnement)
		{
			if (crm_abonnement.Nrq_contact != null)
			{
				crm.Contact crm_contact = new crm.Contact(_service, _tracingService);
				crm_contact.Get_by_reference(crm_abonnement.Nrq_contact);
				Create_or_update_one_contact_in_of(crm_contact);
			}
		}
	}
}
