using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.crm
{
	public class Indbetaling : AbstractCrm
	{
		public int? Nrq_of_id;
		public Money New_amount;
		public SelectedDictionary Nrq_amountType = new SelectedDictionary { { 170590000, "donation" }, { 170590001, "purchase" } };
		public string Nrq_FeeAmount;
		public DateTime? Nrq_PaymentDueDate;
		public DateTime? Nrq_paymentDate;
		public DateTime? nrq_BookkeepingDate;
		public DateTime? Nrq_ChargebackDate;
		public SelectedDictionary Nrq_PaymentGateway = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "epay" }, { 170590002, "linkm" }, { 170590003, "mobilepay_sub" }, { 170590004, "noop" } };
		public SelectedDictionary Nrq_PaymentMedia = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "fi" }, { 170590002, "card" }, { 170590003, "sms_keyword" }, { 170590004, "phonebill" }, { 170590005, "mobilepay" } };
		public SelectedDictionary Nrq_PaymentType = new SelectedDictionary { { 170590000, "single" }, { 170590001, "recurring" } };
		public int? Nrq_of_contact_id;
		public int? Nrq_of_agreement_id;
		public int? Nrq_of_fundraising_project_id;
		public string Nrq_tekst;
		public EntityReference Nrq_indbetaler;

		private static ColumnSet _columnSet = new ColumnSet
		(
			"nrq_of_id",
			"new_amount",
			"nrq_amounttype",
			"nrq_feeamount",
			"nrq_paymentduedate",
			"nrq_paymentdate",
			"nrq_bookkeepingdate",
			"nrq_chargebackdate",
			"nrq_paymentgateway",
			"nrq_paymentmedia",
			"nrq_paymenttype",
			"nrq_of_contact_id",
			"nrq_of_agreement_id",
			"nrq_of_fundraising_project_id",
			"nrq_indbetaler"
		);

		public Indbetaling(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "new_indbetaling")
		{
		}

		public void Get_by_of_id(int id)
		{
			QueryExpression queryExpression = Create_query_expression("nrq_of_id", id.ToString(), _columnSet);

			EntityCollection entities = _service.RetrieveMultiple(queryExpression);

			CrmEntity = entities.Entities.FirstOrDefault();

			Read_from_entity();
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, _columnSet);

			Read_from_entity();
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("nrq_of_id", Nrq_of_id, parameters);
			Fill_if_not_empty("new_amount", New_amount, parameters);
			Fill_if_not_empty("nrq_amounttype", Nrq_amountType, parameters);
			Fill_if_not_empty("nrq_feeamount", Nrq_FeeAmount, parameters);
			Fill_if_not_empty("nrq_paymentduedate", Nrq_PaymentDueDate, parameters);
			Fill_if_not_empty("nrq_paymentdate", Nrq_paymentDate, parameters);
			Fill_if_not_empty("nrq_bookkeepingdate", nrq_BookkeepingDate, parameters);
			Fill_if_not_empty("nrq_chargebackdate", Nrq_ChargebackDate, parameters);
			Fill_if_not_empty("nrq_paymentgateway", Nrq_PaymentGateway, parameters);
			Fill_if_not_empty("nrq_paymentmedia", Nrq_PaymentMedia, parameters);
			Fill_if_not_empty("nrq_paymenttype", Nrq_PaymentType, parameters);
			Fill_if_not_empty("nrq_of_contact_id", Nrq_of_contact_id, parameters);
			Fill_if_not_empty("nrq_of_agreement_id", Nrq_of_agreement_id, parameters);
			Fill_if_not_empty("nrq_of_fundraising_project_id", Nrq_of_fundraising_project_id, parameters);
			Fill_if_not_empty("nrq_indbetaler", Nrq_indbetaler, parameters);
		}

		public override void Read_fields()
		{
			Nrq_of_id = Read_if_not_empty<int?>("nrq_of_id");
			New_amount = Read_if_not_empty<Money>("new_amount");
			Read_if_not_empty(Nrq_amountType, "nrq_amounttype");
			Nrq_FeeAmount = Read_if_not_empty<string>("nrq_feeamount");
			Nrq_PaymentDueDate = Read_if_not_empty<DateTime?>("nrq_paymentduedate");
			Nrq_paymentDate = Read_if_not_empty<DateTime?>("nrq_paymentdate");
			nrq_BookkeepingDate = Read_if_not_empty<DateTime?>("nrq_bookkeepingdate");
			Nrq_ChargebackDate = Read_if_not_empty<DateTime?>("nrq_chargebackdate");
			Read_if_not_empty(Nrq_PaymentGateway, "nrq_paymentgateway");
			Read_if_not_empty(Nrq_PaymentMedia, "nrq_paymentmedia");
			Read_if_not_empty(Nrq_PaymentType, "nrq_paymenttype");
			Nrq_of_contact_id = Read_if_not_empty<int?>("nrq_of_contact_id");
			Nrq_of_agreement_id = Read_if_not_empty<int?>("nrq_of_agreement_id");
			Nrq_of_fundraising_project_id = Read_if_not_empty<int?>("nrq_of_fundraising_project_id");
			Nrq_indbetaler = Read_if_not_empty<EntityReference>("nrq_indbetaler");
		}
	}
}
