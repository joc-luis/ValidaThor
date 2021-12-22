using System;
using System.Collections.Generic;
using System.Text;

namespace ValidaThor
{
    /// <summary>
    /// Representa un error ocurrio durante la validación
    /// </summary>
    public class ValidathorException : Exception
    {

        private List<Field> _Fields;

        private List<String> _Errors;

        /// <summary>
        /// Lista de campos con sus respectivos errores de validación.
        /// </summary>
        public List<Field> Fields { get { return _Fields; } }

        /// <summary>
        /// Lista de errores de validación.
        /// </summary>
        public List<String> Errors { get { return _Errors; } }


        /// <summary>
        /// Representa un error ocurrio durante la validación
        /// </summary>
        public ValidathorException() { }

        /// <summary>
        /// Representa un error ocurrio durante la validación
        /// </summary>
        /// <param name="message">
        /// Mensaje que explica el error ocurrido.
        /// </param>
        public ValidathorException(string message)
            : base(message) { }


        /// <summary>
        /// Representa un error ocurrio durante la validación
        /// </summary>
        /// <param name="message">
        /// Mensaje que explica el error ocurrido
        /// </param>
        /// <param name="fields">
        /// Lista de campos y sus respectivos errores.
        /// </param>
        public ValidathorException(string message, List<Field> fields)
           : base(message) {
            this._Fields = fields;
            this._Errors = new List<String>();

            foreach (var field in fields)
            {
                foreach (var error in field.Errors)
                {
                    this._Errors.Add(error);
                }
            }
        
        }


        /// <summary>
        /// Representa un error ocurrio durante la validación
        /// </summary>
        /// <param name="message">
        /// Mensaje que explica el error ocurrido.
        /// </param>
        /// <param name="inner">
        /// Causa de la excepcion.
        /// </param>
        public ValidathorException(string message, Exception inner)
            : base(message, inner) { }
    }
}
