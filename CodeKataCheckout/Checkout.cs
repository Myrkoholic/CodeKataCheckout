using System;
// Code kata instruction http://codekata.com/kata/kata09-back-to-the-checkout/
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CodeKataCheckout
{
	public static class PriceListing
	{
		private static Dictionary<char, double> _priceList;

		static PriceListing()
		{
			_priceList = new Dictionary<char, double> {{'A', 50.0}, {'B', 30.0}, {'C', 20.0}, {'D', 15.0}};
		}

		public static double Price(char item)
		{
			var price = 0.0;

			try
			{
				_priceList.TryGetValue(item, out price);
			}
			catch(Exception)
			{
			}

			return price;
		}

	}

    public class Checkout
    {
	    private double _total = 0.0;
		
	    public void Scan(string items)
	    {
		    for (var i = 0; i < items.Length; ++i)
		    {
			   _total += PriceListing.Price(items[i]); 
		    }
	    }

	    public double Total()
	    {
		    return _total;
	    }
    }
}
