using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

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

			_config = new crm.Config(_service);
			_of_connection = new of.Connection(_config.Url);
		}

		public void Set_test(ITracingService tracingService, IOrganizationService service)
		{
			_tracingService = tracingService;
			_service = service;
		}
	}
}
