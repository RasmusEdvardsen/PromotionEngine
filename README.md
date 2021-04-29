# Promotion Engine

## Assumptions
* Only one promotion can be applied to a product
* A promotion can only be used once.

## Considerations
* Product SKU/price should come from a Db
* Product price is not necessary for calculating total discount
* Promotions are ordered from most savings to least. This still does not guarantee the highest total savings, but should do well enough.