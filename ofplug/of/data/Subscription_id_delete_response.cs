﻿using System.Runtime.Serialization;

namespace ofplug.of.data
{
	[DataContract]
	public class Subscription_id_delete_response
	{
		[DataMember(Name = "id", EmitDefaultValue = false)]
		public int Id { get; set; }
	}
}
