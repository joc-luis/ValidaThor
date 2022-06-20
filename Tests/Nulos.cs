using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using ValidaThor;
namespace Tests
{
    public class Nulos
    {
		[Test]
		public void Accepted()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Accepted();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void ActiveUrl()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).ActiveUrl();
			Assert.AreEqual(1, validathor.Errors().Count);
		}


		[Test]
		public void Alpha()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Alpha();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void AlphaDash()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).AlphaDash();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void AlphaNum()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).AlphaNum();
			Assert.AreEqual(1, validathor.Errors().Count);
		}


		[Test]
		public void Boolean()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Boolean();
			Assert.AreEqual(1, validathor.Errors().Count);
		}


		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Confirmed("hola");
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Declined()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Declined();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Different("hola", "hello");
			Assert.AreEqual(0, validathor.Errors().Count);
		}

		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Between(0, 1);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Email()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Email();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void EndsWith()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).EndsWith("a,s,d".Split(","));
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Gt()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Gt("Hola");
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Gte()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Gte("hola");
			Assert.AreEqual(1, validathor.Errors().Count);

		}


		[Test]
		public void In()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).In("a,s,d,f".Split(','));
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Integer()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Integer();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Ip()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Ip();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Ipv4()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Ipv4();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Ipv6()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Ipv6();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Json()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Json();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Lt()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Lt("hola");
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Lte()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Lte("Hola");
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Max()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Max(1);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Min()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Min(0);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void NotIn()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).NotIn(ends);
			Assert.AreEqual(0, validathor.Errors().Count);

		}



		[Test]
		public void NotRegexString()
		{
			string regex = "(^[a-z]+$)";
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).NotRegex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void NotRegex()
		{
			Regex regex = new Regex("(^[a-z]+$)", RegexOptions.IgnoreCase);
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).NotRegex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}


		[Test]
		public void Numeric()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Numeric();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void RegexString()
		{
			string regex = "(^[a-z]+$)";
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Regex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Regex()
		{
			Regex regex = new Regex("(^[a-z]+$)", RegexOptions.IgnoreCase);
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Regex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Required()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Required();
			Assert.AreEqual(1, validathor.Errors().Count);

		}
		[Test]
		public void Same()
		{
			
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Same("Hola","Hola");
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void StartsWith()
		{
			string[] ends = { "em", "os", "no" };
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).StartsWith(ends);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Size()
		{
			int ends = 9;
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Size(6);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Url()
		{
			Validathor validathor = new Validathor("es");
			validathor.Cadena("Nulo", null).Accepted();
			Assert.AreEqual(1, validathor.Errors().Count);
		}
	}
}
