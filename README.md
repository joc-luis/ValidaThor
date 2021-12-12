# ValidaThor

ValidaThor es una biblioteca que ofrece distintos tipos de comprobaciones de datos.

## Instalación

Ua el administrador de paquetes [dotnet](https://www.nuget.org/packages/ValidaThor/) para realizar la instalación.

```bash
dotne install validathor
```

## Uso

```c
using ValidaThor;

Validathor validathor = new Validathor("./lang/es.json");

validathor.Cadena("name", "J0n").Required().Alpha().Min(3).Max(10);
validathor.Numero("age", 16).Required().Min(18);

if(validathor.Fails()){
    foreach(var error in validathor.Errors()){
        Console.WriteLine(error);
    }

    foreach(var field in validathor.ErrorsPerField()){
        Console.WriteLine(field.Name);
        foreach(var error in field.Errors){
            Console.WriteLine(error);
        }
    }
}

validathor.Clear();

```

### Api Net Core

```c

//Startup.cs
using ValidaThor;
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IValidathor>(new Validathor("./lang/es.json"));
}

//Controlador
private readonly ILogger<WeatherForecastController> _logger;
private readonly IValidathor _validathor;

public WeatherForecastController(ILogger<WeatherForecastController> logger, IValidathor validathor)
{
	_logger = logger;
	_validathor = validathor;
}

[HttpGet]
public ActionResult Get()
{
	var rand = new Random();
	_validathor.Numero("numero", rand.Next(5, 10)).Min(11).Max(20);
	_validathor.Numero("numero_2", rand.Next(5, 10)).Min(11).Max(20);

	return Ok(_validathor.ErrorsPerField());
}
```

## Validaciones disponibles

### String

#### Accepted

Comprueba que el valor evaluado sea "yes", "on" o "true".

#### ActiveUrl

Comprueba que el valor sea una URL accesible.

#### Alpha

El valor debe estar compuesto unicamente por caracteres alfabéticos.

#### AlphaDash

El valor debe estar compuesto unicamente por caracteres alfabéticos, guion bajo, guion medio y números.

#### AlphaNum

El valor debe estar compuesto unicamente por caracteres alfanuméricos.

#### Boolean

El valor debe ser "true" o "false".

#### Between

La longitud del valor debe estar entre un rango.

#### Confirmed

Comprueba que el valor se igual a otro usado como confirmación.

#### Decilned

El valor debe ser "no", "false" u "off".

#### Different

Comprueba que el valor sea diferente a un valor campo de referencia.

#### Email

El valor debe ser un email.

#### EndsWith

El valor debe terminar con uno de los elementos de la lista.

#### Gt

El valor debe tener una longitud mayor a la de un campo de referencia.

#### Gte

El valor debe tener una longitud mayor o igual a la de un campo de referencia.

#### In

El campo debe estar dentro de una lista de valores permitidos.

#### Integer

El campo debe ser un número entero.

#### Ip

El campo debe ser una ipv4 o ipv6 valida.

#### Ipv4

El campo debe ser una ipv4 valida.

#### Ipv6

El campo debe ser una ipv6 valida.

#### Json

El campo debe ser una JSON valido.

#### Lt

El valor debe tener una longitud menor a la de un campo de referencia.

#### Lte

El valor debe tener una longitud menor o igual a la de un campo de referencia.

#### Max

El valor debe tener una longitud menor o igual a la indicada.

#### Min

El valor debe tener una longitud mayor o igual a la indicada.

#### NotIn

El campo no debe estar dentro de una lista de valores.

#### NotRegex

El campo no debe cumplir con el patrón.

#### NotRegex

El campo no debe cumplir con el patrón.

#### Nullable

Permite que el campo sea nulo.

#### Numeric

Permite que el campo debe ser un número.

#### Regex

El campo debe cumplir con el patrón.

#### Required

El campo no debe ser nulo y debe tener una longitud de al menos 1 carácter.

#### Same

El campo debe coincidir con un valor dado.

#### StartsWith

El campo debe comenzar con un valor de la lista.

#### Size

El campo debe tener una longitud fija.

#### Url

El campo debe ser una url.

### DateTime

#### After

El campo debe ser una fecha mayor a una fecha dada.

#### AfterOrEqual

El campo debe ser una fecha mayor o igual a una fecha dada.

#### After

El campo debe ser una fecha menor a una fecha dada.

#### AfterOrEqual

El campo debe ser una fecha menor o igual a una fecha dada.

#### AfterOrEqual

El campo debe ser una fecha menor o entre un rango.

#### Confirmed

El campo debe ser una fecha igual a un campo de confirmación.

#### Different

El campo debe ser una fecha distinta a un campo de referencia.

#### Nullable

Permite que el campo sea nulo.

#### Required

El campo es obligatorio.

#### Same

El campo debe coincidir con un valor dado.

### List<T>

#### Between

El campo debe tener un cantidad de elementos dentro de un rango dado.

#### Confirmed

El campo debe tener ser igual a una lista de dada.

#### Distinct

El campo debe tener ser diferente a una lista dada.

#### Different

El campo debe tener ser diferente a un campo dado.

#### Max

El campo no debe superar máximo de elementos especificado.

#### Min

El campo no debe ser inferior mínimo de elementos especificado.

#### Nullable

Permite que el campo sea nulo.

#### Required

El campo es obligatorio.

#### Same

El campo debe coincidir con un valor dado.

### Numeric (int, float, double, decimal)

#### Between

El campo debe tener un valor dentro de un rango dado.

#### Confirmed

El campo debe tener ser igual a un número dado.

#### Distinct

El campo debe tener ser diferente a un número dado.

#### Different

El campo debe tener ser diferente a un número dado.

#### Max

El campo no debe superar un valor máximo especificado.

#### Min

El campo no debe ser inferior un valor mínimo especificado.

#### Same

El campo debe coincidir con un valor dado.

## Idiomas disponibles

Los mensajes de validación están disponibles en más de 60 idiomas diferentes. Usé las mismas traducciones de [laravel](https://github.com/Laravel-Lang/lang). Los mensajes fuerón transcritos de manera automática, así que es posible que presente errores.

## Contacto

Cualquier duda, sugerencia, pregunta y/o amenaza de muerte [aquí](mailto:red-oker@protonmail.com)

## Licencia

[MIT](./LICENSE.md)

Icono diseñado por [Darius Dan](https://www.flaticon.es/autores/darius-dan)
