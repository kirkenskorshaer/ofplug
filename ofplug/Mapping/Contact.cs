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
			//crm_contact.new_cprnr
			//of_contact.Id = crm_contact.new_ofcontactid;
			of_contact.Id = null;
			of_contact.Of_id = crm_contact.new_ofcontactid;
			of_contact.Valid_adr_ts_value = null;
			of_contact.External_id = crm_contact.new_kkadminmedlemsnr;

			//    "birthday": "11. nov. 2011",
			//"birthday": "2011-11-13",
		}

		public static void To_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			crm_contact.address1_city = of_contact.City;
			crm_contact.address1_country = of_contact.Country;
			crm_contact.Gendercode_value = crm_contact.Gendercode_string_to_enum(of_contact.Gender);
			crm_contact.address1_latitude = of_contact.Lat;
			crm_contact.address1_line1 = of_contact.Address;
			crm_contact.address1_longitude = of_contact.Long;
			crm_contact.address1_postalcode = of_contact.Postcode;
			crm_contact.birthdate = of_contact.Birthday_stamp_value;
			crm_contact.emailaddress1 = of_contact.Email;
			crm_contact.firstname = of_contact.First_name;
			crm_contact.lastname = of_contact.Last_name;
			//crm_contact.new_cprnr
			crm_contact.new_ofcontactid = of_contact.Id;
			crm_contact.new_kkadminmedlemsnr = of_contact.External_id;
		}

		public static bool Needs_update_in_crm(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			return
				crm_contact.address1_city != of_contact.City ||
				crm_contact.address1_country != of_contact.Country ||
				crm_contact.Gendercode_value != crm_contact.Gendercode_string_to_enum(of_contact.Gender) ||
				crm_contact.address1_latitude != of_contact.Lat ||
				crm_contact.address1_line1 != of_contact.Address ||
				crm_contact.address1_longitude != of_contact.Long ||
				crm_contact.address1_postalcode != of_contact.Postcode ||
				crm_contact.birthdate != of_contact.Birthday_stamp_value ||
				crm_contact.emailaddress1 != of_contact.Email ||
				crm_contact.firstname != of_contact.First_name ||
				crm_contact.lastname != of_contact.Last_name ||
				crm_contact.new_kkadminmedlemsnr != of_contact.External_id ||
				//crm_contact.new_cprnr
				crm_contact.new_ofcontactid != of_contact.Id;
		}

		public static bool Needs_update_in_of(crm.Contact crm_contact, of.data.Contact of_contact)
		{
			return
				of_contact.City != crm_contact.address1_city ||
				of_contact.Country != crm_contact.address1_country ||
				of_contact.Gender != crm_contact.Gendercode_enum_to_string(crm_contact.Gendercode_value) ||
				of_contact.Lat != crm_contact.address1_latitude ||
				of_contact.Address != crm_contact.address1_line1 ||
				of_contact.Long != crm_contact.address1_longitude ||
				of_contact.Postcode != crm_contact.address1_postalcode ||
				of_contact.Birthday_stamp_value != crm_contact.birthdate ||
				of_contact.Email != crm_contact.emailaddress1 ||
				of_contact.First_name != crm_contact.firstname ||
				of_contact.Last_name != crm_contact.lastname ||
				of_contact.External_id != crm_contact.new_kkadminmedlemsnr ||
				//crm_contact.new_cprnr
				of_contact.Id != crm_contact.new_ofcontactid;
		}
	}
}
