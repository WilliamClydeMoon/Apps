order
ID		OrderNumber
PMTMethod	PaymentMethod
OrdRecVia	OrderReceivedVia
Route 		ShippingRoute
ConfirmationID  ConfirmationNumber
ShippingID 	ParentEntityIDShipping
BillingID 	ParentEntityIDBilling
CustomerID 	ParentEntityIDCustomerName
CompanyID 	ParentEntityIDCompanyName
ManifestID 	ParentEntityIDManifest
OrderLogID 	ChildOrderLogID
SubTotal 	OrderSubTotal
DiscountTotal 	OrderDiscountTotal
ShippingCost 	OrderShippingCost
TaxTotal 	OrderTaxTotal
Total 		OrderTotal

private string id;
private string pmtmethod;
private string ordrecvia;
private string route;
private string confirmationid;
private string shippingid;
private string billingid;
private string customerid;
private string companyid;
private string manifestid;
private string orderlogid;
private decimal subtotal;
private decimal discounttotal;
private decimal shippingcost;
private decimal taxtotal;
private decimal total;

public string ID{get;set;}
public string PMTMethod{get;set;}
public string OrdRecVia{get;set;}
public string Route{get;set;}
public string ConfirmationID{get;set;}
public string ShippingID{get;set;}
public string BillingID{get;set;}
public string CustomerID{get;set;}
public string CompanyID{get;set;}
public string ManifestID{get;set;}
public string OrderLogID{get;set;}
public decimal SubTotal{get;set;}
public decimal DiscountTotal{get;set;}
public decimal ShippingCost{get;set;}
public decimal TaxTotal{get;set;}
public decimal Total{get;set;}







orderManifest

private string _manfiestid
private string _productid
private string _inventoryid
private int _quantity
private boolean _instock
private boolean _pricevalidated
private int _discount
private int _shippingcost
private int _tax
private int _totalcost

public string ManfiestID{ get; set; }
public string ProductID{ get; set; }
public string InventoryID{ get; set; }
public int Quantity{ get; set; }
public boolean InStock{ get; set; }
public boolean PriceValidated{ get; set; }
public int Discount{ get; set; }
public int ShippingCost{ get; set; }
public int Tax{ get; set; }
public int TotalCost{ get; set; }



string Id 						{ get; set; }
string PmtMethod 			{ get; set; }
string OrdRecVia 			{ get; set; }
string Route 					{ get; set; }
string ConfirmationId { get; set; }
string ShippingId 		{ get; set; }
string BillingId 			{ get; set; }
string CustomerId 		{ get; set; }
string CompanyId 			{ get; set; }
string ManifestId 		{ get; set; }
string OrderLogId 		{ get; set; }
decimal SubTotal 			{ get; set; }
decimal DiscountTotal { get; set; }
decimal ShippingCost 	{ get; set; }
decimal TaxTotal 			{ get; set; }
decimal Total 				{ get; set; }
DateTime SysDateTime 	{ get; set; }
