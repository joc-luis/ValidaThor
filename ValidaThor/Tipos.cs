using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
namespace ValidaThor
{

	/// <summary>
	/// Validaciones para tipo String.
	/// </summary>
	public class Cadena : General
	{


		/// <summary>
		/// Inicializa los parametros de la clase
		/// </summary>
		/// <param name="name">Abreviatura del lenguaje.</param>
		public Cadena(String name)
		{
			this.ChangeLanguage(name);
		}

		/// <summary>
		/// Valor del campo a evaluar
		/// </summary>
		private String Value = "";

		/// <summary>
		/// Indica si esta permitido que el valor sea nulo
		/// </summary>
		private Boolean _Nullable = false;

		/// <summary>
		/// Asigna el nombre y valor del campo a evaluar.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor del campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Field(String name, String value)
		{
			this.Name = name;
			this.Value = value;
			this._Nullable = false;

			return this;
		}


		/// <summary>
		/// Comprueba si el valor es nulo y esta permitido.
		/// </summary>
		/// <returns>
		/// true si es valor es nulo y esta permitido false si no es así
		/// </returns>
		private Boolean IsNull()
		{
			if (this._Nullable && (this.Value == null || this.Value.Length <= 0))
			{
				return true;
			}

			return false;
		}


		/// <summary>
		/// Comprueba que el valor evaluado sea "yes", "on" o "true".
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Accepted()
		{
			if (this.IsNull())
			{
				return this;
			}

			if (!"yes on true".Split(" ").ToList().Contains(this.Value))
			{
				this.AddError("accepted");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea una url accesible.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena ActiveUrl()
		{
			try
			{
				var request = WebRequest.Create(this.Value).GetResponse().GetResponseStream();
			}
			catch (Exception)
			{

				this.AddError("active_url");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor se componga unicamente de caracteres alfabéticos.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Alpha()
		{

			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex("(^[a-záéíóúñ]+$)", RegexOptions.IgnoreCase);

			if (!regex.IsMatch(this.Value))
			{
				this.AddError("alpha");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor solo contenga caracteres alfabéticos, guiones y guiones medios.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena AlphaDash()
		{

			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex("(^[a-z0-9áéíóúñ_-]+$)", RegexOptions.IgnoreCase);

			if (!regex.IsMatch(this.Value))
			{
				this.AddError("alpha_dash");
			}

			return this;
		}

		/// <summary>
		/// Compurbea que el valor solo contenga caracteres alfanuméricos.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena AlphaNum()
		{
			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex("(^[a-z0-9áéíóúñ]+$)", RegexOptions.IgnoreCase);

			if (!regex.IsMatch(this.Value))
			{
				this.AddError("alpha_num");
			}
			return this;
		}

		/// <summary>
		/// Comprueba si el valor es "true" o "false".
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Boolean()
		{

			if (this.IsNull())
			{
				return this;
			}

			if (this.Value != "true" && this.Value != "false")
			{
				this.AddError("boolean");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor tenga una longitud entre dos valores
		/// </summary>
		/// <param name="min">
		/// Longitud mínima
		/// </param>
		/// <param name="max">
		/// Longitud máxima
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Between(int min, int max)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (min >= this.Value.Length && this.Value.Length <= max)
			{
				this.AddError("between", min, max);
			}

			return this;
		}



		/// <summary>
		/// Comprueba que el valor sea igual a otro usado como confirmación.
		/// </summary>
		/// <param name="valor">
		/// Valor del campo de referencia
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Confirmed(String valor)
		{

			if (this.IsNull())
			{
				return this;
			}

			if (this.Value != valor)
			{
				this.AddError("confirmed");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea "no", "off" o "false"
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Declined()
		{

			if (this.IsNull())
			{
				return this;
			}

			if (!"no off false".Split(" ").ToList().Contains(this.Value))
			{
				this.AddError("declined");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor sea difrente a un campo de referencia.
		/// </summary>
		/// <param name="nombre">
		/// Nombre del campo de referencia
		/// </param>
		/// <param name="valor">
		/// Valor del campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Different(String nombre, String valor)
		{

			if (this.IsNull())
			{
				return this;
			}

			if (this.Value == valor)
			{
				this.AddError("different", nombre);
			}

			return this;
		}


		


		/// <summary>
		/// Comprueba que el valor sea una dirección de email valida. Nota: Solo valida que sea un email, no que exista.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Email()
		{
			if (this.IsNull())
			{
				return this;
			}

			try
			{
				new System.Net.Mail.MailAddress(this.Value);
			}
			catch (Exception)
			{

				this.AddError("email");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor termine al menos con uno de los elementos dados.
		/// </summary>
		/// <param name="payload">
		/// Elementos validos de terminación.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena EndsWith(String[] payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			bool pass = false;
			foreach (var item in payload)
			{
				if (this.Value.EndsWith(item))
				{
					pass = true;
					break;
				}
			}

			if (!pass)
			{
				this.AddError("ends_with", payload);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor tenga una longitud mayor a la de un campo de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor del campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Gt(String valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length <= valor.Length)
			{
				this.AddError("gt", valor.Length);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor tenga una longitud mayor o igual a la de un campo de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor del campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Gte(String valor)
		{
			if (this.IsNull())
			{
				return this;
			}


			if (this.Value.Length < valor.Length)
			{
				this.AddError("gte", valor.Length);
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor este dentro de una lista de cadenas validas.
		/// </summary>
		/// <param name="payload">
		/// Valores permitidos.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena In(String[] payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (!payload.ToList().Contains(this.Value))
			{
				this.AddError("in", payload);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea un entero.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Integer()
		{
			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex("^([0-9]+)$");

			if (!regex.IsMatch(this.Value))
			{
				this.AddError("integer");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea una ip valida (IPv4 o IPv6)
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Ip()
		{
			if (this.IsNull())
			{
				return this;
			}

			try
			{
				var ip = IPAddress.Parse(this.Value);

				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
					ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
				{
					this.AddError("ip");
				}
			}
			catch (Exception)
			{

				this.AddError("ip");
			}


			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea una ipv4 valida.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Ipv4()
		{
			if (this.IsNull())
			{
				return this;
			}

			try
			{
				var ip = IPAddress.Parse(this.Value);

				if (!(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
				{
					this.AddError("ipv4");
				}
			}
			catch (Exception)
			{

				this.AddError("ipv4");
			}


			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea una ipv6 valida.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Ipv6()
		{

			if (this.IsNull())
			{
				return this;
			}

			try
			{
				var ip = IPAddress.Parse(this.Value);

				if (!(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
				{
					this.AddError("ipv6");
				}
			}
			catch (Exception)
			{

				this.AddError("ipv6");
			}
			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea un cadena JSON valida.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Json()
		{

			if (this.IsNull())
			{
				return this;
			}

			try
			{
				JsonConvert.DeserializeObject(this.Value);
			}
			catch (Exception)
			{

				this.AddError("json");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor tenga una longitud menor a la de una campo de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor de campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Lt(String valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length >= valor.Length)
			{
				this.AddError("lt", valor.Length);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor tenga una longitud menor o igual a la de una campo de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor de campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Lte(String valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length > valor.Length)
			{
				this.AddError("lte", valor.Length);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que la longitud del valor no sea mayor al máximo establecido.
		/// </summary>
		/// <param name="max">
		/// Longitud máxima.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Max(int max)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length > max)
			{
				this.AddError("max", max);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que la longitud del valor no sea menor al mínimo establecido.
		/// </summary>
		/// <param name="min">
		/// Longitud máxima.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Min(int min)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length < min)
			{
				this.AddError("min", min);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor no este dentro de una arreglo.
		/// </summary>
		/// <param name="payload">
		/// Valores no permitidos
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena NotIn(String[] payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (payload.ToList().Contains(this.Value))
			{
				this.AddError("not_in");
			}
			return this;
		}


		/// <summary>
		/// Comprueba que el valor no cumpla con la expresión regular dada.
		/// </summary>
		/// <param name="pattern">
		/// Expresion regular para evaluar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena NotRegex(String pattern)
		{
			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex(pattern);

			if (regex.IsMatch(this.Value))
			{
				this.AddError("not_regex");
			}

			return this;
		}


		/// <summary>
		/// Comrpueba que el valor no cumpla con la expresión regular dada
		/// </summary>
		/// <param name="regex">
		/// Expresion regular para evaluar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena NotRegex(Regex regex)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (regex.IsMatch(this.Value))
			{
				this.AddError("not_regex");
			}

			return this;
		}


		/// <summary>
		/// Permite que el valor sea nulo a partir del llamado de esta función. 
		/// Nota: Esto desactiva las validaciones siguientes si el valor es nulo o con longitud igual a 0.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Nullable()
		{
			this._Nullable = true;
			return this;
		}


		/// <summary>
		/// Comprueba que el valor sea un numero entero o decimal.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Numeric()
		{
			if (this.IsNull())
			{
				return this;
			}

			try
			{
				Convert.ToDecimal(this.Value);
			}
			catch (Exception)
			{

				this.AddError("numeric");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor cumpla con la expresión regular dada.
		/// </summary>
		/// <param name="pattern">
		/// Expresión regular para evaluar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Regex(String pattern)
		{
			if (this.IsNull())
			{
				return this;
			}

			Regex regex = new Regex(pattern);

			if (!regex.Match(this.Value).Success)
			{
				this.AddError("regex");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor cumpla con la expresión regular dada.
		/// </summary>
		/// <param name="regex">
		/// Expresión regular para evaluar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Regex(Regex regex)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (!regex.IsMatch(this.Value))
			{
				this.AddError("regex");
			}

			return this;
		}


		/// <summary>
		/// Forza a que el campo no sea null y tenga una longitud mayor a 0. 
		/// Nota: Este es el estado por default, pero no mostrára el mensaje de error a menos que se especifique.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Required()
		{
			this._Nullable = false;

			if (this.Value == null || this.Value.Length <= 0)
			{
				this.AddError("required");
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el campo sea igual a otro
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Valor de campo.
		/// </param>
		/// <returns></returns>
		public Cadena Same(String name, String value)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value != value)
			{
				this.AddError("same", name);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor inicie al menos con uno de los elementos dados.
		/// </summary>
		/// <param name="payload">
		/// Elementos validos de inicio.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena StartsWith(String[] payload)
		{
			if (this.IsNull())
			{
				return this;
			}
			bool pass = false;
			foreach (var item in payload)
			{
				if (this.Value.StartsWith(item))
				{
					pass = true;
					break;
				}
			}

			if (!pass)
			{
				this.AddError("starts_with", payload);
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor tenga una cierta cantidad de caracteres.
		/// </summary>
		/// <param name="longitud">
		/// Cantidad de caracteres.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Size(int longitud)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value.Length != longitud)
			{
				this.AddError("size", longitud);
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor sea una url valida.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Cadena Url()
		{

			if (this.IsNull())
			{
				return this;
			}

			if (!Uri.IsWellFormedUriString(this.Value, UriKind.Absolute))
			{
				this.AddError("url");
			}

			return this;
		}
	}


	/// <summary>
	/// Validaciones para fechas
	/// </summary>
	public class Fecha: General
	{

		/// <summary>
		/// Inicializa los parametros de la clase
		/// </summary>
		/// <param name="name">Abreviatura del lenguaje.</param>
		public Fecha(String name)
		{
			this.ChangeLanguage(name);
		}


		/// <summary>
		/// Valor del campo a evaluar.
		/// </summary>
		private DateTime? Value;

		/// <summary>
		/// Inidica sí esta permitido que el valor sea nulo.
		/// </summary>
		private Boolean _Nullable = false;


		/// <summary>
		/// Asigna el nombre y valor del campo a evaluar.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor del campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Fecha Field(String name, DateTime? value)
		{
			this.Name = name;
			this.Value = value;
			this._Nullable = false;
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es nulo y esta permitido.
		/// </summary>
		/// <returns>
		/// true si es valor es nulo y esta permitido false si no es así
		/// </returns>
		private Boolean IsNull()
		{
			if (this._Nullable && this.Value == null)
			{
				return true;
			}
			return false;
		}


		/// <summary>
		/// Comprueba si la valor es una fecha posterior a la fecha proporcionada.
		/// </summary>
		/// <param name="payload">
		/// Fecha para contrastar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Fecha After(DateTime payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value <= payload)
			{
				this.AddError("after", payload.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es una fecha es posterior o igual a la fecha proporcionada.
		/// </summary>
		/// <param name="payload">
		/// Fecha para contrastar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Fecha AfterOrEqual(DateTime payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value < payload)
			{
				this.AddError("after_or_equal", payload.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es una fecha es anterior a la fecha proprocionada.
		/// </summary>
		/// <param name="payload">
		/// Fecha para contrastar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Fecha Before(DateTime payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value >= payload)
			{

				this.AddError("before", payload.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es una fecha es anterior o igual a la fecha proporcionada.
		/// </summary>
		/// <param name="payload">
		/// Fecha para contrastar.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>.
		/// </returns>
		public Fecha BeforeOrEqual(DateTime payload)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value > payload)
			{
				this.AddError("before_or_equal", payload.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es una fecha ques esta entre dos fechas proporcionadas.
		/// </summary>
		/// <param name="min">
		/// Fecha mínima permitida
		/// </param>
		/// <param name="max">
		/// Fecha máxima permitida.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>.
		/// </returns>
		public Fecha Between(DateTime min, DateTime max)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (min > this.Value || this.Value > max)
			{
				this.AddError("between_numeric", min.ToString("yyyy-MM-dd HH:mm:ss"), max.ToString("yyyy-MM-dd HH:mm:ss"));
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor es una fecha igual al un campo de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor del campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>.
		/// </returns>
		public Fecha Confirmed(DateTime valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value != valor)
			{
				this.AddError("confirmed");
			}

			return this;
		}

	

		/// <summary>
		/// Comprueba que el valor sea una fecha difrente a un campo de referencia.
		/// </summary>
		/// <param name="nombre">
		/// Nombre del campo de referencia
		/// </param>
		/// <param name="valor">
		/// Valor del campo de referencia.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>.
		/// </returns>
		public Fecha Different(String nombre, DateTime valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value == valor)
			{
				this.AddError("different", nombre);
			}

			return this;
		}

		/// <summary>
		/// Permite que el valor sea nulo a partir de que es llamada. Nota: Esto causa que si es null sea ingorada por las evaluaciones siguientes.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>.
		/// </returns>
		public Fecha Nullable()
		{
			this._Nullable = true;

			return this;
		}

		/// <summary>
		/// Forza a que el valor sea diferente de null. Nota: Este es el estado por defecto.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>.
		/// </returns>
		public Fecha Required()
		{
			this._Nullable = false;

			if (this.Value == null)
			{
				this.AddError("required");
			}
			return this;
		}

		/// <summary>
		/// Comprueba que el campo sea igual a otro
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Valor de campo.
		/// </param>
		/// <returns></returns>
		public Fecha Same(String name, DateTime value)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Value != value)
			{
				this.AddError("same", name);
			}

			return this;
		}
	}


	/// <summary>
	/// Validaciones para listas
	/// </summary>
	public class Lista : General
	{

		/// <summary>
		/// Inicializa los parametros de la clase
		/// </summary>
		/// <param name="name">Abreviatura del lenguaje.</param>
		public Lista(String name)
		{
			this.ChangeLanguage(name);
		}

		/// <summary>
		/// Valor del campo a evaluar.
		/// </summary>
		private List<Object> Valor;

		/// <summary>
		/// Indica si esta permitido que el valor sea nulo
		/// </summary>
		private Boolean _Nullable = false;


		/// <summary>
		/// Asigna el nombre y valor del campo a evaluar.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Lista de valores <see cref="List{T}"/>. 
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Field(String name, Object value)
		{
			this.Valor = JsonConvert.DeserializeObject<List<Object>>(JsonConvert.SerializeObject(value));
			this.Name = name;
			this._Nullable = false;
			return this;
		}


		/// <summary>
		/// Comprueba si el valor es null y esta permitido.
		/// </summary>
		/// <returns>
		/// true si el valor es null y esta permtido false si no.
		/// </returns>
		private Boolean IsNull()
		{
			if (this._Nullable && (this.Valor == null || this.Valor.Count == 0))
			{
				return true;
			}
			return false;
		}


		/// <summary>
		/// Comprueba que la lista tenga una cantidad de elementos entre un rango dado.
		/// </summary>
		/// <param name="min">
		/// Minima cantidad de elementos
		/// </param>
		/// <param name="max">
		/// Maxima cantidad de elementos.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Between(int min, int max)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Valor == null || (this.Valor.Count < min || max < this.Valor.Count))
			{
				this.AddError("between_list", min, max);
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor sea igual al valor de referencia.
		/// </summary>
		/// <param name="valor">
		/// Valor del referencia
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Confirmed(Object valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (JsonConvert.SerializeObject(this.Valor) != JsonConvert.SerializeObject(valor))
			{
				this.AddError("confirmed");
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor sea diferente a un campo de referencia.
		/// </summary>
		/// <param name="nombre">
		/// Nombre del campo referencia
		/// </param>
		/// <param name="valor">
		/// Valor del referencia
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Different(String nombre, Object valor)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (JsonConvert.SerializeObject(this.Valor) == JsonConvert.SerializeObject(valor))
			{
				this.AddError("different", nombre);
			}

			return this;
		}


		/// <summary>
		/// Comprueba que el valor no supera un máximo de elementos.
		/// </summary>
		/// <param name="max">
		/// Cantidad máxima de elementos.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Max(int max)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Valor == null || this.Valor.Count > max)
			{
				this.AddError("max_list", max);
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el valor no supera un mínimo de elementos.
		/// </summary>
		/// <param name="min">
		/// Cantidad minima de elementos.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Min(int min)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (this.Valor == null || this.Valor.Count < min)
			{
				this.AddError("min_list", min);
			}

			return this;
		}


		/// <summary>
		/// Permite que el valor sea nulo a partir de que se manda a llamar. 
		/// Nota: Esto causa que todas las demás validaciones ignoren el valor si este es null o tiene 0 elementos.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Nullable()
		{
			this._Nullable = true;

			return this;
		}


		/// <summary>
		/// Obliga a que el valor no se null y tenga al menos 1 elemento. 
		/// Nota: Este es el estado por defecto, pero el mensaje no se añadira a menos que la
		/// validación esta presente.
		/// </summary>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Required()
		{
			this._Nullable = false;

			if (this.Valor == null || this.Valor.Count == 0)
			{
				this.AddError("required");
			}
			return this;
		}

		/// <summary>
		/// Comprueba que el valor sea una lista igual al enviada como de referencia.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Valor del campo <see cref="List{T}"/>
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>.
		/// </returns>
		public Lista Same(String name, Object value)
		{
			if (this.IsNull())
			{
				return this;
			}

			if (JsonConvert.SerializeObject(this.Valor) != JsonConvert.SerializeObject(value))
			{
				this.AddError("same", name);
			}

			return this;
		}


	}


	/// <summary>
	/// Validaciones para campos numericos
	/// </summary>
	public class Numero: General
	{

		/// <summary>
		/// Inicializa los parametros de la clase
		/// </summary>
		/// <param name="name">Abreviatura del lenguaje.</param>
		public Numero(String name)
		{
			this.ChangeLanguage(name);
		}


		/// <summary>
		/// Valor del campo.
		/// </summary>
		private Decimal Value;


		/// <summary>
		/// Asigna el nombre y valor del campo.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Valor del campo <see cref="int"/>, <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
		/// </param>
		/// <returns></returns>
		public Numero Field(String name, Object value)
		{
			this.Name = name;
			this.Value = Convert.ToDecimal(value);
			return this;
		}




		/// <summary>
		/// Comprueba si el valor esta dentro de un rango dado.
		/// </summary>
		/// <param name="min">
		/// Valor mínimo permitido
		/// </param>
		/// <param name="max">
		/// Valor máximo permitido.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>.
		/// </returns>
		public Numero Between(Decimal min, Decimal max)
		{


			if (this.Value < min || max < this.Value)
			{
				this.AddError("between_numeric", min, max);
			}

			return this;
		}

		/// <summary>
		/// Comprueba si el valor es igual al campo de referencia.
		/// </summary>
		/// <param name="payload">
		/// Valor de confirmación.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>.
		/// </returns>
		public Numero Confirmed(Decimal payload)
		{
			if (this.Value != payload)
			{
				this.AddError("confirmed");
			}

			return this;
		}

		/// <summary>
		/// Compruba que el valor sea diferente un campo de referencia.
		/// </summary>
		/// <param name="nombre">
		/// Nombre del campo
		/// </param>
		/// <param name="valor">
		/// Valor del campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>.
		/// </returns>
		public Numero Different(String nombre, Decimal valor)
		{

			if (this.Value == valor)
			{
				this.AddError("different", nombre);
			}

			return this;
		}

	

		/// <summary>
		/// Comprueba que el valor sea menor al máximo establecido.
		/// </summary>
		/// <param name="max">
		/// Valor máximo.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>.
		/// </returns>
		public Numero Max(Decimal max)
		{


			if (this.Value > max)
			{
				this.AddError("max_numeric", max.ToString());
			}

			return this;
		}



		/// <summary>
		/// Comprueba que el valor sea mínimo al establecido.
		/// </summary>
		/// <param name="min">
		/// Valor mínimo.
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>.
		/// </returns>
		public Numero Min(Decimal min)
		{


			if (this.Value < min)
			{
				this.AddError("min_numeric", min.ToString());
			}

			return this;
		}

		/// <summary>
		/// Comprueba que el campo sea igual a otro
		/// </summary>
		/// <param name="name">
		/// Nombre del campo
		/// </param>
		/// <param name="value">
		/// Valor de campo.
		/// </param>
		/// <returns></returns>
		public Numero Same(String name, Object value)
		{

			if (this.Value != Convert.ToDecimal(value))
			{
				this.AddError("same", name);
			}

			return this;
		}
	}
}
