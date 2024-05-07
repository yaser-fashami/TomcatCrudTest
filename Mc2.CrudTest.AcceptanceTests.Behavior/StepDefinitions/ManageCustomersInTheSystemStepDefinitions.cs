using FluentAssertions;
using Mc2.CrudTest.Core.Domain.Entities;
using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Tests.Behavior.Steps
{
    [Binding]
    public class ManageCustomersInTheSystemStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Customer _customer;
        public ManageCustomersInTheSystemStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I create customers")]
        public void WhenICreateCustomers()
        {
            _customer = new Customer("yaser",
                                    "fashami",
                                    DateTime.Parse("1979-04-14"),
                                    "09121438100",
                                    "yaserf2000@yahoo.com",
                                    "111122223334444");
        }

        [Then(@"the customers are created successfully")]
        public void ThenTheCustomersAreCreatedSuccessfully()
        {
            _customer.FirstName.Value.Length.Should().BeInRange(2, 250);
            _customer.LastName.Value.Length.Should().BeInRange(2, 500);
        }

        [Given(@"the following customers in the system")]
        public void GivenTheFollowingCustomersInTheSystem()
        {
            throw new PendingStepException();
        }

        [When(@"those customers get updated")]
        public void WhenThoseCustomersGetUpdated()
        {
            throw new PendingStepException();
        }

        [Then(@"the customers are updated successfully")]
        public void ThenTheCustomersAreUpdatedSuccessfully()
        {
            throw new PendingStepException();
        }
    }
}
