using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using System.Collections.Generic;

namespace ofplug.crm
{
	public class Abonnement : AbstractCrm
	{
		public int? Nrq_of_contact_id;
		public string Nrq_order_id;
		public SelectedDictionary Nrq_state = new SelectedDictionary { { 170590000, "subscribe" }, { 170590001, "subscribing" }, { 170590002, "subscribed" }, { 170590003, "cancelled" } };
		public SelectedDictionary Nrq_PaymentGateway = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "epay" }, { 170590002, "linkm" }, { 170590003, "mobilepay_sub" }, { 170590004, "noop" } };
		public SelectedDictionary Nrq_PaymentMedia = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "fi" }, { 170590002, "card" }, { 170590003, "sms_keyword" }, { 170590004, "phonebill" }, { 170590005, "mobilepay" } };
		public string Nrq_bank_account_no;
		public string Nrq_bank_sort_code;
		public int? Nrq_of_id;
		public EntityReference Nrq_subscriber;

		private static ColumnSet _columnSet = new ColumnSet
		(
			"nrq_of_contact_id",
			"nrq_contact",
			"nrq_order_id",
			"nrq_state",
			"nrq_PaymentGateway",
			"nrq_PaymentMedia",
			"nrq_bank_account_no",
			"nrq_bank_sort_code",
			"nrq_of_id"
		);

		public Abonnement(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "nrq_subscription")//todo nrq entity name
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
			Fill_if_not_empty("nrq_of_contact_id", Nrq_of_contact_id, parameters);
			Fill_if_not_empty("nrq_subscriber", Nrq_subscriber, parameters);
			Fill_if_not_empty("nrq_order_id", Nrq_order_id, parameters);
			Fill_if_not_empty("nrq_state", Nrq_state, parameters);
			Fill_if_not_empty("nrq_PaymentGateway", Nrq_PaymentGateway, parameters);
			Fill_if_not_empty("nrq_PaymentMedia", Nrq_PaymentMedia, parameters);
			Fill_if_not_empty("nrq_bank_account_no", Nrq_bank_account_no, parameters);
			Fill_if_not_empty("nrq_bank_sort_code", Nrq_bank_sort_code, parameters);
			Fill_if_not_empty("nrq_of_id", Nrq_of_id, parameters);
		}

		public override void Read_fields()
		{
			Nrq_of_contact_id = Read_if_not_empty<int?>("nrq_of_contact_id");
			Nrq_subscriber = Read_if_not_empty<EntityReference>("nrq_subscriber");
			Nrq_order_id = Read_if_not_empty<string>("nrq_order_id");
			Read_if_not_empty(Nrq_state, "nrq_state");
			Read_if_not_empty(Nrq_PaymentGateway, "nrq_PaymentGateway");
			Read_if_not_empty(Nrq_PaymentMedia, "nrq_PaymentMedia");
			Nrq_bank_account_no = Read_if_not_empty<string>("nrq_bank_account_no");
			Nrq_bank_sort_code = Read_if_not_empty<string>("nrq_bank_sort_code");
			Nrq_of_id = Read_if_not_empty<int?>("nrq_of_id");
		}
	}
}
