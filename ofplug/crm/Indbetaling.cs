using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace ofplug.crm
{
	public class Indbetaling : AbstractCrm
	{
		public double? new_amount;
		public string new_bankid;
		//public string new_bankkildekode
		//public lookup new_byarbejdeid
		//public lookup new_campaignid
		//public lookup new_indbetalingid
		//public lookup new_indsamlingskoordinatorid
		//public OptionSet new_kilde
		//public lookup new_kontoid
		//public string new_name
		public DateTime? new_valdt;
		//public string nrq_bankensarkivreference;
		//public Currency nrq_beloebkredit;
		public string nrq_bilagsnr;
		//public Formålskode Lookup nrq_formaalskode;
		//public Customer nrq_indbetaler;
		//public int? nrq_indbetalingnr;
		//public Option Set nrq_indbetalingstatus;
		//public Lookup nrq_indbetalingstype;
		//public Lookup nrq_indsamlingssted;
		//public string nrq_kommentartilbogfring;
		public string nrq_linktilindbetaling;
		//public Lookup nrq_modkonto;
		//public string nrq_notat;
		//public DateTime? nrq_rentedato;
		//public Lookup nrq_sted;
		//public string nrq_stedkode;
		//public Option Set nrq_takkebrev;
		//public Two Options nrq_takkebrevsendt;
		public string nrq_tekst;
		//public Status statecode;

		public int? of_aftale_id;


		public Indbetaling(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "new_indbetaling")
		{
		}

		public void Get_by_of_id(int id)
		{
			QueryExpression queryExpression = Create_query_expression("new_of_payment_id", id.ToString(), new ColumnSet("new_indbetalingid"));

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_fields();
		}

		public override void Fill_fields()
		{
			//todo felter

			Fill_if_not_empty("new_amount", new_amount);
			Fill_if_not_empty("new_bankid", new_bankid);
			Fill_if_not_empty("new_valdt", new_valdt);
			Fill_if_not_empty("nrq_bilagsnr", nrq_bilagsnr);
			Fill_if_not_empty("nrq_linktilindbetaling", nrq_linktilindbetaling);
			Fill_if_not_empty("nrq_tekst", nrq_tekst);
		}

		public override void Read_fields()
		{
			//todo felter

			new_amount = Read_if_not_empty<double?>("new_amount");
			new_bankid = Read_if_not_empty<string>("new_bankid");
			new_valdt = Read_if_not_empty<DateTime?>("new_valdt");
			nrq_bilagsnr = Read_if_not_empty<string>("nrq_bilagsnr");
			nrq_linktilindbetaling = Read_if_not_empty<string>("nrq_linktilindbetaling");
			nrq_tekst = Read_if_not_empty<string>("nrq_tekst");
		}
	}
}
