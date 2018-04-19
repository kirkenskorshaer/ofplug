namespace ofplug.Mapping
{
	public class InitiateAgreement
	{
		public static void To_of(crm.AgreementRequest crm_initiate_agreement, of.data.InitiateAgreement of_initiate_agreement)
		{
			of_initiate_agreement.Name = crm_initiate_agreement.Nrq_name;
			of_initiate_agreement.First_name = crm_initiate_agreement.Nrq_firstname;
			of_initiate_agreement.Middle_name = crm_initiate_agreement.Nrq_middlename;
			of_initiate_agreement.Last_name = crm_initiate_agreement.Nrq_lastname;
			of_initiate_agreement.Address = crm_initiate_agreement.Nrq_address_line;
			of_initiate_agreement.Post_code = crm_initiate_agreement.Nrq_address_postalcode;
			of_initiate_agreement.City = crm_initiate_agreement.Nrq_address_city;
			of_initiate_agreement.Country = crm_initiate_agreement.Nrq_address_country ?? "DK";
			of_initiate_agreement.Msisdn = crm_initiate_agreement.Nrq_msisdn;
			of_initiate_agreement.Email = crm_initiate_agreement.Nrq_emailaddress;
			of_initiate_agreement.National_id = crm_initiate_agreement.Nrq_cprnr;
			of_initiate_agreement.Business_code = crm_initiate_agreement.Nrq_cvrnr;
			of_initiate_agreement.Bank_sort_code = crm_initiate_agreement.Nrq_banksortcode;
			of_initiate_agreement.Bank_account_no = crm_initiate_agreement.Nrq_bankaccountno;
			of_initiate_agreement.External_id = crm_initiate_agreement.External_id;
			of_initiate_agreement.Payment_media = crm_initiate_agreement.Nrq_paymentmedia.SelectedValue;
			of_initiate_agreement.Amount = (int)crm_initiate_agreement.Nrq_amount.Value;
			of_initiate_agreement.Frequency = crm_initiate_agreement.Nrq_frequency.SelectedValue;
			//of_initiate_agreement.Project_id = crm_initiate_agreement.Nrq_projectid.GetValueOrDefault();
			of_initiate_agreement.Project_id = int.Parse(crm_initiate_agreement.Nrq_projectid);
		}
	}
}
