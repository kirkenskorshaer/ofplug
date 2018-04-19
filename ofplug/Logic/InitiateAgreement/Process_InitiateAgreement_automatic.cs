using System;

namespace ofplug.Logic.InitiateAgreement
{
	/*
	public class Process_InitiateAgreement_automatic : Abstract.AbstractPlugin
	{
		public override void Execute(IServiceProvider serviceProvider)
		{
			Initialize(serviceProvider);

			if (_context_entity == null)
			{
				return;
			}

			crm.AgreementRequest crm_start_aftale = new crm.AgreementRequest(_service, _tracingService)
			{
				CrmEntity = _context_entity
			};

			if (_context_entity.LogicalName != crm_start_aftale.Logical_name)
			{
				return;
			}

			crm_start_aftale.Read_fields();

			Maintain maintain = new Maintain(_service, _tracingService, _config, _of_connection);
			maintain.Process_InitiateAgreement(crm_start_aftale);
		}
	}
	*/
}
