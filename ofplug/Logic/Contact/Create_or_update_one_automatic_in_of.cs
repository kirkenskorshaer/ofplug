using ofplug.Logic.Abstract;
using System;

namespace ofplug.Logic.Contact
{
	/*
	public class Create_or_update_one_automatic_in_of : AbstractPlugin
	{
		public override void Execute(IServiceProvider serviceProvider)
		{
			Initialize(serviceProvider);

			if (_context_entity == null)
			{
				return;
			}

			crm.Contact crm_contact = new crm.Contact(_service, _tracingService)
			{
				CrmEntity = _context_entity
			};

			if (_context_entity.LogicalName != crm_contact.Logical_name)
			{
				return;
			}

			crm_contact.Read_fields();

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Create_or_update_one_contact_in_of(crm_contact);
		}
	}
	*/
}
