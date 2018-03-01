using Microsoft.Xrm.Sdk;
using System;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class OrganizationServiceMock : IOrganizationService
	{
		public List<KeyValuePair<string, object>> Log = new List<KeyValuePair<string, object>>();
		public Queue<List<Entity>> entitiesToReturn = new Queue<List<Entity>>();

		public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
		{
			throw new NotImplementedException();
		}

		public Guid Create(Entity entity)
		{
			Log.Add(new KeyValuePair<string, object>("Create", entity));

			return Guid.Empty;
		}

		public void Delete(string entityName, Guid id)
		{
			throw new NotImplementedException();
		}

		public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
		{
			throw new NotImplementedException();
		}

		public OrganizationResponse Execute(OrganizationRequest request)
		{
			throw new NotImplementedException();
		}

		public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
		{
			throw new NotImplementedException();
		}

		public EntityCollection RetrieveMultiple(QueryBase query)
		{
			List<Entity> entities = entitiesToReturn.Dequeue();
			return new EntityCollection(entities);
		}

		public void Update(Entity entity)
		{
			Log.Add(new KeyValuePair<string, object>("Update", entity));
		}
	}
}
