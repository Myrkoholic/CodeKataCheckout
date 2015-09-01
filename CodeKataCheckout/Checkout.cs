using System;
// Code kata instruction http://codekata.com/kata/kata09-back-to-the-checkout/
using System.Collections.Generic;

namespace CodeKataCheckout
{
	public interface IPricingRules
	{
		double Discount(Dictionary<string, Item> items);
	}

    public class NullPricingRules : IPricingRules
	{
		public double Discount(Dictionary<string, Item> items)
		{
			return 0.0;
		}
	}

    public class QuantityPriceDiscount
    {
        public int Quantity;
        public double Price;
    }

	public class QuantityPriceRules : IPricingRules
	{
		private readonly Dictionary<string, QuantityPriceDiscount> _priceDiscounts = new Dictionary<string, QuantityPriceDiscount>();

		public QuantityPriceRules()
		{
			_priceDiscounts.Add("A", new QuantityPriceDiscount() { Quantity = 3, Price = 130.0 });
			_priceDiscounts.Add("B", new QuantityPriceDiscount() { Quantity = 2, Price = 45.0 });
		}

		public double Discount(Dictionary<string, Item> items)
		{
			double discount = 0.0;
			foreach (var item in items)
			{
				foreach (var priceDiscount in _priceDiscounts)
				{
					if (priceDiscount.Key == item.Key && item.Value.Quantity >= priceDiscount.Value.Quantity)
					{
						int numberOfDiscount = item.Value.Quantity / priceDiscount.Value.Quantity;

						discount += numberOfDiscount * ((priceDiscount.Value.Quantity * item.Value.UnitPrice) - priceDiscount.Value.Price);
					}
				}
			}
			return discount;
		}
	}

	public class Item
	{
		private string _code;
		private int _quantity;
		private double _unitPrice;
		
		public Item(string code, double unitPrice)
		{
			_code = code;
			_quantity = 1;
			_unitPrice = unitPrice;
		}

		public string Code
		{
			get { return _code; }
		}

		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}

		public double UnitPrice
		{
			get { return _unitPrice; }
		}
	}

	public static class PriceListing
	{
		private static Dictionary<string, double> _priceList;
		
		static PriceListing()
		{
			_priceList = new Dictionary<string, double> {{"A", 50.0}, {"B", 30.0}, {"C", 20.0}, {"D", 15.0}};
		}

		public static double Price(string item)
		{
		    var price = 0.0;
			_priceList.TryGetValue(item, out price);
			return price;
		}
	}

    public class Checkout
    {
	    private Dictionary<string, Item> _items = new Dictionary<string, Item>();
	    private IPricingRules _pricingRules = new NullPricingRules();

	    public void PricingRules(IPricingRules pricingRules)
	    {
		    _pricingRules = pricingRules;
	    }
		
	    public void Scan(string items)
	    {
		    for (var i = 0; i < items.Length; ++i)
		    {
			    var code = items[i].ToString();

			    if (_items.ContainsKey(code))
			    {
				    _items[code].Quantity += 1;
			    }
			    else
			    {
				    _items.Add(code, new Item(code, PriceListing.Price(code)));
			    }
		    }
	    }

	    public double Total()
	    {
		    var total = 0.0;
		    foreach (var item in _items)
		    {
			    total += item.Value.Quantity * item.Value.UnitPrice;
		    }

		    total -= _pricingRules.Discount(_items);

		    return total;
	    }
    }
}
