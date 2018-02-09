using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;

namespace ofplug.Logic.Aftale
{
	public class Create_in_of : IPlugin
	{
		public void Execute(IServiceProvider serviceProvider)
		{
			ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
			IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

			if (context.InputParameters.Contains("Target") == false)
			{
				tracingService.Trace("ofplug_aftale: No Target");
				return;
			}

			if (context.InputParameters["Target"] is Entity == false)
			{
				tracingService.Trace("ofplug_aftale: Target not entity");
				return;
			}

			Entity entity = (Entity)context.InputParameters["Target"];

			if (entity.LogicalName != "nrq_bidragsaftale")
			{
				tracingService.Trace("ofplug_aftale: entity not aftale");
				return;
			}

			try
			{
				IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
				IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

				entity["nrq_type"] = "hello world";

				tracingService.Trace("ofplug_aftale: updating");
				service.Update(entity);
			}
			catch (FaultException<OrganizationServiceFault> exception)
			{
				throw new InvalidPluginExecutionException("ofplug_aftale: ", exception);
			}

			catch (Exception exception)
			{
				tracingService.Trace("ofplug_aftale: {0}", exception.ToString());
				throw;
			}
		}
	}
}
