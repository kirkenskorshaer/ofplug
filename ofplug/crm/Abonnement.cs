﻿using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using System.Collections.Generic;

namespace ofplug.crm
{
	public class Abonnement : AbstractCrm
	{
		public string Nrq_status;
		public int? Nrq_Subscription_customer_no;
		public Guid? Nrq_Bse_guid;
		public int? Nrq_of_contact_id;
		public EntityReference Nrq_contact;
		public string Nrq_order_id;
		public string Nrq_state;
		public string Nrq_payment_gateway;
		public string Nrq_payment_media;
		public string Nrq_payment_media_type;
		public string Nrq_msisdn;
		public string Nrq_bank_account_no;
		public string Nrq_bank_sort_code;
		public int? Nrq_of_subscription_id;

		private static ColumnSet _columnSet = new ColumnSet
		(//todo felter
			"nrq_of_subscription_id"
		);

		public Abonnement(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "Abonnement")//todo nrq entity name
		{
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, _columnSet);

			Read_from_entity();
		}

		public void Get_by_of_id(int id)
		{//todo felter
			QueryExpression queryExpression = Create_query_expression("Nrq_of_subscription_id", id.ToString(), _columnSet);

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_from_entity();
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("nrq_status", Nrq_status, parameters);
			Fill_if_not_empty("nrq_Subscription_customer_no", Nrq_Subscription_customer_no, parameters);
			Fill_if_not_empty("nrq_Bse_guid", Nrq_Bse_guid, parameters);
			Fill_if_not_empty("nrq_of_contact_id", Nrq_of_contact_id, parameters);
			Fill_if_not_empty("nrq_order_id", Nrq_order_id, parameters);
			Fill_if_not_empty("nrq_state", Nrq_state, parameters);
			Fill_if_not_empty("nrq_contact", Nrq_contact, parameters);
			Fill_if_not_empty("nrq_payment_gateway", Nrq_payment_gateway, parameters);
			Fill_if_not_empty("nrq_payment_media", Nrq_payment_media, parameters);
			Fill_if_not_empty("nrq_payment_media_type", Nrq_payment_media_type, parameters);
			Fill_if_not_empty("nrq_msisdn", Nrq_msisdn, parameters);
			Fill_if_not_empty("nrq_bank_account_no", Nrq_bank_account_no, parameters);
			Fill_if_not_empty("nrq_bank_sort_code", Nrq_bank_sort_code, parameters);
		}

		public override void Read_fields()
		{
			Nrq_status = Read_if_not_empty<string>("nrq_status");
			Nrq_Subscription_customer_no = Read_if_not_empty<int?>("nrq_Subscription_customer_no");
			Nrq_Bse_guid = Read_if_not_empty<Guid?>("nrq_Bse_guid");
			Nrq_of_contact_id = Read_if_not_empty<int?>("nrq_of_contact_id");
			Nrq_order_id = Read_if_not_empty<string>("nrq_order_id");
			Nrq_state = Read_if_not_empty<string>("nrq_state");
			Nrq_contact = Read_if_not_empty<EntityReference>("nrq_contact");
			Nrq_payment_gateway = Read_if_not_empty<string>("nrq_payment_gateway");
			Nrq_payment_media = Read_if_not_empty<string>("nrq_payment_media");
			Nrq_payment_media_type = Read_if_not_empty<string>("nrq_payment_media_type");
			Nrq_msisdn = Read_if_not_empty<string>("nrq_msisdn");
			Nrq_bank_account_no = Read_if_not_empty<string>("nrq_bank_account_no");
			Nrq_bank_sort_code = Read_if_not_empty<string>("nrq_bank_sort_code");
		}
	}
}
