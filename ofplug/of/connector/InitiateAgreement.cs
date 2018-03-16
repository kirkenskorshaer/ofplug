namespace ofplug.of.connector
{
	public class InitiateAgreement : Abstract_data_exchange
	{
		public InitiateAgreement(ISender sender, string url, string token, string path) : base(sender, url, token, path)
		{
		}

		public data.InitiateAgreementResponse Post(data.InitiateAgreement of_initiate_agreement)
		{
			data.InitiateAgreementResponse response = _sender.Post<data.InitiateAgreement, data.InitiateAgreementResponse>(_url + _path, _token, of_initiate_agreement);
			return response;
		}
	}
}
