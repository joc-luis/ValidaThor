using System;
using System.Collections.Generic;
using System.Text;

namespace ValidaThor
{
	/// <summary>
	/// Mensajes de error
	/// </summary>
	public class Field
	{
		/// <summary>
		/// Nombre del campo
		/// </summary>
		public String Name { get; set; }


		/// <summary>
		/// Lista de errores
		/// </summary>
		public List<String> Errors { get; set; }

		/// <summary>
		/// Cargador de la clase
		/// </summary>
		public Field()
		{
			this.Errors = new List<String>();
		}
	}
}
