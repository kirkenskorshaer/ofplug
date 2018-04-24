using System;
using Microsoft.Xrm.Sdk;
using ofplug.crm;
using ofplug.of;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.Logic.Indbetaling
{
	public class Maintain : Abstract.Abstract_maintain
	{
		public Maintain(IOrganizationService service, ITracingService tracingService, Config config, Connection of_connection) : base(service, tracingService, config, of_connection)
		{
		}

		public void Create_or_update_all_indbetaling_in_crm()
		{
			foreach (int id in _of_connection.Get_payments())
			{
				of.data.Payment of_indbetaling = _of_connection.Payment.Get(id);

				Create_or_update_one_indbetaling_in_crm(of_indbetaling.Of_id.Value, of_indbetaling);

				//todo remove
				break;
			}
		}

		public void Update_status_in_of(crm.Indbetaling crm_indbetaling)
		{
			//todo byt ud med of_indbetaling_id
			int? of_indbetaling_id = crm_indbetaling.Nrq_of_id;

			if (of_indbetaling_id.HasValue == false)
			{
				return;
			}

			of.data.Payment of_indbetaling = _of_connection.Payment.Get(of_indbetaling_id.Value);

			//todo sæt status
			//string crm_status = crm_indbetaling.nrq_tekst;
			string crm_status = string.Empty;
			if (crm_status == of_indbetaling.State)
			{
				return;
			}

			of.data.Payment of_indbetaling_patch = new of.data.Payment()
			{
				Of_id = of_indbetaling_id,
				State = crm_status,
			};
			_of_connection.Payment.Patch(of_indbetaling_id.Value, of_indbetaling);
		}

		public void Create_or_update_one_indbetaling_in_crm(int of_indbetaling_id, of.data.Payment of_indbetaling)
		{
			crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service, _tracingService);

			crm_indbetaling.Get_by_of_id(of_indbetaling_id);

			if (crm_indbetaling.CrmEntity == null)
			{
				Create_in_crm(crm_indbetaling, of_indbetaling);
			}
			else
			{
				Update_in_crm(crm_indbetaling, of_indbetaling);
			}
		}

		private void Update_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_indbetaling)
		{
			List<string> parameters_to_update = Mapping.Indbetaling.Needs_update_in_crm(crm_indbetaling, of_indbetaling);

			if (parameters_to_update.Any() == false)
			{
				return;
			}

			Mapping.Indbetaling.To_crm(crm_indbetaling, of_indbetaling);

			Create_or_update_associated_entities(crm_indbetaling, of_indbetaling);

			crm_indbetaling.Update(parameters_to_update);
		}

		private void Create_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_indbetaling)
		{
			Mapping.Indbetaling.To_crm(crm_indbetaling, of_indbetaling);

			Create_or_update_associated_entities(crm_indbetaling, of_indbetaling);

			crm_indbetaling.Create();
		}

		private void Create_or_update_associated_entities(crm.Indbetaling crm_indbetaling, of.data.Payment of_indbetaling)
		{
			if (of_indbetaling.Agreement_id.HasValue)
			{
				of.data.Agreement of_aftale = _of_connection.Agreement.Get(of_indbetaling.Agreement_id.Value);

				crm.Aftale crm_aftale = Create_or_update_one_aftale_in_crm(of_aftale);

				crm_indbetaling.Nrq_betalingsaftale = new EntityReference("new_indbetaling", crm_aftale.Id);

				//_tracingService.Trace($"connecting aftale {crm_aftale.Id} to indbetaling {crm_indbetaling.Id}");
			}
			else
			{
				//_tracingService.Trace($"no aftale on indbetaling {crm_indbetaling.Id}");
			}

			if (of_indbetaling.Contact_id.HasValue)
			{
				of.data.Contact of_contact = _of_connection.Contact.Get(of_indbetaling.Contact_id.Value);

				crm.Contact crm_contact = Create_or_update_one_contact_in_crm(of_indbetaling.Contact_id, of_contact);

				crm_indbetaling.Nrq_indbetaler = new EntityReference("contact", crm_contact.Id);

				//_tracingService.Trace($"connecting contact {crm_contact.Id} to indbetaling {crm_indbetaling.Id}");
			}
			else
			{
				//_tracingService.Trace($"no contact on indbetaling {crm_indbetaling.Id}");
			}

			crm_indbetaling.Set_indbetaling_type_from_of_project_id(of_indbetaling.Project_id);
		}
	}
}
