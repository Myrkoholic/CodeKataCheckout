using NUnit.Framework;
using CodeKataCheckout;
using FluentAssertions;

namespace CodeKataCheckoutPrice
{
	[TestFixture]
	public class CodeKataCheckoutTest
	{
		[Test]
		public void TestEmptyCheckout()
		{
			var co = new Checkout();
			co.Scan("");
			co.Total().Should().Be(0.00);
		}

		[Test]
		public void TestACheckout()
		{
			var co = new Checkout();
			co.Scan("A");
			co.Total().Should().Be(50.00);
		}

		[Test]
		public void TestABCheckout()
		{
			var co = new Checkout();
			co.Scan("AB");
			co.Total().Should().Be(80.00);
		}

		[Test]
		public void TestCDBACheckout()
		{
			var co = new Checkout();
			co.Scan("CDBA");
			co.Total().Should().Be(115.00);
		}

		[Test]
		public void TestAACheckout()
		{
			var co = new Checkout();
			co.Scan("AA");
			co.Total().Should().Be(100.00);
		}

		[Test]
		public void TestAAACheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAA");
			co.Total().Should().Be(130.00);
		}

		[Test]
		public void TestAAAACheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAAA");
			co.Total().Should().Be(180.00);
		}

		[Test]
		public void TestAAAAACheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAAAA");
			co.Total().Should().Be(230.00);
		}

		[Test]
		public void TestAAAAAACheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAAAAA");
			co.Total().Should().Be(260.00);
		}

		[Test]
		public void TestAAABCheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAAB");
			co.Total().Should().Be(160.00);
		}

		[Test]
		public void TestAAABBCheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAABB");
			co.Total().Should().Be(175.00);
		}

		[Test]
		public void TestAAABBDCheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("AAABBD");
			co.Total().Should().Be(190.00);
		}

		[Test]
		public void TestDABABACheckout()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("DABABA");
			co.Total().Should().Be(190.00);
		}

		[Test]
		public void TestIncremental()
		{
			var co = new Checkout();
			co.PricingRules(new QuantityPriceRules());
			co.Scan("A");
			co.Total().Should().Be(50.00);
			co.Scan("B");
			co.Total().Should().Be(80.00);
			co.Scan("A");
			co.Total().Should().Be(130.00);
			co.Scan("A");
			co.Total().Should().Be(160.00);
			co.Scan("B");
			co.Total().Should().Be(175.00);
		}
	}
}
