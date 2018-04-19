using System;

namespace ofplug.Logic.Abonnement
{
	/*
	public class Create_or_update_one_automatic_in_of : Abstract.AbstractPlugin
	{
		public override void Execute(IServiceProvider serviceProvider)
		{
			Initialize(serviceProvider);

			if (_context_entity == null)
			{
				return;
			}

			crm.Abonnement crm_abonnement = new crm.Abonnement(_service, _tracingService)
			{
				CrmEntity = _context_entity
			};

			if (_context_entity.LogicalName != crm_abonnement.Logical_name)
			{
				return;
			}

			crm_abonnement.Read_fields();

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_one_abonnement_in_of(crm_abonnement);
		}
	}
	*/
}
