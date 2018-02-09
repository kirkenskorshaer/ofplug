using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;
using CrmContact = ofplug.crm.Contact;
using CrmConfig = ofplug.crm.Config;
using OfContact = ofplug.of.data.Contact;

namespace ofplug.Logic.Abstract
{
	public abstract class AbstractCodeActivity : CodeActivity
	{
		public bool IsTest = false;

		protected ITracingService _tracingService;
		protected IOrganizationService _service;
		protected crm.Config _config;
		protected of.Connection _of_connection;

		protected void Initialize(CodeActivityContext codeActivityContext)
		{
			if (IsTest == false)
			{
				_tracingService = codeActivityContext.GetExtension<ITracingService>();

				IWorkflowContext workflowContext = codeActivityContext.GetExtension<IWorkflowContext>();
				IOrganizationServiceFactory serviceFactory = codeActivityContext.GetExtension<IOrganizationServiceFactory>();
				_service = serviceFactory.CreateOrganizationService(workflowContext.UserId);
			}

			_config = new CrmConfig(_service);
			_of_connection = new of.Connection(_config.Url);
		}

		protected CrmContact Get_or_create_contact(int of_contact_id)
		{
			OfContact of_contact = _of_connection.Contact.Get(of_contact_id);

			CrmContact contact = new CrmContact(_service);
			//todo felter
			contact.Get_contact(_service, of_contact.Id, of_contact.Id, of_contact.Id.ToString());

			if (contact.CrmEntity == null)
			{//todo felter
				contact.firstname = of_contact.Id.ToString();

				contact.Create();
			}

			return contact;
		}

		public void Set_test(ITracingService tracingService, IOrganizationService service)
		{
			_tracingService = tracingService;
			_service = service;
		}

		public void Execute_in_test(CodeActivityContext codeActivityContext)
		{
			Execute(codeActivityContext);
		}
	}
}
