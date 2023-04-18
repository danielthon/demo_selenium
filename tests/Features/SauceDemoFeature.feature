Feature: SauceDemo

A short summary of the feature

Background:
    Given a shopping website navigated through 'https://www.saucedemo.com/' url

@e2e @product-view
Scenario: View product information
	Given I am logged as 'standard_user' with password 'secret_sauce' in the products page
	When I sort the products by 'Name (Z to A)'
	And I click in 'Sauce Labs Backpack' product
	Then the 'Sauce Labs Backpack' product description should be 'carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.'

@e2e @cart @checkout
Scenario Outline: Checkout product
	Given I am logged as '<username>' with password '<password>' in the products page
	When I add 'Sauce Labs Bike Light' product to the cart
	And I click on the cart
	And I proceed to checkout
	And I fill the step one with my information
	And I proceed to continue checkout
	Then the 'Sauce Labs Bike Light' product should be listed in the products

Examples: 
	| username | password |
	| standard_user | secret_sauce |
	| performance_glitch_user | secret_sauce |
	| problem_user | secret_sauce |
	| locked_out_user | secret_sauce |