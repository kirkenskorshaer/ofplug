using Microsoft.Xrm.Sdk;
using System;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace ofplug_test.Mock
{
	public class OrganizationServiceMock : IOrganizationService
	{
		public List<KeyValuePair<Operation, object>> Log = new List<KeyValuePair<Operation, object>>();
		public Queue<List<Entity>> entitiesToReturn = new Queue<List<Entity>>();

		public enum Operation
		{
			Associate = 1,
			Create = 2,
			Delete = 3,
			Disassociate = 4,
			Execute = 5,
			Retrieve = 6,
			RetrieveMultiple = 7,
			Update = 8
		}

		public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
		{
			throw new NotImplementedException();
		}

		public Guid Create(Entity entity)
		{
			Log.Add(new KeyValuePair<Operation, object>(Operation.Create, entity));

			return Guid.Empty;
		}

		public void Delete(string entityName, Guid id)
		{
			Log.Add(new KeyValuePair<Operation, object>(Operation.Delete, entityName));
		}

		public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
		{
			Log.Add(new KeyValuePair<Operation, object>(Operation.Disassociate, entityName));
		}

		public OrganizationResponse Execute(OrganizationRequest request)
		{
			Log.Add(new KeyValuePair<Operation, object>(Operation.Execute, request));
			return new OrganizationResponse();
		}

		public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
		{
			Entity entity = entitiesToReturn.Dequeue()[0];

			Log.Add(new KeyValuePair<Operation, object>(Operation.Retrieve, entity));

			return entity;
		}

		public EntityCollection RetrieveMultiple(QueryBase query)
		{
			List<Entity> entities = entitiesToReturn.Dequeue();

			Log.Add(new KeyValuePair<Operation, object>(Operation.RetrieveMultiple, query));

			return new EntityCollection(entities);
		}

		public void Update(Entity entity)
		{
			Log.Add(new KeyValuePair<Operation, object>(Operation.Update, entity));
		}
	}
}
