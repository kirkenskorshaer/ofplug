using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace ofplug.Abstract
{
	public abstract class AbstractCodeActivity : CodeActivity
	{
		public bool IsTest = false;

		protected ITracingService _tracingService;
		protected IOrganizationService _service;

		protected void Initialize(CodeActivityContext codeActivityContext)
		{
			if (IsTest == false)
			{
				_tracingService = codeActivityContext.GetExtension<ITracingService>();

				IWorkflowContext workflowContext = codeActivityContext.GetExtension<IWorkflowContext>();
				IOrganizationServiceFactory serviceFactory = codeActivityContext.GetExtension<IOrganizationServiceFactory>();
				_service = serviceFactory.CreateOrganizationService(workflowContext.UserId);
			}
		}

		public void SetTest(ITracingService tracingService, IOrganizationService service)
		{
			_tracingService = tracingService;
			_service = service;
		}

		public void ExecuteInTest(CodeActivityContext codeActivityContext)
		{
			Execute(codeActivityContext);
		}
	}
}
