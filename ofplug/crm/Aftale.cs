using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class Aftale : AbstractCrm
	{
		public int? nrq_beloeb;
		public string nrq_betalingsform;
		public Contact nrq_bidragyder;
		public string nrq_frekvens;
		public DateTime? nrq_slutdato;
		public DateTime? nrq_startdato;
		public string nrq_type;
		//todo felter
		public int? of_id = 0;

		public Aftale(IOrganizationService service) : base(service, "nrq_bidragsaftale")
		{
		}

		public void Get_entity_by_of_id(IOrganizationService service, int id)
		{
			QueryExpression queryExpression = Create_query_expression("nrq_betalingsform", id.ToString(), new ColumnSet("nrq_bidragsaftaleid", "nrq_type"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_fields();
		}

		public void Get_by_of_id(int id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("nrq_betalingsform", id.ToString(), new ColumnSet("nrq_bidragsaftaleid", "nrq_type"));

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_fields();
		}

		public static List<Aftale> Get_all(IOrganizationService service)
		{
			QueryExpression queryExpression = new QueryExpression("nrq_bidragsaftale")
			{//todo felter
				ColumnSet = new ColumnSet("nrq_bidragsaftaleid", "nrq_type")
			};

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			List<Aftale> aftaler = new List<Aftale>();
			entities.Entities.ToList().ForEach(entity => aftaler.Add(new Aftale(service)
			{
				CrmEntity = entity,
			}));

			return aftaler;
		}

		public void Get_by_reference(EntityReference aftale_reference)
		{
			CrmEntity = _service.Retrieve(aftale_reference.LogicalName, aftale_reference.Id, new ColumnSet("nrq_of_id"));

			Read_fields();
		}

		public override void Fill_fields()
		{
			//todo felter

			Fill_if_not_empty("nrq_beloeb", nrq_beloeb);
			Fill_if_not_empty("nrq_betalingsform", nrq_betalingsform);
			Fill_if_not_empty("nrq_bidragyder", nrq_bidragyder);
			Fill_if_not_empty("nrq_frekvens", nrq_frekvens);
			Fill_if_not_empty("nrq_slutdato", nrq_slutdato);
			Fill_if_not_empty("nrq_startdato", nrq_startdato);
			Fill_if_not_empty("nrq_type", nrq_type);
			Fill_if_not_empty("of_id", of_id);
		}

		public override void Read_fields()
		{
			//todo felter

			Id = CrmEntity.Id;

			nrq_beloeb = Read_if_not_empty<int?>("nrq_beloeb");
			nrq_betalingsform = Read_if_not_empty<string>("nrq_betalingsform");
			nrq_bidragyder = Read_if_not_empty<Contact>("nrq_bidragyder");
			nrq_frekvens = Read_if_not_empty<string>("nrq_frekvens");
			nrq_slutdato = Read_if_not_empty<DateTime?>("nrq_slutdato");
			nrq_startdato = Read_if_not_empty<DateTime?>("nrq_startdato");
			nrq_type = Read_if_not_empty<string>("nrq_type");
			of_id = Read_if_not_empty<int?>("of_id");
		}
	}
}
