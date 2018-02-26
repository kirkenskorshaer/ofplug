using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace ofplug.crm
{
	public class Contact : AbstractCrm
	{
		public string firstname;
		public int? new_ofcontactid;
		public string emailaddress1;
		public string new_cprnr;
		public string address1_line1;
		public string address1_postalcode;
		public string address1_city;
		public string address1_country;

		private OptionSetValue gendercode;
		public GendercodeEnum? Gendercode_value { get { return Gendercode_optionSet_to_enum(gendercode); } set { gendercode = Gendercode_enum_to_optionSet(value); } }
		public DateTime? birthdate;
		//dawa_id
		public double? address1_latitude;
		public double? address1_longitude;
		//valid_adr_ts
		public string lastname;
		//msisdn

		public Contact(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "contact")
		{
		}

		public void Get_contact_from_medlemsnr(IOrganizationService service, string medlemsnr)
		{
			QueryExpression queryExpression = Create_query_expression("new_KKAdminMedlemsNr", medlemsnr, new ColumnSet("contactid"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_from_entity();
		}

		public void Get_contact_from_of_contact_id(IOrganizationService service, int of_contact_id)
		{
			QueryExpression queryExpression = Create_query_expression("new_ofcontactid", of_contact_id.ToString(), new ColumnSet("contactid"));

			EntityCollection entities = service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_from_entity();
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, new ColumnSet("nrq_of_id"));

			Read_from_entity();
		}

		public void Get_contact_from_id(IOrganizationService service, Guid id)
		{
			CrmEntity = service.Retrieve("contact", id, new ColumnSet("contactid"));

			Read_from_entity();
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

			Read_from_entity();
		}

		public override void Fill_fields()
		{
			//todo felter

			Fill_if_not_empty("firstname", firstname);
			Fill_if_not_empty("new_ofcontactid", new_ofcontactid);
			Fill_if_not_empty("emailaddress1", emailaddress1);
			Fill_if_not_empty("new_cprnr", new_cprnr);
			Fill_if_not_empty("address1_line1", address1_line1);
			Fill_if_not_empty("address1_postalcode", address1_postalcode);
			Fill_if_not_empty("address1_city", address1_city);
			Fill_if_not_empty("address1_country", address1_country);
			Fill_if_not_empty("gendercode", gendercode);
			Fill_if_not_empty("birthdate", birthdate);
			Fill_if_not_empty("address1_latitude", address1_latitude);
			Fill_if_not_empty("address1_longitude", address1_longitude);
			Fill_if_not_empty("lastname", lastname);
		}

		public override void Read_fields()
		{
			//todo felter
			firstname = Read_if_not_empty<string>("firstname");
			new_ofcontactid = Read_if_not_empty<int?>("new_ofcontactid");
			emailaddress1 = Read_if_not_empty<string>("emailaddress1");
			new_cprnr = Read_if_not_empty<string>("new_cprnr");
			address1_line1 = Read_if_not_empty<string>("address1_line1");
			address1_postalcode = Read_if_not_empty<string>("address1_postalcode");
			address1_city = Read_if_not_empty<string>("address1_city");
			address1_country = Read_if_not_empty<string>("address1_country");
			Gendercode_value = Gendercode_string_to_enum(Read_if_not_empty<string>("gendercode"));
			birthdate = Read_if_not_empty<DateTime?>("birthdate");
			address1_latitude = Read_if_not_empty<double?>("address1_latitude");
			address1_longitude = Read_if_not_empty<double?>("address1_longitude");
			lastname = Read_if_not_empty<string>("lastname");
		}
	}
}
