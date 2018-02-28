namespace ofplug.Mapping
{
	public static class Aftale
	{
		//todo felter
		public static void To_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			of_agreement.Amount = (int)crm_aftale.nrq_beloeb.Value;
			of_agreement.Payment_method = crm_aftale.nrq_betalingsform;
			of_agreement.Frequency = crm_aftale.nrq_frekvens;
			//of_agreement.Payment_media = crm_aftale.nrq_type;
			//of_agreement.Id = crm_aftale.of_id;
		}

		public static void To_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			crm_aftale.nrq_beloeb = new Microsoft.Xrm.Sdk.Money((decimal)of_agreement.Amount);
			crm_aftale.nrq_betalingsform = of_agreement.Payment_method;
			crm_aftale.nrq_frekvens = of_agreement.Frequency;
			crm_aftale.nrq_type = of_agreement.Of_id.ToString();
			//crm_aftale.of_id = of_agreement.Id;
		}

		public static bool Needs_update_in_crm(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			return
				crm_aftale.nrq_beloeb == null ||
				crm_aftale.nrq_beloeb.Value != of_agreement.Amount ||
				crm_aftale.nrq_betalingsform != of_agreement.Payment_method ||
				crm_aftale.nrq_frekvens != of_agreement.Frequency ||
				//crm_aftale.nrq_type != of_agreement.Payment_media ||
				crm_aftale.nrq_type != of_agreement.Of_id.GetValueOrDefault().ToString();
		}

		public static bool Needs_update_in_of(crm.Aftale crm_aftale, of.data.Agreement of_agreement)
		{
			return
				crm_aftale.nrq_beloeb.Value != of_agreement.Amount ||
				crm_aftale.nrq_betalingsform != of_agreement.Payment_method ||
				crm_aftale.nrq_frekvens != of_agreement.Frequency ||
				crm_aftale.nrq_type != of_agreement.Of_id.GetValueOrDefault().ToString();
			//crm_aftale.of_id != of_agreement.Id;
		}
	}
}
