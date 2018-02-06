using System.Runtime.Serialization;

namespace ofplug_test.ofTest.dataTest
{
	[DataContract]
	public class Simple_data
	{
		[DataMember]
		public string StringField { get; set; }

		public override string ToString()
		{
			return
				StringField;
		}
	}
}
