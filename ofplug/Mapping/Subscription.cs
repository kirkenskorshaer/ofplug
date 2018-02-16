namespace ofplug.Mapping
{
	public static class Subscription
	{
		//todo felter
		public static void To_of(crm.AbstractCrm crm_, of.data.Subscription of_subscription)
		{ }

		public static void To_crm(crm.AbstractCrm crm_, of.data.Subscription of_subscription)
		{ }

		public static bool Needs_update_in_crm(crm.AbstractCrm crm_, of.data.Subscription of_subscription)
		{
			return true;
		}

		public static bool Needs_update_in_of(crm.AbstractCrm crm_, of.data.Subscription of_subscription)
		{
			return true;
		}
	}
}
