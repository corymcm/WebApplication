namespace WebApplication1.Migrations
{
    using SaasEcom.Core.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            var basicMonthly = new SubscriptionPlan
            {
                Id = "basic_monthly",
                Name = "Basic",
                Interval = SubscriptionPlan.SubscriptionInterval.Monthly,
                Price = 15.00,
                Currency = "CAD"
            };

            basicMonthly.Properties.Add(new SubscriptionPlanProperty());

            context.SubscriptionPlans.AddOrUpdate(sp => sp.Id, basicMonthly);
        }
    }
}
