using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class Config : AbstractCrm
	{
		public string Nrq_of_url;
		public string Nrq_of_token;

		public Config(IOrganizationService service, ITracingService tracingService, bool read_now = true) : base(service, tracingService, "nrq_configuration")
		{
			if (read_now == true)
			{
				QueryExpression queryExpression = new QueryExpression(Logical_name)
				{
					ColumnSet = new ColumnSet("nrq_of_url", "nrq_of_token"),
				};

				queryExpression.TopCount = 1;

				EntityCollection entityCollection = _service.RetrieveMultiple(queryExpression);

				CrmEntity = entityCollection.Entities.FirstOrDefault();

				Read_from_entity();

				if (Nrq_of_url.EndsWith("/") == false)
				{
					Nrq_of_url = Nrq_of_url + "/";
				}
			}
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("nrq_of_url", Nrq_of_url, parameters);
			Fill_if_not_empty("nrq_of_token", Nrq_of_token, parameters);
		}

		public override void Read_fields()
		{
			Nrq_of_url = Read_if_not_empty<string>("nrq_of_url");
			Nrq_of_token = Read_if_not_empty<string>("nrq_of_token");
		}
	}
}
