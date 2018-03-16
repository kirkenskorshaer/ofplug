namespace ofplug.Mapping
{
	public static class Subscription
	{
		//todo felter
		public static void To_of(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			of_subscription.Bank_account_no = crm_abonnement.Nrq_bank_account_no;
			of_subscription.Bank_sort_code = crm_abonnement.Nrq_bank_sort_code;
			of_subscription.Bse_guid = crm_abonnement.Nrq_Bse_guid;
			of_subscription.Contact_id = crm_abonnement.Nrq_of_contact_id;
			of_subscription.Msisdn = crm_abonnement.Nrq_msisdn;
			of_subscription.Of_id = crm_abonnement.Nrq_of_subscription_id;
			of_subscription.Order_id = crm_abonnement.Nrq_order_id;
			of_subscription.Payment_gateway = crm_abonnement.Nrq_payment_gateway;
			of_subscription.Payment_media = crm_abonnement.Nrq_payment_media;
			of_subscription.Payment_media_type = crm_abonnement.Nrq_payment_media_type;
			of_subscription.State = crm_abonnement.Nrq_state;
			of_subscription.Status = crm_abonnement.Nrq_status;
			of_subscription.Subscription_customer_no = crm_abonnement.Nrq_Subscription_customer_no;
			of_subscription.Crm_id = crm_abonnement.Id.ToString().ToLower();
		}

		public static void To_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			crm_abonnement.Nrq_bank_account_no = of_subscription.Bank_account_no;
			crm_abonnement.Nrq_bank_sort_code = of_subscription.Bank_sort_code;
			crm_abonnement.Nrq_Bse_guid = of_subscription.Bse_guid;
			crm_abonnement.Nrq_of_contact_id = of_subscription.Contact_id;
			crm_abonnement.Nrq_msisdn = of_subscription.Msisdn;
			crm_abonnement.Nrq_of_subscription_id = of_subscription.Of_id;
			crm_abonnement.Nrq_order_id = of_subscription.Order_id;
			crm_abonnement.Nrq_payment_gateway = of_subscription.Payment_gateway;
			crm_abonnement.Nrq_payment_media = of_subscription.Payment_media;
			crm_abonnement.Nrq_payment_media_type = of_subscription.Payment_media_type;
			crm_abonnement.Nrq_state = of_subscription.State;
			crm_abonnement.Nrq_status = of_subscription.Status;
			crm_abonnement.Nrq_Subscription_customer_no = of_subscription.Subscription_customer_no;
		}

		public static bool Needs_update_in_crm(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			return
				crm_abonnement.Nrq_bank_account_no != of_subscription.Bank_account_no ||
				crm_abonnement.Nrq_bank_sort_code != of_subscription.Bank_sort_code ||
				crm_abonnement.Nrq_Bse_guid != of_subscription.Bse_guid ||
				crm_abonnement.Nrq_of_contact_id != of_subscription.Contact_id ||
				crm_abonnement.Nrq_msisdn != of_subscription.Msisdn ||
				crm_abonnement.Nrq_of_subscription_id != of_subscription.Of_id ||
				crm_abonnement.Nrq_order_id != of_subscription.Order_id ||
				crm_abonnement.Nrq_payment_gateway != of_subscription.Payment_gateway ||
				crm_abonnement.Nrq_payment_media != of_subscription.Payment_media ||
				crm_abonnement.Nrq_payment_media_type != of_subscription.Payment_media_type ||
				crm_abonnement.Nrq_state != of_subscription.State ||
				crm_abonnement.Nrq_status != of_subscription.Status ||
				crm_abonnement.Nrq_Subscription_customer_no != of_subscription.Subscription_customer_no;
		}

		public static bool Needs_update_in_of(crm.Abonnement crm_abonnement, of.data.Subscription of_subscription)
		{
			return
				of_subscription.Bank_account_no != crm_abonnement.Nrq_bank_account_no ||
				of_subscription.Bank_sort_code != crm_abonnement.Nrq_bank_sort_code ||
				of_subscription.Bse_guid != crm_abonnement.Nrq_Bse_guid ||
				of_subscription.Contact_id != crm_abonnement.Nrq_of_contact_id ||
				of_subscription.Msisdn != crm_abonnement.Nrq_msisdn ||
				of_subscription.Of_id != crm_abonnement.Nrq_of_subscription_id ||
				of_subscription.Order_id != crm_abonnement.Nrq_order_id ||
				of_subscription.Payment_gateway != crm_abonnement.Nrq_payment_gateway ||
				of_subscription.Payment_media != crm_abonnement.Nrq_payment_media ||
				of_subscription.Payment_media_type != crm_abonnement.Nrq_payment_media_type ||
				of_subscription.State != crm_abonnement.Nrq_state ||
				of_subscription.Status != crm_abonnement.Nrq_status ||
				of_subscription.Subscription_customer_no != crm_abonnement.Nrq_Subscription_customer_no;
		}
	}
}
