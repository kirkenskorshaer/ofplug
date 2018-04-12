using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace ofplug.crm
{
	public class AgreementRequest : AbstractCrm
	{
		public Money Nrq_amount;
		public int? Nrq_bankaccountno;
		public int? Nrq_banksortcode;
		public EntityReference Nrq_customer;
		public SelectedDictionary Nrq_frequency = new SelectedDictionary { { 170590000, "monthly" }, { 170590001, "hexannually" }, { 170590002, "quarterly" }, { 170590003, "triannually" }, { 170590004, "biannually" }, { 170590005, "yearly" } };
		public SelectedDictionary Nrq_paymentmedia = new SelectedDictionary { { 170590000, "pbs" }, { 170590001, "fi" }, { 170590002, "card" }, { 170590003, "sms" }, { 170590004, "keyword" }, { 170590005, "phonebill" }, { 170590006, "mobilepay" } };
		//public int? Nrq_projectid;
		public string Nrq_projectid;
		public SelectedDictionary Nrq_processstatus = new SelectedDictionary { { 170590000, "Draft" }, { 170590001, "Ready" }, { 170590002, "Processed" } };

		public string External_id = null;
		public Contact customer_contact = null;
		public Account customer_account = null;

		public string Nrq_name { get { return customer_account?.Name; } }
		public string Nrq_firstname { get { return customer_contact?.firstname; } }
		public string Nrq_middlename { get { return customer_contact?.middlename; } }
		public string Nrq_lastname { get { return customer_contact?.lastname; } }
		public string Nrq_address_line { get { return customer_contact?.address1_line1 ?? customer_account?.Address1_line1; } }
		public string Nrq_address_postalcode { get { return customer_contact?.address1_postalcode ?? customer_account?.Address1_postalcode; } }
		public string Nrq_address_city { get { return customer_contact?.address1_city ?? customer_account?.Address1_city; } }
		public string Nrq_address_country { get { return customer_contact?.address1_country ?? customer_account?.Address1_country; } }
		public string Nrq_emailaddress { get { return customer_contact?.emailaddress1 ?? customer_account?.Emailaddress1; } }
		public string Nrq_cprnr { get { return customer_contact?.new_cprnr; } }
		public string Nrq_cvrnr { get { return customer_account?.Nrq_cvrnr; } }
		public string Nrq_msisdn { get { return customer_contact?.mobilephone ?? customer_account?.Nrq_msisdn; } }

		private static ColumnSet _columnSet = new ColumnSet
		(
			"nrq_agreement_requestid",
			"nrq_amount",
			"nrq_bankaccountno",
			"nrq_banksortcode",
			"nrq_customer",
			"nrq_frequency",
			"nrq_paymentmedia",
			"nrq_projectid",
			"nrq_processstatus"
		);

		public AgreementRequest(IOrganizationService service, ITracingService tracingService) : base(service, tracingService, "nrq_agreement_request")
		{
		}

		private void Read_customer()
		{
			if (Nrq_customer == null)
			{
				return;
			}

			if (Nrq_customer.LogicalName == "contact")
			{
				customer_contact = new Contact(_service, _tracingService);
				customer_contact.Get_by_reference(Nrq_customer);
			}
			else if (Nrq_customer.LogicalName == "account")
			{
				customer_account = new Account(_service, _tracingService);
				customer_account.Get_by_reference(Nrq_customer);
			}
		}

		public void Get_by_reference(EntityReference entityReference)
		{
			CrmEntity = _service.Retrieve(entityReference.LogicalName, entityReference.Id, _columnSet);

			Read_from_entity();
		}

		public override void Fill_fields(List<string> parameters = null)
		{
			Fill_if_not_empty("nrq_amount", Nrq_amount, parameters);
			Fill_if_not_empty("nrq_bankaccountno", Nrq_bankaccountno, parameters);
			Fill_if_not_empty("nrq_banksortcode", Nrq_banksortcode, parameters);
			Fill_if_not_empty("nrq_customer", Nrq_customer, parameters);
			Fill_if_not_empty("nrq_frequency", Nrq_frequency, parameters);
			Fill_if_not_empty("nrq_paymentmedia", Nrq_paymentmedia, parameters);
			Fill_if_not_empty("nrq_projectid", Nrq_projectid, parameters);
			Fill_if_not_empty("nrq_processstatus", Nrq_processstatus, parameters);
		}

		public override void Read_fields()
		{
			Nrq_amount = Read_if_not_empty<Money>("nrq_amount");
			Nrq_bankaccountno = Read_if_not_empty<int?>("nrq_bankaccountno");
			Nrq_banksortcode = Read_if_not_empty<int?>("nrq_banksortcode");
			Nrq_customer = Read_if_not_empty<EntityReference>("nrq_customer");
			Read_if_not_empty(Nrq_frequency, "nrq_frequency");
			Read_if_not_empty(Nrq_paymentmedia, "nrq_paymentmedia");
			//Nrq_projectid = Read_if_not_empty<int?>("nrq_projectid");
			Nrq_projectid = Read_if_not_empty<string>("nrq_projectid");
			Read_if_not_empty(Nrq_processstatus, "nrq_processstatus");

			Read_customer();
		}
	}
}
