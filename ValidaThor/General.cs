using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ValidaThor
{
	/// <summary>
	/// Funciones y propiedades compartidas por los diferentes tipos.
	/// </summary>
	public class General
	{

		private Translate Translate = new Translate();

		private Lang Lang = new Lang();
		/// <summary>
		/// Lista de errores por campo.
		/// </summary>
		private List<Field> Fields = new List<Field>();

		/// <summary>
		/// Nombre del campo a validar.
		/// </summary>
		protected String Name = "";
		

		/// <summary>
		/// Cambia el lenguaje de los mensajes de error
		/// </summary>
		/// <param name="name">
		/// Abreviatura del lenguaje
		/// </param>
		public void ChangeLanguage(String name)
		{
			this.Lang = this.Translate.Lang(name);
		}


		/// <summary>
		/// Añade un nuevo message de error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		protected void AddError(String validation)
		{
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					var temp = message[1].Replace(":attribute", this.Name);
					temp = temp[0].ToString().ToUpper() + temp.Substring(1);
					this.AddField(temp);
					break;
				}
			}
			
		}


		/// <summary>
		/// Añade un nuevo error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		/// <param name="payload">
		/// Valor mínimo, valor máximo, longitud, campo secundario, fecha, valores.
		/// </param>
		protected void AddError(String validation, String payload)
		{
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					var temp = message[1].Replace(":attribute", this.Name)
						.Replace(":min", payload)
						.Replace(":max", payload)
						.Replace(":digits", payload)
						.Replace(":other", payload)
						.Replace(":date", payload)
						.Replace(":values", payload);
					temp = temp[0].ToString().ToUpper() + temp.Substring(1);
					this.AddField(temp);
					break;
				}
			}
		}

		/// <summary>
		/// Añade un nuevo error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		/// <param name="payload">
		/// Valor mínimo, valor máximo, longitud, campo secundario, fecha, valores.
		/// </param>
		protected void AddError(String validation, int payload)
		{
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					var temp = message[1].Replace(":attribute", this.Name)
						.Replace(":min", payload.ToString())
						.Replace(":max", payload.ToString())
						.Replace(":digits", payload.ToString())
						.Replace(":size", payload.ToString())
						.Replace(":value", payload.ToString())
						.Replace(":other", payload.ToString());
					temp = temp[0].ToString().ToUpper() + temp[1..];
					this.AddField(temp);
					break;
				}
			}
		}


		/// <summary>
		/// Añade un nuevo error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		/// <param name="min">
		/// Límite mínimo.
		/// </param>
		/// <param name="max">
		/// Límite máximo.
		/// </param>
		protected void AddError(String validation, Decimal min, Decimal max)
		{
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					var temp = message[1].Replace(":attribute", this.Name)
						.Replace(":min", min.ToString())
						.Replace(":max", max.ToString());
					temp = temp[0].ToString().ToUpper() + temp.Substring(1);
					this.AddField(temp);
					break;
				}
			}
		}


		/// <summary>
		/// Añade un nuevo error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		/// <param name="min">
		/// Límite mínimo.
		/// </param>
		/// <param name="max">
		/// Límite máximo.
		/// </param>
		protected void AddError(String validation, String min, String max)
		{
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					var temp = message[1].Replace(":attribute", this.Name)
						.Replace(":min", min)
						.Replace(":max", max);
					temp = temp[0].ToString().ToUpper() + temp.Substring(1);
					this.AddField(temp);
					break;
				}
			}
		}


		/// <summary>
		/// Añade un nuevo error.
		/// </summary>
		/// <param name="validation">
		/// Nombre de la validación
		/// </param>
		/// <param name="payload">
		/// Dato extra.
		/// </param>
		protected void AddError(String validation, String[] payload)
		{
			String values = "";
			foreach (var message in this.Lang.Errors)
			{
				if (message[0] == validation)
				{
					foreach (var value in payload)
					{
						values += value + ", "; 
					}
					values = values.Substring(0, values.Length - 2);
					var temp = message[1].Replace(":attribute", this.Name)
						.Replace(",", ".")
						.Replace(":values", values);
					temp = temp[0].ToString().ToUpper() + temp.Substring(1);
					this.AddField(temp);
					break;
				}
			}
		}

		/// <summary>
		/// Añade un nuevo message de error a la lista de campos.
		/// </summary>
		/// <param name="error">
		/// Mensaje de error.
		/// </param>
		private void AddField(String error)
		{
			if (this.Fields.Count(f => f.Name == this.Name) > 0)
			{
				this.Fields.First(f => f.Name == this.Name).Errors.Add(error);
			}
			else
			{
				var field = new Field();
				field.Name = this.Name;
				field.Errors.Add(error);
				this.Fields.Add(field);
			}
		}



		/// <summary>
		/// Lista de errores al ejecutar la validación.
		/// </summary>
		/// <returns>
		/// Lista de messages de error.
		/// </returns>
		public List<String> Errors()
		{
			List<String> errors = new List<string>();
			
			foreach (var field in Fields)
			{
				errors.AddRange(field.Errors);
			}

			return errors;
		}


		/// <summary>
		/// Lista de errores por campo al ejecutar la validación.
		/// </summary>
		/// <returns>
		/// Lista de los campos con error y sus respectivos messages.
		/// </returns>
		public List<Field> ErrorsPerField()
		{
			return this.Fields;
		}

		/// <summary>
		/// Indicia si la validación fue correcta o falló.
		/// </summary>
		/// <returns>
		/// true si no hubo errores, false si hay campos invalidos.
		/// </returns>
		public Boolean Fail()
		{
			if (this.Errors().Count > 0)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Elimina los messages de error.
		/// </summary>
		public void Clear()
		{
			this.Fields.Clear();
		}
	}
}
