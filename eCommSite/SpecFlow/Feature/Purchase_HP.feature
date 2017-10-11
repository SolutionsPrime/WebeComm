Feature: Purchase_HP
	Purchase 2 Items

/*
These are comments

*/
@mytag
Scenario: Verify user registration
	Given I open the website in Chrome
	When I register in the website
	Then System must create an account on the website


@mytag
Scenario: Verify the system supports the purchase of items
	Given I login to website successfully for which System displays the available items
	| UserName        | Password |
	| abi3520@abi.com | BJSSTest |	
	When I quick view item, change the Item size, Add the item to the shopping cart, for which System displays quick form with Product successfully added to shopping cart
	| ItemId | ItemName             | ItemSize | ItemColour | Currency | ItemPrice | ItemQuantity | ImgUrl|
	| 6      | Printed Summer Dress | Medium   | Yellow     | $        | 30.50     | 1            | http://automationpractice.com/img/p/1/6/16-home_default.jpg |
	| 4      | Printed Dress       | Default  | Pink       | $        | 50.99     | 1            | http://automationpractice.com/img/p/1/0/10-home_default.jpg |
	And I Check out and verify the shopping cart information
	And I proceed for checkout, see delivery address saved as aliases, continue Checkout to shipping options	
	| ShippingType      | ShippingValue |
	| Delivery Next Day | 2.00          |
	And I Agree the terms of service, continue to proceed checkout, verify the cart information
	And I pay by bank wire, confirm order
	Then system displays the order is complete message along with the order details	

@mytag
Scenario: Review previous orders and add a message
    Given Afer I login to website, I view previous orders
	| UserName        | Password |
	| abi3520@abi.com | BJSSTest |
	When I verify and select an item from the previous orders and add a comment
	| Order Reference | Order Date | Total Price | Payments  | Status                     | Comment                    | OrderNo |
	| RAIVIACLK       | 10/07/2017 | $63.00      | Bank wire | Awaiting bank wire payment | nearest to leisure center  | 21035   |
	| IBUJSGQUM       | 10/09/2017 | $83.49      | Bank wire | On backorder               | adding more notes for test | 21116   |
	Then the system confirms that the comment was Successfully sent
	| From           | Message                   |
	| Abishai Tester | nearest to leisure center |

