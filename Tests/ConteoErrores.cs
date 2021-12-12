using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValidaThor;

namespace Tests
{
	public class CadenaErrores
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Accepted()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("confirmación", "yes").Accepted();
			validathor.Cadena("confirmación", "on").Accepted();
			validathor.Cadena("confirmación", "true").Accepted();
			validathor.Cadena("confirmación", "ok").Accepted();
			validathor.Cadena("confirmación", "No tiene sentido esto").Accepted();
			validathor.Cadena("confirmación", "Es más que obvio que esto va a fallar.").Accepted();
			Assert.AreEqual(3, validathor.Errors().Count);
		}

		[Test]
		public void ActiveUrl()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("url", "https://generated.photos/face-generator/new").ActiveUrl();
			validathor.Cadena("url", "https://www.klsajdlksad.com/").ActiveUrl();
			validathor.Cadena("url", "true").ActiveUrl();
			validathor.Cadena("url", "ok").ActiveUrl();
			validathor.Cadena("url", "No tiene sentido esto").Accepted();
			validathor.Cadena("url", "Es más que obvio que esto va a fallar.").Accepted();
			Assert.AreEqual(5, validathor.Errors().Count);
		}


		[Test]
		public void Alpha()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("Letras", "https://generated.photos/face-generator/new").Alpha();
			validathor.Cadena("Letras", "https://www.klsajdlksad.com/").Alpha();
			validathor.Cadena("Letras", "true").Alpha();
			validathor.Cadena("Letras", "ok").Alpha();
			validathor.Cadena("Letras", "11ok11").Alpha();
			validathor.Cadena("Letras", "o11k").Alpha();
			validathor.Cadena("Letras", "No tiene sentido esto").Alpha();
			validathor.Cadena("Letras", "Es más que obvio que esto va a fallar.").Alpha();
			Assert.AreEqual(6, validathor.Errors().Count);
		}

		[Test]
		public void AlphaDash()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("Letras", "https://generated.photos/face-generator/new").AlphaDash();
			validathor.Cadena("Letras", "https://www.klsajdlksad.com/").AlphaDash();
			validathor.Cadena("Letras", "true").AlphaDash();
			validathor.Cadena("Letras", "ok").AlphaDash();
			validathor.Cadena("Letras", "11ok11").AlphaDash();
			validathor.Cadena("Letras", "o11k").AlphaDash();
			validathor.Cadena("Letras", "_o11k").AlphaDash();
			validathor.Cadena("Letras", "o1_1k").AlphaDash();
			validathor.Cadena("Letras", "o11k_").AlphaDash();
			validathor.Cadena("Letras", "-o1-1k_").AlphaDash();
			validathor.Cadena("Letras", "No tiene sentido esto").AlphaDash();
			validathor.Cadena("Letras", "Es más que obvio que esto va a fallar.").AlphaDash();
			Assert.AreEqual(4, validathor.Errors().Count);
		}

		[Test]
		public void AlphaNum()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("Letras", "https://generated.photos/face-generator/new").AlphaNum();
			validathor.Cadena("Letras", "https://www.klsajdlksad.com/").AlphaNum();
			validathor.Cadena("Letras", "true").AlphaNum();
			validathor.Cadena("Letras", "ok").AlphaNum();
			validathor.Cadena("Letras", "11ok11").AlphaNum();
			validathor.Cadena("Letras", "o11k").AlphaNum();
			validathor.Cadena("Letras", "_o11k").AlphaNum();
			validathor.Cadena("Letras", "o1_1k").AlphaNum();
			validathor.Cadena("Letras", "o11k_").AlphaNum();
			validathor.Cadena("Letras", "-o1-1k_").AlphaNum();
			validathor.Cadena("Letras", "No tiene sentido esto").AlphaNum();
			validathor.Cadena("Letras", "Es más que obvio que esto va a fallar.").AlphaNum();
			Assert.AreEqual(8, validathor.Errors().Count);
		}


		[Test]
		public void Boolean()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("booleano", "https://generated.photos/face-generator/new").Boolean();
			validathor.Cadena("booleano", "https://www.klsajdlksad.com/").Boolean();
			validathor.Cadena("booleano", "true").Boolean();
			validathor.Cadena("booleano", "false").Boolean();
			validathor.Cadena("booleano", "No tiene sentido esto").Boolean();
			validathor.Cadena("booleano", "Es más que obvio que esto va a fallar.").Boolean();
			Assert.AreEqual(4, validathor.Errors().Count);
		}


		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("password", "https://generated.photos/face-generator/new").Confirmed("dsd");
			validathor.Cadena("password", "https://www.klsajdlksad.com/").Confirmed("dsads");
			validathor.Cadena("password", "1234567890").Confirmed("1234567890");
			validathor.Cadena("password", "contraseña123").Confirmed("contraseña123");
			validathor.Cadena("password", "No tiene sentido esto").Confirmed("");
			validathor.Cadena("boleano", "Es más que obvio que esto va a fallar.").Confirmed("");
			Assert.AreEqual(4, validathor.Errors().Count);
		}

		[Test]
		public void Declined()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("Acepta vender sus órganos", "https://generated.photos/face-generator/new").Declined();
			validathor.Cadena("Acepta vender sus órganos", "https://www.klsajdlksad.com/").Declined();
			validathor.Cadena("Acepta vender sus órganos", "no").Declined();
			validathor.Cadena("Acepta vender sus órganos", "false").Declined();
			validathor.Cadena("Acepta vender sus órganos", "off").Declined();
			validathor.Cadena("Acepta vender sus órganos", "Es más que obvio que esto va a fallar.").Declined();
			Assert.AreEqual(3, validathor.Errors().Count);
		}

		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("Nueva contraseña", "1234567890").Different("Contraseña anterior", "1234567890");
			validathor.Cadena("Nueva contraseña", "09876543210").Different("Contraseña anterior", "1234567890");
			validathor.Cadena("Nueva contraseña", "no").Different("Contraseña anterior", "1234567890");
			validathor.Cadena("Nueva contraseña", "false").Different("Contraseña anterior", "1234567890");
			validathor.Cadena("Nueva contraseña", "off").Different("Contraseña anterior", "1234567890");
			validathor.Cadena("Nueva contraseña", "Es más que obvio que esto va a fallar.").Different("Contraseña anterior", "1234567890");
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("password", "12345678").Between(10, 20);
			validathor.Cadena("password", "123456789012345678901").Between(10, 20);
			validathor.Cadena("password", "1234567890").Between(10, 20);
			validathor.Cadena("password", "12345678901").Between(10, 20);
			validathor.Cadena("password", "12345678901234567890").Between(10, 20);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Email()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "email").Email();
			validathor.Cadena("correo", "email@test.com").Email();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void EndsWith()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "email").EndsWith(ends);
			validathor.Cadena("correo", "Habla").EndsWith(ends);
			validathor.Cadena("correo", "Operativos").EndsWith(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").EndsWith(ends);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Gt()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "hola").Gt(ends);
			validathor.Cadena("correo", "Ho").Gt(ends);
			validathor.Cadena("correo", "Operativos").Gt(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Gt(ends);
			Assert.AreEqual(2, validathor.Errors().Count);

		}

		[Test]
		public void Gte()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "hola").Gte(ends);
			validathor.Cadena("correo", "Ho").Gte(ends);
			validathor.Cadena("correo", "Operativos").Gte(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Gte(ends);
			Assert.AreEqual(1, validathor.Errors().Count);

		}


		[Test]
		public void In()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").In(ends);
			validathor.Cadena("correo", "Habla").In(ends);
			validathor.Cadena("correo", "Operativos").In(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").In(ends);
			Assert.AreEqual(3, validathor.Errors().Count);

		}

		[Test]
		public void Integer()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("telefono", "1234567890").Integer();
			validathor.Cadena("telefono", "1234567pop").Integer();
			validathor.Cadena("telefono", "11.0").Integer();
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Ip()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("ip", "12345.67890").Ip();
			validathor.Cadena("ip", "fe80::1ce2:e22a:62df:6ec%17").Ip();
			validathor.Cadena("ip", "11.0.0.0").Ip();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Ipv4()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("ip", "12345.67890").Ipv4();
			validathor.Cadena("ip", "fe80::1ce2:e22a:62df:6ec%17").Ipv4();
			validathor.Cadena("ip", "11.0.0.0").Ipv4();
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Ipv6()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("ip", "12345.67890").Ipv6();
			validathor.Cadena("ip", "fe80::1ce2:e22a:62df:6ec%17").Ipv6();
			validathor.Cadena("ip", "11.0.0.0").Ipv6();
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Json()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("json", "12345.67").Json();
			validathor.Cadena("json", "fe80::1ce2:e22a:62df:6ec%17").Json();
			validathor.Cadena("json", "11.0.0.0").Json();
			validathor.Cadena("json", "{'hola':'como','estas':'tu'}").Json();
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Lt()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "hola").Lt(ends);
			validathor.Cadena("correo", "Ho").Lt(ends);
			validathor.Cadena("correo", "Operativos").Lt(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Lt(ends);
			Assert.AreEqual(3, validathor.Errors().Count);

		}

		[Test]
		public void Lte()
		{
			string ends = "hola";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "hola").Lte(ends);
			validathor.Cadena("correo", "Ho").Lte(ends);
			validathor.Cadena("correo", "Operativos").Lte(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Lte(ends);
			Assert.AreEqual(2, validathor.Errors().Count);

		}

		[Test]
		public void Max()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("prueba", "hola").Max(2);
			validathor.Cadena("prueba", "hola").Max(4);
			validathor.Cadena("prueba", "hola").Max(3);
			validathor.Cadena("prueba", "hola").Max(5);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Min()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("prueba", "hola").Min(2);
			validathor.Cadena("prueba", "hola").Min(4);
			validathor.Cadena("prueba", "hola").Min(3);
			validathor.Cadena("prueba", "hola").Min(5);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void NotIn()
		{
			string[] ends = { "la", "os", "no" };
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").NotIn(ends);
			validathor.Cadena("correo", "Habla").NotIn(ends);
			validathor.Cadena("correo", "Operativos").NotIn(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").NotIn(ends);
			Assert.AreEqual(1, validathor.Errors().Count);

		}



		[Test]
		public void NotRegexString()
		{
			string regex = "(^[a-z]+$)";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").NotRegex(regex);
			validathor.Cadena("correo", "Habla").NotRegex(regex);
			validathor.Cadena("correo", "Operativos").NotRegex(regex);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").NotRegex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void NotRegex()
		{
			Regex regex = new Regex("(^[a-z]+$)", RegexOptions.IgnoreCase);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").NotRegex(regex);
			validathor.Cadena("correo", "Habla").NotRegex(regex);
			validathor.Cadena("correo", "Operativos").NotRegex(regex);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").NotRegex(regex);
			Assert.AreEqual(3, validathor.Errors().Count);

		}


		[Test]
		public void Numeric()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("prueba", "10.5").Numeric();
			validathor.Cadena("prueba", "10.0").Numeric();
			validathor.Cadena("prueba", "5").Numeric();
			validathor.Cadena("prueba", "hola").Numeric();
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void RegexString()
		{
			string regex = "(^[a-z]+$)";
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").Regex(regex);
			validathor.Cadena("correo", "Habla").Regex(regex);
			validathor.Cadena("correo", "Operativos").Regex(regex);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Regex(regex);
			Assert.AreEqual(3, validathor.Errors().Count);

		}

		[Test]
		public void Regex()
		{
			Regex regex = new Regex("(^[a-z]+$)", RegexOptions.IgnoreCase);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").Regex(regex);
			validathor.Cadena("correo", "Habla").Regex(regex);
			validathor.Cadena("correo", "Operativos").Regex(regex);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Regex(regex);
			Assert.AreEqual(1, validathor.Errors().Count);

		}

		[Test]
		public void Required()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "os").Required();
			validathor.Cadena("correo", "").Required();
			validathor.Cadena("correo", null).Required();
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Required();
			Assert.AreEqual(2, validathor.Errors().Count);

		}


		[Test]
		public void StartsWith()
		{
			string[] ends = { "em", "os", "no" };
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "email").StartsWith(ends);
			validathor.Cadena("correo", "Habla").StartsWith(ends);
			validathor.Cadena("correo", "Operativos").StartsWith(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").StartsWith(ends);
			Assert.AreEqual(3, validathor.Errors().Count);

		}

		[Test]
		public void Size()
		{
			int ends = 9;
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("correo", "email").Size(ends);
			validathor.Cadena("correo", "Habla").Size(ends);
			validathor.Cadena("correo", "123456789").Size(ends);
			validathor.Cadena("correo", "No se me ocurre algo que teminé con no").Size(ends);
			Assert.AreEqual(3, validathor.Errors().Count);

		}

		[Test]
		public void Url()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("url", "https://generated.photos/face-generator/new").Url();
			validathor.Cadena("url", "https://www.klsajdlksad.com/").Url();
			validathor.Cadena("url", "true").Url();
			validathor.Cadena("url", "ok").Url();
			validathor.Cadena("url", "No tiene sentido esto").Url();
			validathor.Cadena("url", "Es más que obvio que esto va a fallar.").Url();
			Assert.AreEqual(4, validathor.Errors().Count);
		}
	}

	public class FechaErrores
	{
		[Test]
		public void After()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).After(anterior.Date); //
			validathor.Fecha("prueba", actual.Date).After(actual.Date);
			validathor.Fecha("prueba", actual).After(actual);

			anterior = anterior.AddDays(1).AddSeconds(-1);
			validathor.Fecha("prueba", actual).After(anterior);//
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void AfterOrEqual()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).AfterOrEqual(anterior.Date);//
			validathor.Fecha("prueba", actual.Date).AfterOrEqual(actual.Date);//
			validathor.Fecha("prueba", actual).AfterOrEqual(actual);//

			anterior = anterior.AddDays(1).AddSeconds(1);
			validathor.Fecha("prueba", actual).AfterOrEqual(anterior);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Before()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).Before(anterior.Date); //
			validathor.Fecha("prueba", actual.Date).Before(actual.Date);
			validathor.Fecha("prueba", actual).Before(actual);

			anterior = anterior.AddDays(3);
			validathor.Fecha("prueba", actual).Before(anterior);//
			Assert.AreEqual(3, validathor.Errors().Count);
		}

		[Test]
		public void BeforeOrEqual()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).BeforeOrEqual(anterior.Date);//
			validathor.Fecha("prueba", actual.Date).BeforeOrEqual(actual.Date);//
			validathor.Fecha("prueba", actual).BeforeOrEqual(actual);//

			anterior = anterior.AddDays(1).AddSeconds(-1);
			validathor.Fecha("prueba", actual).BeforeOrEqual(anterior);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Between()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddSeconds(-1);
			DateTime posterior = actual.AddSeconds(1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual).Between(anterior, posterior);
			validathor.Fecha("prueba", actual).Between(posterior, anterior);
			validathor.Fecha("prueba", actual).Between(actual, posterior);
			validathor.Fecha("prueba", actual).Between(anterior, actual);
			anterior = anterior.AddDays(-1);
			posterior = posterior.AddDays(1);
			validathor.Fecha("prueba", actual.Date).Between(anterior.Date, posterior.Date);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Confirmed()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).Confirmed(anterior.Date);//
			validathor.Fecha("prueba", actual.Date).Confirmed(actual.Date);//
			validathor.Fecha("prueba", actual).Confirmed(actual);//

			anterior = anterior.AddDays(1).AddSeconds(-1);
			validathor.Fecha("prueba", actual).Confirmed(anterior);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Different()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).Different("fecha", anterior.Date);//
			validathor.Fecha("prueba", actual.Date).Different("fecha", actual.Date);//
			validathor.Fecha("prueba", actual).Different("fecha", actual);//

			anterior = anterior.AddDays(1).AddSeconds(-1);
			validathor.Fecha("prueba", actual).Different("fecha", anterior);
			Assert.AreEqual(2, validathor.Errors().Count);
		}


		[Test]
		public void Equals()
		{
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-1);
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual.Date).Same("prueba2", anterior.Date);//
			validathor.Fecha("prueba", actual.Date).Same("prueba2", actual.Date);//
			validathor.Fecha("prueba", actual).Same("prueba2", actual);//

			anterior = anterior.AddDays(1).AddSeconds(-1);
			validathor.Fecha("prueba", actual).Same("prueba2", anterior);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Required()
		{
			DateTime actual = DateTime.Now;
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("prueba", actual).Required();
			validathor.Fecha("prueba", null).Required();
			Assert.AreEqual(1, validathor.Errors().Count);
		}
	}

	public class ListaErrores
	{
	

		[SetUp]
		public void Setup()
		{
			
		}

		[Test]
		public void Between()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Between(1, 2);
			validathor.Lista("prueba", lista).Between(1, 4);
			validathor.Lista("prueba", lista).Between(1, 5);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Confirmed()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			List<String> lista2 = new List<String>();
			lista2.Add("A");
			lista2.Add("B");
			lista2.Add("C");
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Confirmed(lista);
			validathor.Lista("prueba", lista).Confirmed(lista2);

			lista2.Add("D");
			validathor.Lista("prueba", lista).Confirmed(lista2);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Different()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			List<String> lista2 = new List<String>();
			lista2.Add("A");
			lista2.Add("B");
			lista2.Add("C");
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Different("lista", lista);
			validathor.Lista("prueba", lista).Different("lista", lista2);

			lista2.Add("D");
			validathor.Lista("prueba", lista).Different("lista", lista2);
			Assert.AreEqual(2, validathor.Errors().Count);
		}

		[Test]
		public void Same()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			List<String> lista2 = new List<String>();
			lista2.Add("A");
			lista2.Add("B");
			lista2.Add("C");
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Same("lista2", lista);
			validathor.Lista("prueba", lista).Same("lista2", lista2);

			lista2.Add("D");
			validathor.Lista("prueba", lista).Same("lista2", lista2);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Max()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Max(2);
			validathor.Lista("prueba", lista).Max(4);
			validathor.Lista("prueba", lista).Max(5);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Min()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Min(2);
			validathor.Lista("prueba", lista).Min(4);
			validathor.Lista("prueba", lista).Min(5);
			Assert.AreEqual(1, validathor.Errors().Count);
		}


		[Test]
		public void Required()
		{
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			lista.Add("D");

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Lista("prueba", lista).Required();
			validathor.Lista("prueba", null).Required();
			validathor.Lista("prueba", new List<String>()).Required();
			Assert.AreEqual(2, validathor.Errors().Count);
		}
	}


	public class NumeroErrores
	{
		Decimal numero = 0;

		[SetUp]
		public void Setup()
		{
			numero = 40;
		}

		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Between(40, 50);
			validathor.Numero("prueba", numero).Between(1, 40);
			validathor.Numero("prueba", numero).Between(1, 5);
			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Confirmed()
		{
			
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Confirmed(40);
			validathor.Numero("prueba", numero).Confirmed(41);

			Assert.AreEqual(1, validathor.Errors().Count);
		}


		[Test]
		public void Different()
		{

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Different("numero", 40);
			validathor.Numero("prueba", numero).Different("numero", 41);

			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Same()
		{

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Same("prueba2", 40);
			validathor.Numero("prueba", numero).Same("prueba2", 41);

			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Max()
		{

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Max(40);
			validathor.Numero("prueba", numero).Max(39);

			Assert.AreEqual(1, validathor.Errors().Count);
		}

		[Test]
		public void Min()
		{

			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("prueba", numero).Min(40);
			validathor.Numero("prueba", numero).Min(49);

			Assert.AreEqual(1, validathor.Errors().Count);
		}
	}
}
