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

		private of.ISender _sender_test = null;

		public abstract void Execute(IServiceProvider serviceProvider);

		protected void Initialize(IServiceProvider serviceProvider)
		{
			if (_sender_test == null)
			{
				_tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
				_context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

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
			}

			if (_context != null && _context.InputParameters != null && _context.InputParameters.Contains("Target") && _context.InputParameters["Target"] is Entity)
			{
				_context_entity = (Entity)_context.InputParameters["Target"];
			}

			_config = new crm.Config(_service, _tracingService);
			_of_connection = new of.Connection(_config.Url);

			if (_sender_test != null)
			{
				_of_connection.Replace_sender(_sender_test);
			}
		}

		public void Set_test(ITracingService tracingService, IOrganizationService service, of.ISender sender, IPluginExecutionContext context)
		{
			_tracingService = tracingService;
			_service = service;
			_sender_test = sender;
			_context = context;
		}
	}
}
