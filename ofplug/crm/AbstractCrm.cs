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
		protected ITracingService _tracingService;

		public string Logical_name { get; private set; }

		public AbstractCrm(IOrganizationService service, ITracingService tracingService, string logical_name)
		{
			_service = service;
			_tracingService = tracingService;

			Logical_name = logical_name;
		}

		public enum GendercodeEnum
		{
			Male = 1,
			Female = 2,
		}

		public GendercodeEnum? Gendercode_string_to_enum(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}

			if (value.ToLower() == "male")
			{
				return GendercodeEnum.Male;
			}

			if (value.ToLower() == "female")
			{
				return GendercodeEnum.Female;
			}

			return null;
		}

		public string Gendercode_enum_to_string(GendercodeEnum? value)
		{
			switch (value)
			{
				case GendercodeEnum.Male:
					return "male";
				case GendercodeEnum.Female:
					return "female";
				case null:
					return null;
				default:
					throw new Exception("unknown enum " + value);
			}
		}

		public GendercodeEnum? Gendercode_optionSet_to_enum(OptionSetValue value)
		{
			if (value == null)
			{
				return null;
			}

			return (GendercodeEnum)value.Value;
		}

		public OptionSetValue Gendercode_enum_to_optionSet(GendercodeEnum? value)
		{
			if (value == null)
			{
				return null;
			}

			return new OptionSetValue((int)value.Value);
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

			Id = _service.Create(CrmEntity);
		}

		public void Update()
		{
			CrmEntity = new Entity(Logical_name);

			Fill_fields();
			CrmEntity.Id = Id;

			_tracingService.Trace("ofplug " + Logical_name + " Update");

			_service.Update(CrmEntity);
		}

		public abstract void Fill_fields();
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

		protected void Fill_if_not_empty(string name, object value)
		{
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

			CrmEntity[name] = value;
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
