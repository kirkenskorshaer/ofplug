using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Aftale
	{
		//todo felter
		public static void To_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			of_agreement.Amount = (int)crm_aftale.nrq_beloeb.Value;
			of_agreement.Payment_type = crm_aftale.nrq_betalingsform;
			of_agreement.Frequency = crm_aftale.nrq_frekvens;
			of_agreement.Crm_id = crm_aftale.Id.ToString().ToLower();
			//of_agreement.Payment_media = crm_aftale.nrq_type;
			//of_agreement.Id = crm_aftale.of_id;
		}

		public static void To_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			crm_aftale.nrq_beloeb = new Microsoft.Xrm.Sdk.Money((decimal)of_agreement.Amount);
			crm_aftale.nrq_betalingsform = of_agreement.Payment_type;
			crm_aftale.nrq_frekvens = of_agreement.Frequency;
			crm_aftale.nrq_type = of_agreement.Of_id.ToString();
			//crm_aftale.of_id = of_agreement.Id;
		}

		public static List<string> Needs_update_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "nrq_beloeb", (int?)crm_aftale.nrq_beloeb?.Value, of_agreement.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_frekvens", crm_aftale.nrq_frekvens, of_agreement.Frequency);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_type", crm_aftale.nrq_type, of_agreement.Of_id.GetValueOrDefault().ToString());
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_betalingsform", crm_aftale.nrq_betalingsform, of_agreement.Payment_type);

			//crm_aftale.nrq_type != of_agreement.Payment_media ||

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "Amount", (int?)crm_aftale.nrq_beloeb?.Value, of_agreement.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "Frequency", crm_aftale.nrq_frekvens, of_agreement.Frequency);
			Mapping_update_helper.Add_if_unequal(parameters, "payment_type", crm_aftale.nrq_betalingsform, of_agreement.Payment_type);

			return parameters;
		}
	}
}
