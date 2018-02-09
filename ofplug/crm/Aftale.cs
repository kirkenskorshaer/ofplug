using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class Aftale : AbstractCrm
	{
		public int nrq_beloeb;
		public string nrq_betalingsform;
		public string nrq_bidragyder;
		public string nrq_frekvens;
		public DateTime nrq_slutdato;
		public DateTime nrq_startdato;
		public string nrq_type;
		//todo felter
		public int of_id = 0;

		public Aftale(IOrganizationService service) : base(service, "nrq_bidragsaftale")
		{
		}

		public void Get_entity_by_of_id(IOrganizationService service, int id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("nrq_betalingsform", id.ToString(), new ColumnSet("nrq_bidragsaftaleid", "nrq_type"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();
		}

		public void Get_by_of_id(int id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("nrq_betalingsform", id.ToString(), new ColumnSet("nrq_bidragsaftaleid", "nrq_type"));

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();
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

		public void Create(Contact contact)
		{
			Entity entity = new Entity(_logical_name);
			//todo felter
			entity["nrq_beloeb"] = nrq_beloeb;
			entity["nrq_betalingsform"] = nrq_betalingsform;
			entity["nrq_bidragyder"] = contact;
			entity["nrq_frekvens"] = nrq_frekvens;
			entity["nrq_slutdato"] = nrq_slutdato;
			entity["nrq_startdato"] = nrq_startdato;
			entity["nrq_type"] = nrq_type;

			Id = _service.Create(entity);
			CrmEntity = entity;
		}

		public void Get_by_reference(EntityReference aftale_reference)
		{//todo felter
			CrmEntity = _service.Retrieve(aftale_reference.LogicalName, aftale_reference.Id, new ColumnSet("nrq_of_id"));

			int.TryParse(CrmEntity["nrq_of_id"].ToString(), out int of_id);
		}

		public void Update()
		{
			_service.Update(CrmEntity);
		}
	}
}
