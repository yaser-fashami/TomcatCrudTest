Feature: Manage customers in the system
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](Mc2.CrudTest.AcceptanceTests.Behavior/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
	Scenario: customers get created successfully
		When I create customers
		Then the customers are created successfully

	Scenario: customers get updated siccessfully
		Given the following customers in the system
		When those customers get updated
		Then the customers are updated successfully