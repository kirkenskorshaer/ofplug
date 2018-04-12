using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace ofplug.crm
{
	public class Account : AbstractCrm
	{
		public string Name;
		public string Address1_line1;
		public string Address1_postalcode;
		public string Address1_city;
		public string Address1_country;
		public string Emailaddress1;
		public string New_kkadminmedlemsnr;
		public string Nrq_cvrnr;
		public string Nrq_msisdn;

		private static ColumnSet _columnSet = new ColumnSet
		(
			"name",
			"address1_line1",
			"address1_postalcode",
			"address1_city",
			"address1_country",
			"emailaddress1",
			"new_kkadminmedlemsnr",
			"nrq_cvrnr",
			"nrq_msisdn"
		);

		public Account(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "account")
		{
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, _columnSet);

			Read_from_entity();
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("name", Name, parameters);
			Fill_if_not_empty("address1_line1", Address1_line1, parameters);
			Fill_if_not_empty("address1_postalcode", Address1_postalcode, parameters);
			Fill_if_not_empty("address1_city", Address1_city, parameters);
			Fill_if_not_empty("address1_country", Address1_country, parameters);
			Fill_if_not_empty("emailaddress1", Emailaddress1, parameters);
			Fill_if_not_empty("new_kkadminmedlemsnr", New_kkadminmedlemsnr, parameters);
			Fill_if_not_empty("nrq_cvrnr", Nrq_cvrnr, parameters);
			Fill_if_not_empty("nrq_msisdn", Nrq_msisdn, parameters);
		}

		public override void Read_fields()
		{
			Name = Read_if_not_empty<string>("name");
			Address1_line1 = Read_if_not_empty<string>("address1_line1");
			Address1_postalcode = Read_if_not_empty<string>("address1_postalcode");
			Address1_city = Read_if_not_empty<string>("address1_city");
			Address1_country = Read_if_not_empty<string>("address1_country");
			Emailaddress1 = Read_if_not_empty<string>("emailaddress1");
			New_kkadminmedlemsnr = Read_if_not_empty<string>("new_kkadminmedlemsnr");
			Nrq_cvrnr = Read_if_not_empty<string>("nrq_cvrnr");
			Nrq_msisdn = Read_if_not_empty<string>("nrq_msisdn");
		}
	}
}
