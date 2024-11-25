<div align="center">

# Documentacion de la Prueba Tecnica 📚

Utilizando una version refactorizada de **Agora** para modelar un caso de prueba tecnica.
A esta version la llamé Doselete (*voladizo que a manera de dosel se coloca sobre las estatuas, puertas, etc.*)

![Logo][front-image]

</div>

## Introducción
Desarollé este proyecto, con el intuito de enseñar mis capaciades y familiariedades con la tecnologia .NET, los patrones de programacion y las arquitecturas limpias.
Lo hice basandome en un [software anterior](https://github.com/otomaticoscript/agora) que hice. Es un software flexible y abstrae al usuario de todos los elementos del negocio. Lo hace de tal forma que el usuario de la aplicacion no tiene que preocuparse de la parte "sucia" de crear tablas crear relaciones con los elementos, en fin , modelar el negocio.

## Proyecto

### 📋Requisitos

Es necesario crear una aplicación web api ASP.NET para exponer la información proporcionada por esta api [www.tvmaze.com/api](http://www.tvmaze.com/api)

#### Requisito 1
>Implementar un proceso para almacenar en una base de datos la información proporcionada por el endpoint “Shows main information”.
#### Requisito 2
>Exponer un endpoint para ejecutar el proceso cuando sea necesario y asegurarlo mediante una clave api.
#### Requisito 3
>Exponer un endpoint público para consultar la información almacenada en la base de datos.

### 💬Reflexion sobre los requisitos

>Se entiende que lo que se solicita es una ETL (extracion, transformacion y carga). Dicho problema se solventaria con un CRUD y se podria usar MVC para la arquitectura.
Se ha optado por una vision global y teniendo en mente la flexibilidad y la reutilizacion del proceso para otros endpoint de tvmaze.


### 🧶Organizacion

La aplicacion usa una arquitectura por capas de tal forma que se distiguem 3 espacios.

**Domain** -» donde almacenaremos todos las entidades de la aplicacion.
**Application** -» tendremos los gestores que implementan los caso de uso.
**Infrastructure** -» toda interacion hacia fuera de la aplicacion.

```
📁 Soluction
┣📁 Domain
┃ ┖📰Entity
┣📁 Application
┃ ┖📰Manager
┖📁 Infrastructure
  ┣📰Repository
  ┖📰RestAPI

```
### 💻Tecnologias Utilizadas

La aplicacion usará **.Net8** y **C#** y las libreias de **Swagger** (UI de metodos en *Back-End*) y **Dapper** (para mapeo de base de datos) y como Base de Datos se usará **MySql**.

### 🧮Interfaz

#### UI

No se proporcionará una version *Front-End* , mas alla de la que proporsiona *Swagger* en la ️Configuración «development».

#### RestAPI - endpoint
> GET: [*url*]/tvmaze/show/:id -» proceso de consultar la informacion.  
 PUT: [*url*]/tvmaze/show/:id -» proceso para almacenar la informacion.

Para los endponit se enviará un parametro en la cabecera llamado 'x-api-key' con la clave 'ThisIsSecureApiKey'.


## ⚙️Configuración del Proyecto

En la carpeta ```migracion``` hay un fichero ```dump-yyyy.mm.dd.sql``` para migracion de BD
La aplicacion esta pensada para funcionar en consola ya sea window, wsl o docker

## ⛳Roadmap del proyecto

1. Se refactorizará el codigo de ```Agora``` con la intencion de tener un MVP para back.

2. Se incluira un controlador ProductController con los metodos que cumpla el ```requerimento 1 y 3```.  
  2.1. Proceso de extraccion de 'Show Main Innformation' de la api de TvMaze.  
  2.2. Obtencion de informacion guardada por el proceso de extraccion.  

3. Crear un gestor (ProductManager) que implemente el ```caso de uso``` de extracion y tranformacion y que se comunique con el Servicio de obtencion de informacion (TvMazeService) para obtener el json y los 'Repositorios' (NodeData y ProductData) para guardar la informacion en las tablas de nodo y producto.

4. Implemntar un middleware para que que cumpla el ```requerimento 2``` y las peticiones de ProductController se hagan bajo un clave de API

## 📸 Capturas de Pantalla

![Pantalla 1][screenshot]

---

Desarrollado por [Otavio Ferreira Rosa](https://otomaticoscript.github.io/)

---
> ### Ideas de mejora para futuras version:
> + Agregar campo TipoPlantilla en la tabla de template  con los valores de [Proyecto, Estructura, Lista] para agilizar el filtrado, busquedas y reconstrucciones de elementos.
> + Puesto a agregar el campo de Tipo Plantilla tambien una tabla con estos valores y un Enumerado para controlarlos.  


[front-image]: readme/canopy.png

[screenshot]: readme/screenshot.png