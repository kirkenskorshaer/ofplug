using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.InitiateAgreement
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, crm.Config config, of.Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Process_InitiateAgreement(crm.StartAftale crm_start_aftale)
		{
			if (crm_start_aftale.Nrq_import_status == true)
			{
				return;
			}

			of.data.InitiateAgreement of_start_aftale = new of.data.InitiateAgreement();
			Mapping.InitiateAgreement.To_of(crm_start_aftale, of_start_aftale);

			of.data.InitiateAgreementResponse of_initiateAgreementResponse = _of_connection.Initiate_agreement.Post(of_start_aftale);

			of.data.Agreement of_aftale = _of_connection.Agreement.Get(of_initiateAgreementResponse.Agreement_id);
			of.data.Contact of_contact = _of_connection.Contact.Get(of_initiateAgreementResponse.Contact_id);
			of.data.Subscription of_abonnement = _of_connection.Subscription.Get(of_initiateAgreementResponse.Subscription_id);

			crm.Aftale crm_aftale = Create_or_update_one_aftale_in_crm(of_aftale);
			crm.Contact crm_contact = Create_or_update_one_contact_in_crm(of_initiateAgreementResponse.Contact_id, of_contact);
			crm.Abonnement crm_abonnement = Create_or_update_one_abonnement_in_crm(of_abonnement);

			of.data.Agreement of_aftale_patch = new of.data.Agreement() { Of_id = of_aftale.Of_id, Crm_id = crm_aftale.Id.ToString().ToLower() };
			of.data.Contact of_contact_patch = new of.data.Contact() { Of_id = of_contact.Of_id, Crm_id = crm_contact.Id.ToString().ToLower() };
			of.data.Subscription of_abonnement_patch = new of.data.Subscription() { Of_id = of_abonnement.Of_id, Crm_id = crm_contact.Id.ToString().ToLower() };

			_of_connection.Agreement.Patch(of_aftale_patch.Of_id.Value, of_aftale_patch);
			_of_connection.Contact.Patch(of_contact_patch.Of_id.Value, of_contact_patch);
			_of_connection.Subscription.Patch(of_abonnement_patch.Of_id.Value, of_abonnement_patch);

			crm.StartAftale crm_start_aftale_update = new crm.StartAftale(_service, _tracingService)
			{
				Id = crm_start_aftale.Id,
				Nrq_import_status = true,
			};

			crm_start_aftale_update.Update();
		}
	}
}
