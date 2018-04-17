using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Indbetaling
	{
		//todo felter
		public static void To_of(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			of_payment.Agreement_id = crm_indbetaling.Nrq_of_agreement_id;
			of_payment.Amount = (int?)crm_indbetaling.New_amount.Value;
			of_payment.Contact_id = crm_indbetaling.Nrq_of_contact_id;
			of_payment.Crm_id = crm_indbetaling.Id.ToString().ToLower();
			of_payment.Currency = "208";
			of_payment.Amount_type = crm_indbetaling.Nrq_amountType.SelectedValue;
			//of_payment.Form_id
			//of_payment.Gateway_subscription_id
			//of_payment.Ocr
			//of_payment.Order_id
			of_payment.Payment_due_ts_value = crm_indbetaling.Nrq_PaymentDueDate;
			of_payment.Payment_gateway = crm_indbetaling.Nrq_PaymentGateway.SelectedValue;
			of_payment.Payment_media = crm_indbetaling.Nrq_PaymentMedia.SelectedValue;
			of_payment.Payment_media_type = crm_indbetaling.Nrq_PaymentType.SelectedValue;
			of_payment.Of_id = crm_indbetaling.Nrq_of_id;
			//of_payment.Payment_method
			//of_payment.State
			//of_payment.Subscription_id = crm_indbetaling.
		}

		public static void To_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			crm_indbetaling.Nrq_of_agreement_id = of_payment.Agreement_id;
			crm_indbetaling.New_amount = new Money((decimal)of_payment.Amount);
			if (string.IsNullOrWhiteSpace(of_payment.Crm_id) == false)
			{
				crm_indbetaling.Id = Guid.Parse(of_payment.Crm_id);
			}
			if (string.IsNullOrWhiteSpace(of_payment.Amount_type) == false)
			{
				crm_indbetaling.Nrq_amountType.Select(of_payment.Amount_type);
			}
			//crm_indbetaling.Nrq_FeeAmount = of_payment.fee_amount;
			crm_indbetaling.Nrq_of_contact_id = of_payment.Contact_id;
			crm_indbetaling.Nrq_of_fundraising_project_id = of_payment.Project_id;
			crm_indbetaling.Nrq_of_id = of_payment.Of_id;
			//crm_indbetaling.Nrq_paymentDate = of_payment.Payment_ts_value;
			crm_indbetaling.Nrq_PaymentDueDate = of_payment.Payment_due_ts_value;
			crm_indbetaling.Nrq_PaymentGateway.Select(of_payment.Payment_gateway);
			crm_indbetaling.Nrq_PaymentMedia.Select(of_payment.Payment_media);
			crm_indbetaling.Nrq_PaymentType.Select(of_payment.Payment_media_type);
			//crm_indbetaling.Nrq_BookkeeptinDate
			//crm_indbetaling.Nrq_ChargebackDate
		}

		public static List<string> Needs_update_in_crm(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_agreement_id", crm_indbetaling.Nrq_of_agreement_id, of_payment.Agreement_id);
			Mapping_update_helper.Add_if_unequal(parameters, "new_amount", (int?)crm_indbetaling.New_amount?.Value, of_payment.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_amounttype", crm_indbetaling.Nrq_amountType.SelectedValue, of_payment.Amount_type);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_bookkeeptindate", crm_indbetaling.Nrq_BookkeeptinDate, of_payment.);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_chargebackdate", crm_indbetaling.Nrq_ChargebackDate, of_payment.Agreement_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_feeamount", crm_indbetaling.Nrq_FeeAmount, of_payment.fee);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_contact_id", crm_indbetaling.Nrq_of_contact_id, of_payment.Contact_id);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_of_fundraising_project_id", crm_indbetaling.Nrq_of_fundraising_project_id, of_payment.Project_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentdate", crm_indbetaling.Nrq_paymentDate, of_payment.Payment_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentduedate", crm_indbetaling.Nrq_PaymentDueDate, of_payment.Payment_due_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentgateway", crm_indbetaling.Nrq_PaymentGateway.SelectedValue, of_payment.Payment_gateway);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentmedia", crm_indbetaling.Nrq_PaymentMedia.SelectedValue, of_payment.Payment_media);
			Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymenttype", crm_indbetaling.Nrq_PaymentType.SelectedValue, of_payment.Payment_media_type);

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Indbetaling crm_indbetaling, of.data.Payment of_payment)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "Agreement_id", crm_indbetaling.Nrq_of_agreement_id, of_payment.Agreement_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Amount", (int?)crm_indbetaling.New_amount.Value, of_payment.Amount);
			Mapping_update_helper.Add_if_unequal(parameters, "Amount_type", crm_indbetaling.Nrq_amountType.SelectedValue, of_payment.Amount_type);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_bookkeepingdate", crm_indbetaling.Nrq_BookkeepinDate, of_payment.);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_chargebackdate", crm_indbetaling.Nrq_ChargebackDate, of_payment.Agreement_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_feeamount", crm_indbetaling.Nrq_FeeAmount, of_payment.fee);
			Mapping_update_helper.Add_if_unequal(parameters, "Contact_id", crm_indbetaling.Nrq_of_contact_id, of_payment.Contact_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Project_id", crm_indbetaling.Nrq_of_fundraising_project_id, of_payment.Project_id);
			//Mapping_update_helper.Add_if_unequal(parameters, "nrq_paymentdate", crm_indbetaling.Nrq_paymentDate, of_payment.Payment_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_due_ts", crm_indbetaling.Nrq_PaymentDueDate, of_payment.Payment_due_ts_value);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_gateway", crm_indbetaling.Nrq_PaymentGateway.SelectedValue, of_payment.Payment_gateway);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_media", crm_indbetaling.Nrq_PaymentMedia.SelectedValue, of_payment.Payment_media);
			Mapping_update_helper.Add_if_unequal(parameters, "Payment_media_type", crm_indbetaling.Nrq_PaymentType.SelectedValue, of_payment.Payment_media_type);

			return parameters;
		}
	}
}
