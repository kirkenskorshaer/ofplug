using ofplug.of.connector;

namespace ofplug.of
{
	public class Connection
	{
		private string _url;
		private Sender _sender;

		public Contact Contact;
		public Agreement Agreement;
		public Payment Payment;

		public Connection(string url)
		{
			_sender = new Sender();
			_url = url;

			Contact = new Contact(_sender, _url, "contact");
			Agreement = new Agreement(_sender, _url, "agreement");
			Payment = new Payment(_sender, _url, "payment");
		}

		public Agreements Get_agreements(int step)
		{
			return new Agreements(_url, step, _sender);
		}

		public Contacts Get_contacts(int step)
		{
			return new Contacts(_url, step, _sender);
		}

		public Payments Get_payments(int step)
		{
			return new Payments(_url, step, _sender);
		}
	}
}
