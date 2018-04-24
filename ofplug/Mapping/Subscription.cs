using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Subscription
	{
		//todo felter
		public static void To_of(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			of_subscription.Bank_account_no = crm_abonnement.Nrq_bank_account_no;
			of_subscription.Bank_sort_code = crm_abonnement.Nrq_bank_sort_code;
			of_subscription.Contact_id = crm_abonnement.Nrq_of_contact_id;
			of_subscription.Of_id = crm_abonnement.Nrq_of_id;
			//of_subscription.Order_id = crm_abonnement.Nrq_order_id;
			of_subscription.Payment_gateway = crm_abonnement.Nrq_PaymentGateway.SelectedValue;
			of_subscription.Payment_media = crm_abonnement.Nrq_PaymentMedia.SelectedValue;
			//of_subscription.Payment_media_type = crm_abonnement.;
			//of_subscription.State = crm_abonnement.Nrq_state;
			//of_subscription.Status = crm_abonnement.Nrq_status;
			//of_subscription.Subscription_customer_no = crm_abonnement.Nrq_Subscription_customer_no;
			of_subscription.Crm_id = crm_abonnement.Id.ToString().ToLower();
		}

		public static void To_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			crm_abonnement.Nrq_bank_account_no = of_subscription.Bank_account_no;
			crm_abonnement.Nrq_bank_sort_code = of_subscription.Bank_sort_code;
			//crm_abonnement.Nrq_Bse_guid = of_subscription.Bse_guid;
			crm_abonnement.Nrq_of_contact_id = of_subscription.Contact_id;
			//crm_abonnement.Nrq_msisdn = of_subscription.Msisdn;
			crm_abonnement.Nrq_of_id = of_subscription.Of_id;
			//crm_abonnement.Nrq_order_id = of_subscription.Order_id;
			crm_abonnement.Nrq_PaymentGateway.Select(of_subscription.Payment_gateway);
			crm_abonnement.Nrq_PaymentMedia.Select(of_subscription.Payment_media);
			//crm_abonnement.Nrq_payment_media_type = of_subscription.Payment_media_type;
			crm_abonnement.Nrq_state.Select(of_subscription.State);
			//crm_abonnement.Nrq_status = of_subscription.Status;
			//crm_abonnement.Nrq_Subscription_customer_no = of_subscription.Subscription_customer_no;
		}

		public static List<string> Needs_update_in_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "nrq_bank_account_no", crm_abonnement.Nrq_bank_account_no, of_subscription.Bank_account_no);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_bank_sort_code", crm_abonnement.Nrq_bank_sort_code, of_subscription.Bank_sort_code);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_Bse_guid", crm_abonnement.Nrq_Bse_guid, of_subscription.Bse_guid);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_contact_id", crm_abonnement.Nrq_of_contact_id, of_subscription.Contact_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_msisdn", crm_abonnement.Nrq_msisdn, of_subscription.Msisdn);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_subscription_id", crm_abonnement.Nrq_of_id, of_subscription.Of_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_order_id", crm_abonnement.Nrq_order_id, of_subscription.Order_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_payment_gateway", crm_abonnement.Nrq_PaymentGateway.SelectedValue, of_subscription.Payment_gateway);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_payment_media", crm_abonnement.Nrq_PaymentMedia.SelectedValue, of_subscription.Payment_media);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_payment_media_type", crm_abonnement.Nrq_payment_media_type, of_subscription.Payment_media_type);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_state", crm_abonnement.Nrq_state, of_subscription.State);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_status", crm_abonnement.Nrq_status, of_subscription.Status);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_Subscription_customer_no", crm_abonnement.Nrq_Subscription_customer_no, of_subscription.Subscription_customer_no);

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "Bank_account_no", crm_abonnement.Nrq_bank_account_no, of_subscription.Bank_account_no);
			Mapping_update_helper.Add_if_unequal(parameters, "Bank_sort_code", crm_abonnement.Nrq_bank_sort_code, of_subscription.Bank_sort_code);
			//Mapping_update_helper.Add_if_unequal(parameters, "Bse_guid", crm_abonnement.Nrq_Bse_guid, of_subscription.Bse_guid);
			Mapping_update_helper.Add_if_unequal(parameters, "Contact_id", crm_abonnement.Nrq_of_contact_id, of_subscription.Contact_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "Msisdn", crm_abonnement.Nrq_msisdn, of_subscription.Msisdn);
			Mapping_update_helper.Add_if_unequal(parameters, "Crm_id", crm_abonnement.Id.ToString().ToLower(), of_subscription.Crm_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "Order_id", crm_abonnement.Nrq_order_id, of_subscription.Order_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_gateway", crm_abonnement.Nrq_PaymentGateway.SelectedValue, of_subscription.Payment_gateway);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_media", crm_abonnement.Nrq_PaymentMedia.SelectedValue, of_subscription.Payment_media);
			//Mapping_update_helper.Add_if_unequal(parameters, "Payment_media_type", crm_abonnement.Nrq_payment_media_type, of_subscription.Payment_media_type);
			//Mapping_update_helper.Add_if_unequal(parameters, "State", crm_abonnement.Nrq_state, of_subscription.State);
			//Mapping_update_helper.Add_if_unequal(parameters, "Status", crm_abonnement.Nrq_status, of_subscription.Status);
			//Mapping_update_helper.Add_if_unequal(parameters, "Subscription_customer_no", crm_abonnement.Nrq_Subscription_customer_no, of_subscription.Subscription_customer_no);

			return parameters;
		}
	}
}
