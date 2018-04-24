using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class Aftale : AbstractCrm
	{
		public string nrq_agreementstarttype;
		public SelectedDictionary nrq_amounttype = new SelectedDictionary { { 170590000, "donation" }, { 170590001, "purchase" } };
		public Money nrq_beloeb;
		public string nrq_betalingsform;
		public EntityReference nrq_bidragyder;
		public DateTime? nrq_chargedate;
		public SelectedDictionary nrq_frequency = new SelectedDictionary { { 170590000, "monthly" }, { 170590001, "hexannually" }, { 170590002, "quarterly" }, { 170590003, "triannually" }, { 170590004, "biannually" }, { 170590005, "yearly" } };
		public int? nrq_of_contact_id;
		public int? nrq_of_id;
		public int? nrq_of_project_id;
		public int? nrq_of_subscription_id;
		public SelectedDictionary nrq_paymentmedia = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "fi" }, { 170590002, "card" }, { 170590003, "sms_keyword" }, { 170590004, "phonebill" }, { 170590005, "mobilepay" } };
		public DateTime? nrq_slutdato;
		public DateTime? nrq_startdato;
		public string nrq_state;
		public EntityReference nrq_subscription;
		public string nrq_type;

		private static ColumnSet _columnSet = new ColumnSet
		(
			"nrq_agreementstarttype",
			"nrq_amounttype",
			"nrq_beloeb",
			"nrq_betalingsform",
			"nrq_bidragyder",
			"nrq_chargedate",
			"nrq_frequency",
			"nrq_of_contact_id",
			"nrq_of_id",
			"nrq_of_project_id",
			"nrq_of_subscription_id",
			"nrq_paymentmedia",
			"nrq_slutdato",
			"nrq_startdato",
			"nrq_state",
			"nrq_subscription",
			"nrq_type"
		);

		public Aftale(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "nrq_bidragsaftale")
		{
		}

		public void Get_by_of_id(int id)
		{
			QueryExpression queryExpression = Create_query_expression("nrq_of_id", id.ToString(), _columnSet);

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_from_entity();
		}

		public static List<Aftale> Get_all(IOrganizationService service, ITracingService tracingService)
		{
			QueryExpression queryExpression = new QueryExpression("nrq_bidragsaftale")
			{
				ColumnSet = _columnSet
			};

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			List<Aftale> aftaler = new List<Aftale>();
			entities.Entities.ToList().ForEach(entity => aftaler.Add(new Aftale(service, tracingService)
			{
				CrmEntity = entity,
			}));

			return aftaler;
		}

		public void Get_by_reference(EntityReference aftale_reference)
		{
			CrmEntity = _service.Retrieve(aftale_reference.LogicalName, aftale_reference.Id, _columnSet);

			Read_from_entity();
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("nrq_agreementstarttype", nrq_agreementstarttype, parameters);
			Fill_if_not_empty("nrq_amounttype", nrq_amounttype, parameters);
			Fill_if_not_empty("nrq_beloeb", nrq_beloeb, parameters);
			Fill_if_not_empty("nrq_betalingsform", nrq_betalingsform, parameters);
			Fill_if_not_empty("nrq_bidragyder", nrq_bidragyder, parameters);
			Fill_if_not_empty("nrq_chargedate", nrq_chargedate, parameters);
			Fill_if_not_empty("nrq_frequency", nrq_frequency, parameters);
			Fill_if_not_empty("nrq_of_contact_id", nrq_of_contact_id, parameters);
			Fill_if_not_empty("nrq_of_id", nrq_of_id, parameters);
			Fill_if_not_empty("nrq_of_project_id", nrq_of_project_id, parameters);
			Fill_if_not_empty("nrq_of_subscription_id", nrq_of_subscription_id, parameters);
			Fill_if_not_empty("nrq_paymentmedia", nrq_paymentmedia, parameters);
			Fill_if_not_empty("nrq_slutdato", nrq_slutdato, parameters);
			Fill_if_not_empty("nrq_startdato", nrq_startdato, parameters);
			Fill_if_not_empty("nrq_state", nrq_state, parameters);
			Fill_if_not_empty("nrq_subscription", nrq_subscription, parameters);
			Fill_if_not_empty("nrq_type", nrq_type, parameters);
		}

		public override void Read_fields()
		{
			nrq_agreementstarttype = Read_if_not_empty<string>("nrq_agreementstarttype");
			Read_if_not_empty(nrq_amounttype, "nrq_amounttype");
			nrq_beloeb = Read_if_not_empty<Money>("nrq_beloeb");
			nrq_betalingsform = Read_if_not_empty<string>("nrq_betalingsform");
			nrq_bidragyder = Read_if_not_empty<EntityReference>("nrq_bidragyder");
			nrq_chargedate = Read_if_not_empty<DateTime?>("nrq_chargedate");
			Read_if_not_empty(nrq_frequency, "nrq_frequency");
			nrq_of_contact_id = Read_if_not_empty<int?>("nrq_of_contact_id");
			nrq_of_id = Read_if_not_empty<int?>("nrq_of_id");
			nrq_of_project_id = Read_if_not_empty<int?>("nrq_of_project_id");
			nrq_of_subscription_id = Read_if_not_empty<int?>("nrq_of_subscription_id");
			Read_if_not_empty(nrq_paymentmedia, "nrq_paymentmedia");
			nrq_slutdato = Read_if_not_empty<DateTime?>("nrq_slutdato");
			nrq_startdato = Read_if_not_empty<DateTime?>("nrq_startdato");
			nrq_state = Read_if_not_empty<string>("nrq_state");
			nrq_subscription = Read_if_not_empty<EntityReference>("nrq_subscription");
			nrq_type = Read_if_not_empty<string>("nrq_type");
		}
	}
}
