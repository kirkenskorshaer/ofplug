using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public abstract class AbstractCrm
	{
		public Guid Id;
		public Entity CrmEntity;
		protected IOrganizationService _service;
		protected ITracingService _tracingService;

		public string Logical_name { get; private set; }

		public AbstractCrm(IOrganizationService service, ITracingService tracingService, string logical_name)
		{
			_service = service;
			_tracingService = tracingService;

			Logical_name = logical_name;
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

			QueryExpression queryExpression = new QueryExpression(Logical_name)
			{
				ColumnSet = coulmnSet
			};

			queryExpression.Criteria.AddFilter(filterExpression);

			return queryExpression;
		}

		public void Create()
		{
			CrmEntity = new Entity(Logical_name);

			Fill_fields();

			_tracingService.Trace("ofplug " + Logical_name + " Create");

			string trace = "Create " + GetFieldsString();
			_tracingService.Trace(trace);

			Id = _service.Create(CrmEntity);
		}

		public void Update(List<string> parameters = null)
		{
			CrmEntity = new Entity(Logical_name);

			Fill_fields(parameters);
			CrmEntity.Id = Id;

			_tracingService.Trace("ofplug " + Logical_name + " Update");

			string trace = "Update " + GetFieldsString();
			_tracingService.Trace(trace);

			_service.Update(CrmEntity);
		}

		private string GetFieldsString()
		{
			return CrmEntity.Attributes.Aggregate(" ", (collect, attribute) => collect + " " + attribute.Key + " = " + Get_attribute_string_value(attribute.Value));
		}

		private string Get_attribute_string_value(object value)
		{
			if (value.GetType() == typeof(OptionSetValue))
			{
				return ((OptionSetValue)value).Value.ToString();
			}
			return value.ToString();
		}

		public abstract void Fill_fields(List<string> parameters = null);
		public abstract void Read_fields();

		public EntityReference Get_entity_reference()
		{
			return new EntityReference(Logical_name, Id);
		}

		protected void Read_from_entity()
		{
			if (CrmEntity == null)
			{
				return;
			}

			Id = CrmEntity.Id;

			Read_fields();
		}

		protected void Fill_if_not_empty(string name, object value, List<string> parameters)
		{
			if (parameters != null && parameters.Contains(name) == false)
			{
				return;
			}

			if (value == null)
			{
				return;
			}

			if (value.GetType() == typeof(int?))
			{
				CrmEntity[name] = ((int?)value).Value;
				return;
			}

			if (value.GetType() == typeof(float?))
			{
				CrmEntity[name] = ((float?)value).Value;
				return;
			}

			if (value.GetType() == typeof(double?))
			{
				CrmEntity[name] = ((double?)value).Value;
				return;
			}

			if (value.GetType() == typeof(SelectedDictionary))
			{
				SelectedDictionary dictionary = (SelectedDictionary)value;
				if (dictionary.SelectedKey.HasValue == false)
				{
					return;
				}

				CrmEntity[name] = new OptionSetValue(dictionary.SelectedKey.Value);
				return;
			}

			CrmEntity[name] = value;
		}

		protected void Read_if_not_empty(SelectedDictionary selectedDictionary, string name)
		{
			if (CrmEntity.Contains(name))
			{
				OptionSetValue value = (OptionSetValue)CrmEntity[name];
				selectedDictionary.Select(value.Value);
				return;
			}
			else
			{
				_tracingService.Trace($"Read_if_not_empty didn't find :{name}");
			}
		}

		protected output Read_if_not_empty<output>(string name)
		{
			if (CrmEntity.Contains(name))
			{
				return (output)CrmEntity[name];
			}

			return default(output);
		}
	}
}
