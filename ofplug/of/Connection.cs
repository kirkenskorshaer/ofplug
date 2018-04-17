using ofplug.of.connector;

namespace ofplug.of
{
	public class Connection
	{
		private string _url;
		private string _token;
		private ISender _sender;

		private Contact _contact;
		public Contact Contact
		{
			get
			{
				if (_contact == null)
				{
					_contact = new Contact(_sender, _url, _token, "contact");
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
					_agreement = new Agreement(_sender, _url, _token, "agreement");
				}

				return _agreement;
			}
		}

		private Subscription _subscription = null;
		public Subscription Subscription
		{
			get
			{
				if (_subscription == null)
				{
					_subscription = new Subscription(_sender, _url, _token, "subscription");
				}

				return _subscription;
			}
		}

		private Payment _payment = null;
		public Payment Payment
		{
			get
			{
				if (_payment == null)
				{
					_payment = new Payment(_sender, _url, _token, "payment");
				}

				return _payment;
			}
		}

		private InitiateAgreement _initiate_agreement = null;
		public InitiateAgreement Initiate_agreement
		{
			get
			{
				if (_initiate_agreement == null)
				{
					_initiate_agreement = new InitiateAgreement(_sender, _url, _token, "wizard/InitiateAgreement");
				}

				return _initiate_agreement;
			}
		}

		public Connection(string url, string token)
		{
			_sender = new Sender();
			_url = url;
			_token = token;
		}

		public void Replace_sender(ISender sender)
		{
			_sender = sender;
		}

		public Agreements Get_agreements()
		{
			return new Agreements(_url, _token, _sender);
		}

		public Subscriptions Get_subscriptions()
		{
			return new Subscriptions(_url, _token, _sender);
		}

		public Contacts Get_contacts()
		{
			return new Contacts(_url, _token, _sender);
		}

		public Payments Get_payments()
		{
			return new Payments(_url, _token, _sender);
		}
	}
}
