using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace ofplug.crm
{
	public class Contact : AbstractCrm
	{
		public string firstname;
		internal int of_id;

		public Contact(IOrganizationService service) : base(service, "contact")
		{
		}

		public void Get_contact_from_medlemsnr(IOrganizationService service, string medlemsnr)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("new_KKAdminMedlemsNr", medlemsnr, new ColumnSet("contactid"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();
		}

		public void Get_contact_from_of_contact_id(IOrganizationService service, int of_contact_id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("new_ofcontactid", of_contact_id.ToString(), new ColumnSet("contactid"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();
		}

		public void Get_by_reference(EntityReference entityReference)
		{//todo felter
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, new ColumnSet("nrq_of_id"));

			int.TryParse(CrmEntity["nrq_of_id"].ToString(), out int of_id);
		}

		public void Get_by_of_id(IOrganizationService service, int of_contact_id)
		{//todo felter
			throw new NotImplementedException();
		}

		public void Get_contact_from_id(IOrganizationService service, Guid id)
		{//todo felter
			CrmEntity = service.Retrieve("contact", id, new ColumnSet("contactid"));
		}

		public void Get_contact(IOrganizationService service, int? medlemsnr, int of_contact_id, string email)
		{//todo felter
			if (medlemsnr != null)
			{
				Get_contact_from_medlemsnr(service, medlemsnr.Value.ToString());

				if (CrmEntity != null)
				{
					return;
				}
			}

			Get_contact_from_of_contact_id(service, of_contact_id);
			if (CrmEntity != null)
			{
				return;
			}

			Get_contact_from_basis_information(service, email);
		}

		public void Get_contact_from_basis_information(IOrganizationService service, string email)
		{
			ConditionExpression emailCondition = new ConditionExpression()
			{
				AttributeName = "emailaddress1",
				Operator = ConditionOperator.Equal
			};
			//todo felter
			emailCondition.Values.Add(email);

			FilterExpression filterExpression = new FilterExpression();
			filterExpression.AddCondition(emailCondition);

			QueryExpression queryExpression = new QueryExpression("contact")
			{
				ColumnSet = new ColumnSet("contactid")
			};

			queryExpression.Criteria.AddFilter(filterExpression);

			EntityCollection entityCollection = service.RetrieveMultiple(queryExpression);

			CrmEntity = entityCollection.Entities.FirstOrDefault();
		}

		public Entity Create()
		{
			Entity entity = new Entity(_logical_name);
			//todo felter
			entity["firstname"] = firstname;

			Id = _service.Create(entity);

			return entity;
		}

		public void Update()
		{
			_service.Update(CrmEntity);
		}
	}
}
