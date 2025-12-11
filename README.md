<!-- markdownlint-disable MD033 MD041-->
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>
<!-- markdownlint-enable MD033 -->

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

Este proyecto implementa parte de una biblioteca de medios electrónicos, tales
como libros electrónicos, películas y audiolibros. Los medios electrónicos
pueden ser prestados a usuarios por diferentes períodos de tiempo. La duración
del préstamo depende del tipo de medio electrónico.

Te damos ya implementadas las clases [`Book`](./src/Library/Book.cs) que
representa los libros electrónicos y [`Movie`](./src/Library/Movie.cs) que
representa las películas .

> [!IMPORTANT]
> Lee toda la consigna primero. Luego escribe en una hoja de papel los 
> cambios que entiendes que debes hacer para completar cada parte de la 
> consigna. Por último, implementa los cambios necesarios en el código en 
> el orden que sea más conveniente. Haz un commit despues de implementar cada
> cambio, con el mensaje "Implementa parte X" donde "X" es el número de las
> partes a continuación.
<!--  -->
> [!IMPORTANT]
> Los casos de prueba pasan con el codigo inicial y deben seguir pasando luego
> de cada modificación.

## Parte 1: Revisar `Book` y `Movie`

Aunque las clases `Book` y `Movie` funcionan correctamente, hay algunas mejoras
que puedes hacer:

1. Refleja que tanto libros electrónicos como películas son medios electrónicos.
2. Evita el código duplicado en las dos clases.

## Parte 2: Implementar `Audiobook`

Agrega una nueva clase `Audiobook` para representar los audiolibros. Los
audiolibros tamibén son medios electrónicos; tienen `Title`, `Year` e
`Isbn` al igual que `Book`, pero tienen `Narrator` en lugar de `Author`. El
tiempo de préstamo es de 14 días. El audiolibro más viejo es de 1870.

## Parte 3: Revisar `BooksRepository` y `MoviesRepository` e implementar `AudiobooksRepository`

Aunque las clases [`BooksRepository`](./src/Library/BooksRepository.cs) y
[`MoviesRepository`](./src/Library/MoviesRepository.cs) funcionan correctamente,
hay mejoras que puedes hacer para:

1. Evitar el código duplicado en las dos clases.
2. Agregar fácilmente un repositorio para el nuevo tipo de medio electrónico
   `Audiobook`.

## Parte 4: Revisar `FindById` en los repositorios

Mira el código del método `FindByTitle` en los repositorios. El método funciona
correctamente porque todos los medios electrónicos tienen un título.

Mira ahora el código del método `FindById` en los repositorios de medios
electrónicos. Aunque el método funciona correctamente, el identificador de los
libros y de los audiolibros es `Isbn`, mientras que el de las películas es
`ImdbId`. Haz las modificaciones necesarias para que puedas buscar los medios
por su identificador correcto, sin cambiar la firma del método FindById.

> [!TIP]
> Cada medio tiene la responsabilidad de conocer su propio identificador.

## Parte 5: Revisar `Loan`

Actualmente la clase [`Loan`](./src/Library/Loan.cs) representa préstamos de
libros electrónicos, pues referencia una instancia de `Book`. Haz los cambios
necesarios como para que se pueda prestar cualquier medio electrónico. Eso
incluye también modificar, al menos, el método `void LoanToUser(User, ...,
DateTime)` de la clase `MediaLibrary` para prestar cualquier medio electrónico,
no solo libros.

## Parte 6: Agregar nuevas reglas de préstamos

En el método `void LoanToUser(User, ..., DateTime)` de la clase
`MediaLibrary` hay actualmente tres reglas:

* No se puede prestar más de dos medios electrónicos a un mismo usuario a la
  vez.

* Un medio no puede estar prestado a más de un usuario a la vez.

* Un usuario con préstamos vencidos no puede pedir nuevos préstamos.

Haz las modificaciones necesarias en ese método, para que luego sea fácil
agregar nuevas reglas sin modificarlo.

Luego agrega una nueva regla:

* Un usuario no puede tener dos medios del mimso año. Es una regla arbitraria
  solamente a efectos de este ejercicio.

> [!TIP]
> La clase `MediaLibrary` tiene un método ``

Si has hecho lo anterior bien, no deberías necesitar modificar el método `void
LoanToUser(User, ..., DateTime)` de la clase `MediaLibrary`.
