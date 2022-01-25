
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaThor
{
	/// <summary>
	/// Validaciones para diferentes tipos de datos.
	/// </summary>
	public class Validathor: IValidathor
	{

		/// <summary>
		/// Instancia de la clase Cadena <seealso cref="Cadena"/>
		/// </summary>
		private Cadena _Cadena = null;

		/// <summary>
		/// Instancia de la clase Fecha <seealso cref="Fecha"/>
		/// </summary>
		private Fecha _Fecha = null;

		/// <summary>
		/// Instancia de la clase Lista <seealso cref="Lista"/>
		/// </summary>
		private Lista _Lista = null;

		/// <summary>
		/// Instancia de la clase Numero <seealso cref="Numero"/>
		/// </summary>
		private Numero _Numero = null;


		/// <summary>
		/// Incializa los parametros de la clase.
		/// </summary>
		/// <param name="name" >
		/// Abreviatura del lenguaje a utilizar.
		/// </param>		
		public Validathor(String name)
		{
			this._Cadena = new Cadena(name);
			this._Fecha = new Fecha(name);
			this._Lista = new Lista(name);
			this._Numero = new Numero(name);
		}

		/// <summary>
		/// Validaciones para datos de tipo <see cref="String"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>
		/// </returns>
		public Cadena Cadena(String name, String value)
		{
			_Cadena.Field(name, value);
			return _Cadena;
		}


		/// <summary>
		/// Validaciones para datos de tipo <see cref="DateTime"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>
		/// </returns>
		public Fecha Fecha(String name, DateTime? value)
		{
			_Fecha.Field(name, value);
			return _Fecha;
		}


		/// <summary>
		/// Validaciones para datos de tipo <see cref="List{T}"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>
		/// </returns>
		public Lista Lista(String name, Object value)
		{

			_Lista.Field(name, value);
			return _Lista;
		}

		/// <summary>
		/// Validaciones para datos de tipo <see cref="int"/>,  
		/// <see cref="double"/>, <see cref="float"/>, <see cref="decimal"/>.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>
		/// </returns>
		public Numero Numero(String name, Decimal value)
		{
			_Numero.Field(name, value);
			return _Numero;
		}



		/// <summary>
		/// Lista de errores en la validación.
		/// </summary>
		/// <returns>
		/// La lista de errores en la validación.
		/// </returns>
		public List<String> Errors()
		{
			List<String> errores = new List<String>();

			errores.AddRange(_Cadena.Errors());
			errores.AddRange(_Fecha.Errors());
			errores.AddRange(_Lista.Errors());
			errores.AddRange(_Numero.Errors());

			return errores;
		}


		/// <summary>
		/// Lista de errores en la validación.
		/// </summary>
		/// <returns>
		/// La lista de errores en la validación.
		/// </returns>
		public List<Field> ErrorsPerField()
		{
			List<Field> errores = new List<Field>();

			errores.AddRange(_Cadena.ErrorsPerField());
			errores.AddRange(_Fecha.ErrorsPerField());
			errores.AddRange(_Lista.ErrorsPerField());
			errores.AddRange(_Numero.ErrorsPerField());

			return errores;
		}

		/// <summary>
		/// Indicia si la validación fue correcta o falló.
		/// </summary>
		/// <param name="makeException">
		/// Si se especifica true, al encontrar errores en la validación se lanzará una excepción
		/// de tipo <see cref="ValidathorException"/>, el mensaje será el primer error encontrado.
		/// </param>
		/// <returns></returns>
		/// <exception cref="ValidathorException"></exception>
		public Boolean Fail(Boolean makeException = false)
		{
			var errors = this.ErrorsPerField();
			if (errors.Count > 0)
			{
                if (makeException)
                {
					throw new ValidathorException(errors.First().Errors.First(), errors);
                }
				return true;
			}

			return false;
		}


		/// <summary>
		/// Elimina los mensajes de error.
		/// </summary>
		public void Clear()
		{
			_Cadena.Clear();
			_Fecha.Clear();
			_Lista.Clear();
			_Numero.Clear();
		}


		/// <summary>
		/// Carga un diccionario de mensajes de error.
		/// </summary>
		/// <param name="name">
		/// Ruta del diccionario.
		/// </param>
		public void ChangeLanguage(String name)
		{
			_Cadena.ChangeLanguage(name);
			_Fecha.ChangeLanguage(name);
			_Lista.ChangeLanguage(name);
			_Numero.ChangeLanguage(name);
		}

	}


	/// <summary>
	/// Validaciones para diferentes tipos de datos.
	/// </summary>
	public interface IValidathor
	{
		/// <summary>
		/// Validaciones para datos de tipo <see cref="String"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Cadena"/>
		/// </returns>
		Cadena Cadena(String name, String value);


		/// <summary>
		/// Validaciones para datos de tipo <see cref="DateTime"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Fecha"/>
		/// </returns>
		Fecha Fecha(String name, DateTime? value);


		/// <summary>
		/// Validaciones para datos de tipo <see cref="List{T}"/>
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Lista"/>
		/// </returns>
		Lista Lista(String name, Object value);


		/// <summary>
		/// Validaciones para datos de tipo <see cref="int"/>,  
		/// <see cref="double"/>, <see cref="float"/>, <see cref="decimal"/>.
		/// </summary>
		/// <param name="name">
		/// Nombre del campo.
		/// </param>
		/// <param name="value">
		/// Valor de campo
		/// </param>
		/// <returns>
		/// Instancia de <see cref="Numero"/>
		/// </returns>
		Numero Numero(String name, Decimal value);


		/// <summary>
		/// Lista de errores al ejecutar la validación.
		/// </summary>
		/// <returns>
		/// Lista de mensajes de error.
		/// </returns>
		List<String> Errors();


		/// <summary>
		/// Lista de errores por campo al ejecutar la validación.
		/// </summary>
		/// <returns>
		/// Lista de los campos con error y sus respectivos mensajes.
		/// </returns>
		List<Field> ErrorsPerField();



		/// <summary>
		/// Indicia si la validación fue correcta o falló.
		/// </summary>
		/// <param name="makeException">
		/// Si se especifica true, al encontrar errores en la validación se lanzará una excepción
		/// de tipo <see cref="ValidathorException"/>, el mensaje será el primer error encontrado.
		/// </param>
		/// <returns></returns>
		/// <exception cref="ValidathorException"></exception>
		Boolean Fail(Boolean makeException = false);


		/// <summary>
		/// Elimina los mensajes de error.
		/// </summary>
		void Clear();

		/// <summary>
		/// Carga la lista de mensajes de error del lenguaje especificado.
		/// </summary>
		/// <param name="name">
		/// Abreviatura del lenguaje.
		/// </param>
		void ChangeLanguage(String name);
	}
}
