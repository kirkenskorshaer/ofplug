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

		public static bool Needs_update_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			return
				crm_indbetaling.of_aftale_id != of_payment.Agreement_id ||
				crm_indbetaling.new_amount != of_payment.Amount;
		}

		public static bool Needs_update_in_of(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			return
				of_payment.Agreement_id != crm_indbetaling.of_aftale_id ||
				of_payment.Amount != (int?)crm_indbetaling.new_amount;
		}
	}
}
