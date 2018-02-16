using ofplug.Logic.Abstract;
using System;

namespace ofplug.Logic.Aftale
{
	public class Create_or_update_one_automatic_in_of : AbstractPlugin
	{
		public override void Execute(IServiceProvider serviceProvider)
		{
			Initialize(serviceProvider);

			if (_context_entity == null)
			{
				return;
			}

			crm.Aftale crm_aftale = new crm.Aftale(_service)
			{
				CrmEntity = _context_entity
			};

			if (_context_entity.LogicalName != crm_aftale.Logical_name)
			{
				return;
			}

			crm_aftale.Read_fields();

			Maintain maintain = new Maintain(_service, _config, _of_connection);
			maintain.Create_or_update_one_in_of(crm_aftale);
		}
	}
}
