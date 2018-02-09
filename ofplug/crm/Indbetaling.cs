using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace ofplug.crm
{
	public class Indbetaling : AbstractCrm
	{
		public Indbetaling(IOrganizationService service) : base(service, "new_indbetaling")
		{
		}

		public void Get_by_of_id(int id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("new_of_payment_id", id.ToString(), new ColumnSet("new_indbetalingid"));

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();
		}

		public Entity Create()
		{
			Entity entity = new Entity(_logical_name);
			//todo felter
			entity[""] = "value";

			Id = _service.Create(entity);

			return entity;
		}

		public void Update()
		{
			_service.Update(CrmEntity);
		}
	}
}
