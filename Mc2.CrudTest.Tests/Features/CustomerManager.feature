Feature: Manage customers in the system

	Scenario: customers get created successfully
		When I create customers
		Then the customers are created successfully

	Scenario: customers get updated siccessfully
		Given the following customers in the system
		When those customers get updated
		Then the customers are updated successfully