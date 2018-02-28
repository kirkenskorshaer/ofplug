using ofplug.of.connector;

namespace ofplug.of
{
	public class Connection
	{
		private string _url;
		private ISender _sender;

		private Contact _contact;
		public Contact Contact
		{
			get
			{
				if(_contact == null)
				{
					_contact = new Contact(_sender, _url, "contact");
				}

				return _contact;
			}
		}

		private Agreement _agreement = null;
		public Agreement Agreement
		{
			get
			{
				if (_agreement == null)
				{
					_agreement = new Agreement(_sender, _url, "agreement");
				}

				return _agreement;
			}
		}

		private Payment _payment = null;
		public Payment Payment
		{
			get
			{
				if (_payment == null)
				{
					_payment = new Payment(_sender, _url, "agreement");
				}

				return _payment;
			}
		}

		public Connection(string url)
		{
			_sender = new Sender();
			_url = url;
		}

		public void Replace_sender(ISender sender)
		{
			_sender = sender;
		}

		public Agreements Get_agreements()
		{
			return new Agreements(_url, _sender);
		}

		public Contacts Get_contacts()
		{
			return new Contacts(_url, _sender);
		}

		public Payments Get_payments()
		{
			return new Payments(_url, _sender);
		}
	}
}
