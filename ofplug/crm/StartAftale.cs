using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace ofplug.crm
{
	public class StartAftale : AbstractCrm
	{
		public string Nrq_Name;
		public string Nrq_First_name;
		public string Nrq_Middle_name;
		public string Nrq_Last_name;
		public string Nrq_Address;
		public string Nrq_Post_code;
		public string Nrq_City;
		public string Nrq_Country;
		public string Nrq_Msisdn;
		public string Nrq_Email;
		public string Nrq_National_id;
		public string Nrq_Business_code;
		public int? Nrq_Bank_sort_code;
		public int? Nrq_Bank_account_no;
		public string Nrq_External_id;
		public string Nrq_Payment_media;
		public Money Nrq_Amount;
		public string Nrq_Frequency;
		public int Nrq_Project_id;

		public bool Nrq_import_status;

		public StartAftale(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "StartAftale")//todo norriq navn
		{
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, new ColumnSet("nrq_of_id"));

			Read_from_entity();
		}

		public override void Fill_fields()
		{
			//todo felter
			Fill_if_not_empty("nrq_Name", Nrq_Name);
			Fill_if_not_empty("nrq_First_name", Nrq_First_name);
			Fill_if_not_empty("nrq_Middle_name", Nrq_Middle_name);
			Fill_if_not_empty("nrq_Last_name", Nrq_Last_name);
			Fill_if_not_empty("nrq_Address", Nrq_Address);
			Fill_if_not_empty("nrq_Post_code", Nrq_Post_code);
			Fill_if_not_empty("nrq_City", Nrq_City);
			Fill_if_not_empty("nrq_Country", Nrq_Country);
			Fill_if_not_empty("nrq_Msisdn", Nrq_Msisdn);
			Fill_if_not_empty("nrq_Email", Nrq_Email);
			Fill_if_not_empty("nrq_National_id", Nrq_National_id);
			Fill_if_not_empty("nrq_Business_code", Nrq_Business_code);
			Fill_if_not_empty("nrq_Bank_sort_code", Nrq_Bank_sort_code);
			Fill_if_not_empty("nrq_Bank_account_no", Nrq_Bank_account_no);
			Fill_if_not_empty("nrq_External_id", Nrq_External_id);
			Fill_if_not_empty("nrq_Payment_media", Nrq_Payment_media);
			Fill_if_not_empty("nrq_Amount", Nrq_Amount);
			Fill_if_not_empty("nrq_Frequency", Nrq_Frequency);
			Fill_if_not_empty("nrq_Project_id", Nrq_Project_id);
			Fill_if_not_empty("nrq_import_status", Nrq_import_status);
		}

		public override void Read_fields()
		{
			//todo felter
			Nrq_Name = Read_if_not_empty<string>("nrq_Name");
			Nrq_First_name = Read_if_not_empty<string>("nrq_First_name");
			Nrq_Middle_name = Read_if_not_empty<string>("nrq_Middle_name");
			Nrq_Last_name = Read_if_not_empty<string>("nrq_Last_name");
			Nrq_Address = Read_if_not_empty<string>("nrq_Address");
			Nrq_Post_code = Read_if_not_empty<string>("nrq_Post_code");
			Nrq_City = Read_if_not_empty<string>("nrq_City");
			Nrq_Country = Read_if_not_empty<string>("nrq_Country");
			Nrq_Msisdn = Read_if_not_empty<string>("nrq_Msisdn");
			Nrq_Email = Read_if_not_empty<string>("nrq_Email");
			Nrq_National_id = Read_if_not_empty<string>("nrq_National_id");
			Nrq_Business_code = Read_if_not_empty<string>("nrq_Business_code");
			Nrq_Bank_sort_code = Read_if_not_empty<int?>("nrq_Bank_sort_code");
			Nrq_Bank_account_no = Read_if_not_empty<int?>("nrq_Bank_account_no");
			Nrq_External_id = Read_if_not_empty<string>("nrq_External_id");
			Nrq_Payment_media = Read_if_not_empty<string>("nrq_Payment_media");
			Nrq_Amount = Read_if_not_empty<Money>("nrq_Amount");
			Nrq_Frequency = Read_if_not_empty<string>("nrq_Frequency");
			Nrq_Project_id = Read_if_not_empty<int>("nrq_Project_id");
			Nrq_import_status = Read_if_not_empty<bool>("nrq_import_status");
		}
	}
}
