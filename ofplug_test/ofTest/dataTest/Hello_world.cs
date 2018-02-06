using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ofplug_test.ofTest.dataTest
{
	[DataContract]
	public class Hello_world
	{
		[DataMember(Name = "response")]
		public int Response { get; set; }
	}
}
