using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace ofplug.crm
{
	public abstract class AbstractCrm
	{
		public Guid Id;
		public Entity CrmEntity;
		protected IOrganizationService _service;
		protected string _logical_name;
		private IOrganizationService service;

		public AbstractCrm(IOrganizationService service, string logical_name)
		{
			_service = service;
			_logical_name = logical_name;
		}

		protected QueryExpression Create_query_expression(string attribute_name, object value, ColumnSet coulmnSet)
		{
			ConditionExpression conditionExpression = new ConditionExpression()
			{
				AttributeName = attribute_name,
				Operator = ConditionOperator.Equal
			};

			conditionExpression.Values.Add(value);

			FilterExpression filterExpression = new FilterExpression();
			filterExpression.AddCondition(conditionExpression);

			QueryExpression queryExpression = new QueryExpression(_logical_name)
			{
				ColumnSet = coulmnSet
			};

			queryExpression.Criteria.AddFilter(filterExpression);

			return queryExpression;
		}
	}
}
