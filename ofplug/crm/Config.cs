using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace ofplug.crm
{
	public class Config : AbstractCrm
	{
		public string Url { get; private set; }
		public int Aggrement_step { get; private set; }
		public int Payment_step { get; private set; }
		public int Contact_step { get; private set; }

		public Config(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "nrq_settings")
		{
			//QueryExpression queryExpression = Create_query_expression("nrq_project", "ofplug", new ColumnSet("nrq_url", "nrq_url"));

			//EntityCollection entities = _service.RetrieveMultiple(queryExpression);


			//todo opret korrekt entitet
			//CrmEntity = entities.Entities.FirstOrDefault();
			CrmEntity = new Entity();
			CrmEntity["nrq_url"] = "http://of.devflowtwo.com/kirkenskorshaer/api/v2/";
			CrmEntity["nrq_aggrement_step"] = 50;
			CrmEntity["nrq_payment_step"] = 50;
			CrmEntity["nrq_contact_step"] = 50;



			Url = CrmEntity["nrq_url"].ToString();
			if (Url.EndsWith("/") == false)
			{
				Url = Url + "/";
			}

			Aggrement_step = int.Parse(CrmEntity["nrq_aggrement_step"].ToString());
			Payment_step = int.Parse(CrmEntity["nrq_payment_step"].ToString());
			Contact_step = int.Parse(CrmEntity["nrq_contact_step"].ToString());
		}

		public override void Fill_fields()
		{
			//todo maybe implement
		}

		public override void Read_fields()
		{
			//todo maybe implement
		}
	}
}
