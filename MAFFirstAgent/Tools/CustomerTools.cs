using System.ComponentModel;

namespace MAFFirstAgent.Tools
{
    public class CustomerTools
    {
        [Description("Find a customer by customer ID.")]
        public string GetCustomer([Description("The customer ID, such as C101 or C102.")]
        string customerId)
        {
            return customerId.ToUpperInvariant() switch
            {
                "C101" => """
                Customer ID: C101
                Name: Amit Sharma
                Subscription ID: SUB100
                Status: Active
                """,

                "C102" => """
                Customer ID: C102
                Name: Priya Patil
                Subscription ID: SUB200
                Status: Active
                """,

                _ => $"No customer found for ID {customerId}."
            };
        }

        [Description("Find the expiry date of a subscription by subscription ID.")]
        public string GetSubscriptionExpiry([Description("The subscription ID, such as SUB100 or SUB200.")]
        string subscriptionId)
        {
            return subscriptionId.ToUpperInvariant() switch
            {
                "SUB100" => "SUB100 expires on 31 December 2026.",
                "SUB200" => "SUB200 expires on 15 March 2027.",
                _ => $"No subscription found for ID {subscriptionId}."
            };
        }

    }
}
