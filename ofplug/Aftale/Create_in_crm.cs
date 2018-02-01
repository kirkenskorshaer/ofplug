using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ofplug.Aftale
{
	public class Create_in_crm : CodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			//Create the tracing service
			ITracingService tracingService = codeActivityContext.GetExtension<ITracingService>();

			//Create the context
			IWorkflowContext workflowContext = codeActivityContext.GetExtension<IWorkflowContext>();
			IOrganizationServiceFactory serviceFactory = codeActivityContext.GetExtension<IOrganizationServiceFactory>();
			IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.UserId);

			tracingService.Trace("ofplug_aftale_create: creating aftale");

			Entity entity = new Entity("nrq_bidragsaftale");
			entity["nrq_type"] = "hello world";
			service.Create(entity);
		}
	}
}
