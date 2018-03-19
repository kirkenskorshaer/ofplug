using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Indbetaling
	{
		//todo felter
		public static void To_of(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			of_payment.Agreement_id = crm_indbetaling.of_aftale_id;
			of_payment.Amount = (int?)crm_indbetaling.new_amount;
			of_payment.Crm_id = crm_indbetaling.Id.ToString().ToLower();
		}

		public static void To_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			crm_indbetaling.of_aftale_id = of_payment.Agreement_id;
			crm_indbetaling.new_amount = of_payment.Amount;
			//crm_indbetaling.new_valdt = of_payment.
		}

		public static List<string> Needs_update_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "of_aftale_id", crm_indbetaling.of_aftale_id, of_payment.Agreement_id);
			Mapping_update_helper.Add_if_unequal(parameters, "new_amount", crm_indbetaling.new_amount, of_payment.Amount);

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "Agreement_id", crm_indbetaling.of_aftale_id, of_payment.Agreement_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Amount", crm_indbetaling.new_amount, of_payment.Amount);

			return parameters;
		}
	}
}
