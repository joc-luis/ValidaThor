using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ValidaThor;

namespace Tests
{
    public class Excepciones
    {

        [Test]
        public void FirstError()
        {
            try
            {
                var validathor = new Validathor("./lang/es.json");

                validathor.Cadena("Nombre", "J0hn").Alpha();

                validathor.Fail(true);
            }
            catch(ValidathorException ex)
            {
                Assert.AreEqual("Nombre sólo debe contener letras.", ex.Message);
            }
            
        }

        [Test]
        public void Fields()
        {
            try
            {
                var validathor = new Validathor("./lang/es.json");

                validathor.Cadena("Nombre", "J0hn").Alpha();

                validathor.Fail(true);
            }
            catch (ValidathorException ex)
            {
                Assert.AreEqual(1, ex.Fields.Count);
            }

        }

        [Test]
        public void Errors()
        {
            try
            {
                var validathor = new Validathor("./lang/es.json");

                validathor.Cadena("Nombre", "J0hn").Alpha();

                validathor.Fail(true);
            }
            catch (ValidathorException ex)
            {
                Assert.AreEqual(1, ex.Errors.Count);
            }

        }
    }
}
