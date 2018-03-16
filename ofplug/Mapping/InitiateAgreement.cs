namespace ofplug.Mapping
{
	public class InitiateAgreement
	{
		public static void To_of(crm.StartAftale crm_initiate_agreement, of.data.InitiateAgreement of_initiate_agreement)
		{
			of_initiate_agreement.Name = crm_initiate_agreement.Nrq_Name;
			of_initiate_agreement.First_name = crm_initiate_agreement.Nrq_First_name;
			of_initiate_agreement.Middle_name = crm_initiate_agreement.Nrq_Middle_name;
			of_initiate_agreement.Last_name = crm_initiate_agreement.Nrq_Last_name;
			of_initiate_agreement.Address = crm_initiate_agreement.Nrq_Address;
			of_initiate_agreement.Post_code = crm_initiate_agreement.Nrq_Post_code;
			of_initiate_agreement.City = crm_initiate_agreement.Nrq_City;
			of_initiate_agreement.Country = crm_initiate_agreement.Nrq_Country;
			of_initiate_agreement.Msisdn = crm_initiate_agreement.Nrq_Msisdn;
			of_initiate_agreement.Email = crm_initiate_agreement.Nrq_Email;
			of_initiate_agreement.National_id = crm_initiate_agreement.Nrq_National_id;
			of_initiate_agreement.Business_code = crm_initiate_agreement.Nrq_Business_code;
			of_initiate_agreement.Bank_sort_code = crm_initiate_agreement.Nrq_Bank_sort_code;
			of_initiate_agreement.Bank_account_no = crm_initiate_agreement.Nrq_Bank_account_no;
			of_initiate_agreement.External_id = crm_initiate_agreement.Nrq_External_id;
			of_initiate_agreement.Payment_media = crm_initiate_agreement.Nrq_Payment_media;
			of_initiate_agreement.Amount = (int)crm_initiate_agreement.Nrq_Amount.Value;
			of_initiate_agreement.Frequency = crm_initiate_agreement.Nrq_Frequency;
			of_initiate_agreement.Project_id = crm_initiate_agreement.Nrq_Project_id;
		}
	}
}
