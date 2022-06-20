using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidaThor;

namespace Tests
{
    public class Combinaciones
    {
        [Test]
        public void Telefono()
        {
            Validathor validathor = new Validathor("es");
            validathor.Cadena("Telefono", "1234567890").Size(10).Integer();
            Assert.AreEqual(0, validathor.Errors().Count());
        }
    }
}
