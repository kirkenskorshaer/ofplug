using System;

namespace ofplug.Logic.Indbetaling
{
	/*
	public class Update_status_automatic_in_of : Abstract.AbstractPlugin
	{
		public override void Execute(IServiceProvider serviceProvider)
		{
			Initialize(serviceProvider);

			if (_context_entity == null)
			{
				return;
			}

			crm.Indbetaling crm_indbetaling = new crm.Indbetaling(_service, _tracingService)
			{
				CrmEntity = _context_entity
			};

			if (_context_entity.LogicalName != crm_indbetaling.Logical_name)
			{
				return;
			}

			crm_indbetaling.Read_fields();

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Update_status_in_of(crm_indbetaling);
		}
	}
	*/
}
