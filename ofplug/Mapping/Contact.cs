using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace ofplug.Mapping
{
	public static class Contact
	{
		//todo felter
		public static void To_of(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			of_contact.City = crm_contact.address1_city;
			of_contact.Country = crm_contact.address1_country;
			//of_contact.Gender = crm_contact.Gendercode_enum_to_string(crm_contact.Gendercode_value);
			of_contact.Gender = null;
			//of_contact.Lat = crm_contact.address1_latitude;
			of_contact.Lat = null;
			of_contact.Address = crm_contact.address1_line1;
			//of_contact.Long = crm_contact.address1_longitude;
			of_contact.Long = null;
			of_contact.Postcode = crm_contact.address1_postalcode;
			//of_contact.Birthday_stamp_value = crm_contact.birthdate;
			of_contact.Birthday_stamp_value = null;
			of_contact.Email = crm_contact.emailaddress1;
			of_contact.First_name = crm_contact.firstname;
			of_contact.Last_name = crm_contact.lastname;
			of_contact.Cpr = crm_contact.new_cprnr;
			//of_contact.Id = crm_contact.new_ofcontactid;
			of_contact.Id = null;
			of_contact.Of_id = crm_contact.nrq_of_id;
			of_contact.Valid_adr_ts_value = null;
			of_contact.External_id = crm_contact.new_kkadminmedlemsnr?.ToString();
			of_contact.Crm_id = crm_contact.Id.ToString().ToLower();

			//    "birthday": "11. nov. 2011",
			//"birthday": "2011-11-13",
		}

		public static void To_crm(crm.Contact crm_contact, of.data.Contact of_contact, ITracingService tracingService)
		{
			crm_contact.address1_city = of_contact.City;
			crm_contact.address1_country = of_contact.Country;
			crm_contact.gendercode.Select(of_contact.Gender, tracingService);
			crm_contact.address1_latitude = of_contact.Lat;
			crm_contact.address1_line1 = of_contact.Address;
			crm_contact.address1_longitude = of_contact.Long;
			crm_contact.address1_postalcode = of_contact.Postcode;
			crm_contact.birthdate = of_contact.Birthday_stamp_value;
			crm_contact.emailaddress1 = of_contact.Email;
			crm_contact.firstname = of_contact.First_name;
			crm_contact.lastname = of_contact.Last_name;
			crm_contact.new_cprnr = of_contact.Cpr;
			crm_contact.nrq_of_id = of_contact.Of_id;
			if (string.IsNullOrWhiteSpace(of_contact.External_id) == false)
			{
				crm_contact.new_kkadminmedlemsnr = int.Parse(of_contact.External_id);
			}
		}

		public static List<string> Needs_update_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "address1_city", crm_contact.address1_city, of_contact.City);
			Mapping_update_helper.Add_if_unequal(parameters, "address1_country", crm_contact.address1_country, of_contact.Country);
			Mapping_update_helper.Add_if_unequal(parameters, "Gendercode", crm_contact.gendercode.SelectedValue, of_contact.Gender);
			Mapping_update_helper.Add_if_unequal(parameters, "address1_latitude", crm_contact.address1_latitude, of_contact.Lat);
			Mapping_update_helper.Add_if_unequal(parameters, "address1_line1", crm_contact.address1_line1, of_contact.Address);
			Mapping_update_helper.Add_if_unequal(parameters, "address1_longitude", crm_contact.address1_longitude, of_contact.Long);
			Mapping_update_helper.Add_if_unequal(parameters, "address1_postalcode", crm_contact.address1_postalcode, of_contact.Postcode);
			Mapping_update_helper.Add_if_unequal(parameters, "birthdate", crm_contact.birthdate, of_contact.Birthday_stamp_value);
			Mapping_update_helper.Add_if_unequal(parameters, "emailaddress1", crm_contact.emailaddress1, of_contact.Email);
			Mapping_update_helper.Add_if_unequal(parameters, "firstname", crm_contact.firstname, of_contact.First_name);
			Mapping_update_helper.Add_if_unequal(parameters, "lastname", crm_contact.lastname, of_contact.Last_name);
			Mapping_update_helper.Add_if_unequal(parameters, "new_cprnr", crm_contact.new_cprnr, of_contact.Cpr);

			return parameters;
		}

		public static List<string> Needs_update_in_of(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			List<string> parameters = new List<string>();

			Mapping_update_helper.Add_if_unequal(parameters, "City", crm_contact.address1_city, of_contact.City);
			Mapping_update_helper.Add_if_unequal(parameters, "Country", crm_contact.address1_country, of_contact.Country);
			Mapping_update_helper.Add_if_unequal(parameters, "Gender", crm_contact.gendercode.SelectedValue, of_contact.Gender);
			Mapping_update_helper.Add_if_unequal(parameters, "Lat", crm_contact.address1_latitude, of_contact.Lat);
			Mapping_update_helper.Add_if_unequal(parameters, "Address", crm_contact.address1_line1, of_contact.Address);
			Mapping_update_helper.Add_if_unequal(parameters, "Long", crm_contact.address1_longitude, of_contact.Long);
			Mapping_update_helper.Add_if_unequal(parameters, "Postcode", crm_contact.address1_postalcode, of_contact.Postcode);
			Mapping_update_helper.Add_if_unequal(parameters, "Email", crm_contact.emailaddress1, of_contact.Email);
			Mapping_update_helper.Add_if_unequal(parameters, "First_name", crm_contact.firstname, of_contact.First_name);
			Mapping_update_helper.Add_if_unequal(parameters, "Last_name", crm_contact.lastname, of_contact.Last_name);
			Mapping_update_helper.Add_if_unequal(parameters, "External_id", crm_contact.new_kkadminmedlemsnr?.ToString(), of_contact.External_id);
			Mapping_update_helper.Add_if_unequal(parameters, "Cpr", crm_contact.new_cprnr, of_contact.Cpr);

			Mapping_update_helper.Add_if_other_exists(parameters, "Address", "Postcode");

			return parameters;
		}
	}
}
