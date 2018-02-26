using Microsoft.Xrm.Sdk;

namespace ofplug.Logic.Aftale
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, crm.Config config, of.Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Update_agreements_in_crm_from_of_data()
		{
			of.connector.Agreements agreements = new of.connector.Agreements(_config.Url, _config.Aggrement_step);
			foreach (int id in agreements)
			{
				crm.Aftale crm_aftale = new crm.Aftale(_service);
				crm_aftale.Get_entity_by_of_id(_service, id);
				of.data.Agreement of_agreement = _of_connection.Agreement.Get(id);

				if (crm_aftale.CrmEntity == null)
				{
					Create_crm_aftale(of_agreement);
				}
				else if (Mapping.Aftale.Needs_update_in_crm(crm_aftale, of_agreement))
				{
					crm_aftale.Update();
				}
				//todo remove
				break;
			}
		}

		public void Create_or_update_one_aftale_in_crm(of.data.Agreement of_aftale)
		{
			crm.Aftale crm_aftale = new crm.Aftale(_service, _tracingService);
			crm_aftale.Get_by_of_id(of_aftale.Id.Value);

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

			Add_contact(crm_aftale, of_agreement);

			crm_aftale.Create();
		}

		private void Update_aftale_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			Mapping.Aftale.To_crm(crm_aftale, of_aftale);

			Add_contact(crm_aftale, of_aftale);

			crm_aftale.Update();
		}

		private void Add_contact(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			crm.Contact crm_contact = Get_or_create_contact(of_aftale.Contact_id.Value);

			crm_aftale.nrq_bidragyder = crm_contact.Get_entity_reference();
		}

		public void Create_or_update_one_in_of(crm.Aftale crm_aftale)
		{
			of.data.Agreement of_aftale = null;

			if (crm_aftale.of_id.HasValue)
			{
				of_aftale = _of_connection.Agreement.Get(crm_aftale.of_id.Value);
			}

			if (of_aftale == null)
			{
				Create_of_aftale(crm_aftale);
			}
			else if (Mapping.Aftale.Needs_update_in_of(crm_aftale, of_aftale))
			{
				Update_of_aftale(crm_aftale, of_aftale);
			}
		}

		private void Update_of_aftale(crm.Aftale crm_aftale, of.data.Agreement of_aftale)
		{
			Mapping.Aftale.To_of(crm_aftale, of_aftale);

			_of_connection.Agreement.Patch(of_aftale.Id.Value, of_aftale);
		}

		private void Create_of_aftale(crm.Aftale crm_aftale)
		{
			of.data.Agreement of_aftale = new of.data.Agreement();

			Mapping.Aftale.To_of(crm_aftale, of_aftale);

			_of_connection.Agreement.Post(of_aftale);
		}
	}
}
