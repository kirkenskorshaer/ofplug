using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Aftale
	{
		public static void To_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			of_agreement.Amount = (int)crm_aftale.nrq_beloeb.Value;
			of_agreement.Payment_type = crm_aftale.nrq_betalingsform;
			of_agreement.Frequency = crm_aftale.nrq_frequency.SelectedValue;
			of_agreement.Crm_id = crm_aftale.Id.ToString().ToLower();
			of_agreement.Amount_type = crm_aftale.nrq_amounttype.SelectedValue;
			of_agreement.Currency = "208";
			of_agreement.Payment_media = crm_aftale.nrq_paymentmedia.SelectedValue;
			of_agreement.Payment_media_type = crm_aftale.nrq_type;
			of_agreement.Project_id = crm_aftale.nrq_of_project_id;
			of_agreement.State = crm_aftale.nrq_state;
			of_agreement.Agreement_start_type = crm_aftale.nrq_agreementstarttype;
			of_agreement.Agreement_start_ts_value = crm_aftale.nrq_startdato;
			of_agreement.Last_payment_ts_value = crm_aftale.nrq_slutdato;
			of_agreement.Charge_ts_value = crm_aftale.nrq_chargedate;
		}

		public static void To_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			crm_aftale.nrq_beloeb = new Microsoft.Xrm.Sdk.Money((decimal)of_agreement.Amount);
			crm_aftale.nrq_betalingsform = of_agreement.Payment_type;
			crm_aftale.nrq_amounttype.Select(of_agreement.Amount_type);
			crm_aftale.nrq_frequency.Select(of_agreement.Frequency);
			crm_aftale.nrq_of_contact_id = of_agreement.Contact_id;
			crm_aftale.nrq_of_id = of_agreement.Of_id;
			crm_aftale.nrq_of_project_id = of_agreement.Project_id;
			crm_aftale.nrq_of_subscription_id = of_agreement.Subscription_id;
			crm_aftale.nrq_paymentmedia.Select(of_agreement.Payment_media);
			crm_aftale.nrq_type = of_agreement.Payment_media_type?.ToString();
			crm_aftale.nrq_state = of_agreement.State;
			crm_aftale.nrq_agreementstarttype = of_agreement.Agreement_start_type;
			crm_aftale.nrq_startdato = of_agreement.Agreement_start_ts_value;
			crm_aftale.nrq_slutdato = of_agreement.Last_payment_ts_value;
			crm_aftale.nrq_chargedate = of_agreement.Charge_ts_value;
		}

		public static List<string> Needs_update_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "nrq_beloeb", crm_aftale.nrq_beloeb?.Value, of_agreement.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_betalingsform", crm_aftale.nrq_betalingsform, of_agreement.Payment_type);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_amounttype", crm_aftale.nrq_amounttype.SelectedValue, of_agreement.Amount_type);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_frequency", crm_aftale.nrq_frequency.SelectedValue, of_agreement.Frequency);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_contact_id", crm_aftale.nrq_of_contact_id, of_agreement.Contact_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_id", crm_aftale.nrq_of_id, of_agreement.Of_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_project_id", crm_aftale.nrq_of_project_id, of_agreement.Project_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_subscription_id", crm_aftale.nrq_of_subscription_id, of_agreement.Subscription_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentmedia", crm_aftale.nrq_paymentmedia?.SelectedValue, of_agreement.Payment_media_type);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_type", crm_aftale.nrq_type, of_agreement.Payment_media_type);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_agreementstarttype", crm_aftale.nrq_agreementstarttype, of_agreement.Agreement_start_type);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_startdato", crm_aftale.nrq_startdato, of_agreement.Agreement_start_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_slutdato", crm_aftale.nrq_slutdato, of_agreement.Last_payment_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_chargedate", crm_aftale.nrq_chargedate, of_agreement.Charge_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_state", crm_aftale.nrq_state, of_agreement.State);

			Mapping_update_helper.Add_if_other_exists(parameters, "nrq_of_subscription_id", "nrq_subscription");
			Mapping_update_helper.Add_if_other_exists(parameters, "nrq_of_contact_id", "nrq_bidragyder");

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "Amount", crm_aftale.nrq_beloeb?.Value, of_agreement.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "payment_type", crm_aftale.nrq_betalingsform, of_agreement.Payment_type);
			Mapping_update_helper.Add_if_unequal(parameters, "Amount_type", crm_aftale.nrq_amounttype.SelectedValue, of_agreement.Amount_type);
			Mapping_update_helper.Add_if_unequal(parameters, "Frequency", crm_aftale.nrq_frequency.SelectedValue, of_agreement.Frequency);
			Mapping_update_helper.Add_if_unequal(parameters, "Project_id", crm_aftale.nrq_of_project_id, of_agreement.Project_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_media", crm_aftale.nrq_paymentmedia.SelectedValue, of_agreement.Payment_media);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_media_type", crm_aftale.nrq_type, of_agreement.Payment_media_type);
			Mapping_update_helper.Add_if_unequal(parameters, "State", crm_aftale.nrq_state, of_agreement.State);
			Mapping_update_helper.Add_if_unequal(parameters, "Crm_id", crm_aftale.Id.ToString().ToLower(), of_agreement.Crm_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Agreement_start_type", crm_aftale.nrq_agreementstarttype, of_agreement.Agreement_start_type);
			Mapping_update_helper.Add_if_unequal(parameters, "Agreement_start_ts_value", crm_aftale.nrq_startdato, of_agreement.Agreement_start_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "Last_payment_ts_value", crm_aftale.nrq_slutdato, of_agreement.Last_payment_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "Charge_ts_value", crm_aftale.nrq_chargedate, of_agreement.Charge_ts_value);

			return parameters;
		}
	}
}
