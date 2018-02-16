using Microsoft.Xrm.Sdk;
using System;

namespace ofplug.Logic.Abstract
{
	public abstract class AbstractPlugin : IPlugin
	{
		protected ITracingService _tracingService;
		protected IPluginExecutionContext _context;
		protected IOrganizationService _service;

		protected of.Connection _of_connection;
		protected crm.Config _config;

		protected Entity _context_entity = null;

		public abstract void Execute(IServiceProvider serviceProvider);

		protected void Initialize(IServiceProvider serviceProvider)
		{
			_tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
			_context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

			if (_context.InputParameters.Contains("Target") && _context.InputParameters["Target"] is Entity)
			{
				Entity entity = (Entity)_context.InputParameters["Target"];
			}

			try
			{
				IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
				_service = serviceFactory.CreateOrganizationService(_context.UserId);
			}
			catch (Exception exception)
			{
				_tracingService.Trace("ofplug: {0}", exception.ToString());
				throw;
			}

			_config = new crm.Config(_service);
			_of_connection = new of.Connection(_config.Url);
		}
	}
}
