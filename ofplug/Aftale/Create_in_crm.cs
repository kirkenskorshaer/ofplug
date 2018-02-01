using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ofplug.Abstract;

namespace ofplug.Aftale
{
	public class Create_in_crm : AbstractCodeActivity
	{
		protected override void Execute(CodeActivityContext codeActivityContext)
		{
			Initialize(codeActivityContext);

			_tracingService.Trace("ofplug_aftale_create: creating aftale");

			Entity entity = new Entity("nrq_bidragsaftale");
			entity["nrq_type"] = "hello world 2";
			_service.Create(entity);
		}
	}
}
