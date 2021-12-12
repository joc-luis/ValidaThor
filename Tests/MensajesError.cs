using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ValidaThor;
namespace Tests
{
	public class Cadenas
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Accepted()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("condiciones", "no").Accepted();
			Assert.AreEqual("Condiciones debe ser aceptado.", validathor.Errors().First());
			
		}


		[Test]
		public void ActiveUrl()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("pagina", "").ActiveUrl();
			Assert.AreEqual("Pagina no es una URL válida.", validathor.Errors().First());
			
		}

		[Test]
		public void Alpha()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("letras", "334234").Alpha();
			Assert.AreEqual("Letras sólo debe contener letras.", validathor.Errors().First());
			
		}

		[Test]
		public void AlphaDash()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("letras", "@").AlphaDash();
			Assert.AreEqual("Letras sólo debe contener letras, números, guiones y guiones bajos.", validathor.Errors().First());
			
		}

		[Test]
		public void AlphaNum()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("letras", "-").AlphaNum();
			Assert.AreEqual("Letras sólo debe contener letras y números.", validathor.Errors().First());
			
		}

		[Test]
		public void Boolean()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Boolean();
			Assert.AreEqual("El campo boolean debe tener un valor verdadero o falso.", validathor.Errors().First());
			
		}

		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Confirmed("yes");
			Assert.AreEqual("La confirmación de boolean no coincide.", validathor.Errors().First());
			
		}

		[Test]
		public void Declined()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Declined();
			Assert.AreEqual("Boolean debe ser rechazado.", validathor.Errors().First());
			
		}

		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Different("hola", "ya");
			Assert.AreEqual("Boolean y hola deben ser diferentes.", validathor.Errors().First());
			
		}

		

		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Between(3, 4);
			Assert.AreEqual("Boolean tiene que tener entre 3 - 4 caracteres.", validathor.Errors().First());

		}

		[Test]
		public void Email()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Email();
			Assert.AreEqual("Boolean no es un correo válido.", validathor.Errors().First());

		}

		[Test]
		public void EndsWith()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").EndsWith("haha,kskd,llo".Split(","));
			Assert.AreEqual("El campo boolean debe finalizar con uno de los siguientes valores: haha, kskd, llo.", validathor.Errors().First());

		}


		[Test]
		public void Gt()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Gt("haha");
			Assert.AreEqual("El campo boolean debe tener más de 4 caracteres.", validathor.Errors().First());

		}

		[Test]
		public void Gte()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Gte("haha");
			Assert.AreEqual("El campo boolean debe tener como mínimo 4 caracteres.", validathor.Errors().First());

		}

		[Test]
		public void In()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").In("haha, haha".Split(","));
			Assert.AreEqual("Boolean es inválido.", validathor.Errors().First());

		}

		[Test]
		public void Integer()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Integer();
			Assert.AreEqual("Boolean debe ser un número entero.", validathor.Errors().First());

		}


		[Test]
		public void Ip()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Ip();
			Assert.AreEqual("Boolean debe ser una dirección IP válida.", validathor.Errors().First());

		}

		[Test]
		public void Ipv4()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Ipv4();
			Assert.AreEqual("Boolean debe ser una dirección IPv4 válida.", validathor.Errors().First());

		}

		[Test]
		public void Ipv6()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Ipv6();
			Assert.AreEqual("Boolean debe ser una dirección IPv6 válida.", validathor.Errors().First());

		}

		[Test]
		public void Json()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "{ya}").Json();
			Assert.AreEqual("El campo boolean debe ser una cadena JSON válida.", validathor.Errors().First());

		}

		[Test]
		public void Lt()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "WiiU2").Lt("hola");
			Assert.AreEqual("El campo boolean debe tener menos de 4 caracteres.", validathor.Errors().First());

		}
		[Test]
		public void Lte()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "{ya}").Lte("s");
			Assert.AreEqual("El campo boolean debe tener como máximo 1 caracteres.", validathor.Errors().First());

		}
		[Test]
		public void Max()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "{ya}").Max(1);
			Assert.AreEqual("Boolean no debe ser mayor que 1 caracteres.", validathor.Errors().First());

		}
		
		[Test]
		public void Min()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "{ya}").Min(5);
			Assert.AreEqual("Boolean debe contener al menos 5 caracteres.", validathor.Errors().First());

		}

		[Test]
		public void NotIn()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "{ya}").NotIn("{ya},r,e".Split(","));
			Assert.AreEqual("Boolean es inválido.", validathor.Errors().First());

		}

		[Test]
		public void NotRegexString()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").NotRegex("[a-z]+");
			Assert.AreEqual("El formato del campo boolean no es válido.", validathor.Errors().First());

		}

		[Test]
		public void NotRegex()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			Regex regex = new Regex("[a-z]+", RegexOptions.IgnoreCase);
			validathor.Cadena("boolean", "ya").NotRegex(regex);
			Assert.AreEqual("El formato del campo boolean no es válido.", validathor.Errors().First());

		}

		[Test]
		public void Numeric()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Numeric();
			Assert.AreEqual("Boolean debe ser numérico.", validathor.Errors().First());

		}

		[Test]
		public void RegexString()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "16").Regex("[a-z]+");
			Assert.AreEqual("El formato de boolean es inválido.", validathor.Errors().First());

		}

		[Test]
		public void Regex()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			Regex regex = new Regex("[a-z]+", RegexOptions.IgnoreCase);
			validathor.Cadena("boolean", "15").Regex(regex);
			Assert.AreEqual("El formato de boolean es inválido.", validathor.Errors().First());

		}

		[Test]
		public void StartsWith()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "15").StartsWith("rt,78,90".Split(","));
			Assert.AreEqual("El campo boolean debe comenzar con uno de los siguientes valores: rt, 78, 90.", validathor.Errors().First());

		}

		[Test]
		public void Size()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Size(3);
			Assert.AreEqual("Boolean debe contener 3 caracteres.", validathor.Errors().First());

		}

		[Test]
		public void Url()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Cadena("boolean", "ya").Url();
			Assert.AreEqual("Boolean debe ser una URL válida.", validathor.Errors().First());

		}
	}

	public class Fechas
	{

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void After()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(1);
			validathor.Fecha("actual", actual).After(anterior);
			Assert.AreEqual("Actual debe ser una fecha posterior a "+anterior.ToString("yyyy-MM-dd HH:mm:ss")+".", validathor.Errors().First());
		}

		[Test]
		public void AfterOrEqual()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(1);
			validathor.Fecha("actual", DateTime.Now).AfterOrEqual(DateTime.Now.AddDays(1));
			Assert.AreEqual("Actual debe ser una fecha posterior o igual a " + anterior.ToString("yyyy-MM-dd HH:mm:ss") + ".", validathor.Errors().First());
		}

		[Test]
		public void Before()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-2);
			validathor.Fecha("actual", DateTime.Now).Before(DateTime.Now.AddDays(-2));
			Assert.AreEqual("Actual debe ser una fecha anterior a " + anterior.ToString("yyyy-MM-dd HH:mm:ss") + ".", validathor.Errors().First());
		}

		[Test]
		public void BeforeOrEqual()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-2);
			validathor.Fecha("actual", DateTime.Now).BeforeOrEqual(DateTime.Now.AddDays(-2));
			Assert.AreEqual("Actual debe ser una fecha anterior o igual a " + anterior.ToString("yyyy-MM-dd HH:mm:ss") + ".", validathor.Errors().First());
		}

		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			DateTime anterior = actual.AddDays(-2);
			DateTime posterior = actual.AddDays(-1);
			validathor.Fecha("actual", DateTime.Now).Between(anterior, posterior);
			Assert.AreEqual("Actual tiene que estar entre " + anterior.ToString("yyyy-MM-dd HH:mm:ss") + " - "+ posterior.ToString("yyyy-MM-dd HH:mm:ss") + ".", validathor.Errors().First());
		}

		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("actual", DateTime.Now).Confirmed(DateTime.Now.AddDays(2));
			Assert.AreEqual("La confirmación de actual no coincide.", validathor.Errors().First());
		}


		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			DateTime actual = DateTime.Now;
			validathor.Fecha("actual", actual).Different("futuro", actual);
			Assert.AreEqual("Actual y futuro deben ser diferentes.", validathor.Errors().First());
		}

		[Test]
		public void Same()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Fecha("actual", DateTime.Now).Same("futuro", DateTime.Now.AddDays(2));
			Assert.AreEqual("Actual y futuro deben coincidir.", validathor.Errors().First());
		}
	}

	public class Listas
	{
		[SetUp]
		public void Setup()
		{

		}


		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			validathor.Lista("lista", lista).Between(10, 11);
			Assert.AreEqual("Lista tiene que tener entre 10 - 11 elementos.", validathor.Errors().First());
		}


		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			var lista2 = new List<String>();
			lista2.AddRange(lista);
			lista2.Add("D");
			
			validathor.Lista("lista", lista).Confirmed(lista2);
			Assert.AreEqual("La confirmación de lista no coincide.", validathor.Errors().First());
		}


		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			var lista2 = new List<String>();
			lista2.AddRange(lista);
			validathor.Lista("lista", lista).Different("lista2", lista2);
			Assert.AreEqual("Lista y lista2 deben ser diferentes.", validathor.Errors().First());
		}

		[Test]
		public void Same()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
			var lista2 = new List<String>();
			lista2.AddRange(lista);
			lista2.Add("D");
			validathor.Lista("lista", lista).Same("lista2", lista2);
			Assert.AreEqual("Lista y lista2 deben coincidir.", validathor.Errors().First());
		}

		[Test]
		public void Max()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");
		
			validathor.Lista("lista", lista).Max(2);
			Assert.AreEqual("Lista no debe tener más de 2 elementos.", validathor.Errors().First());
		}


		[Test]
		public void Min()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			List<String> lista = new List<String>();
			lista.Add("A");
			lista.Add("B");
			lista.Add("C");

			validathor.Lista("lista", lista).Min(5);
			Assert.AreEqual("Lista debe tener al menos 5 elementos.", validathor.Errors().First());
		}

	}

	public class Numero
	{
		[SetUp]
		public void Setup()
		{

		}


		[Test]
		public void Between()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("lista", 5).Between(10, 11);
			Assert.AreEqual("Lista tiene que estar entre 10 - 11.", validathor.Errors().First());
		}


		[Test]
		public void Confirmed()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("lista", 10).Confirmed(12);
			Assert.AreEqual("La confirmación de lista no coincide.", validathor.Errors().First());
		}


		[Test]
		public void Different()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("lista", 10).Different("lista2", 10);
			Assert.AreEqual("Lista y lista2 deben ser diferentes.", validathor.Errors().First());
		}

		[Test]
		public void Same()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("numero", 8).Same("numero2", 10);
			Assert.AreEqual("Numero y numero2 deben coincidir.", validathor.Errors().First());
		}

		[Test]
		public void Max()
		{
			Validathor validathor = new Validathor("./lang/es.json");

			validathor.Numero("lista", 6).Max(2);
			Assert.AreEqual("Lista no debe ser mayor que 2.", validathor.Errors().First());
		}


		[Test]
		public void Min()
		{
			Validathor validathor = new Validathor("./lang/es.json");
			validathor.Numero("lista", 2).Min(5);
			Assert.AreEqual("El tamaño de lista debe ser de al menos 5.", validathor.Errors().First());
		}
	}
}