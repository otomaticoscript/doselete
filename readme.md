<div align="center">

# Documentacion de la Prueba Tecnica 📚

Utilizando una version refactorizada de **Agora** para modelar un caso de prueba tecnica.
A esta version la llamé Doselete (*voladizo que a manera de dosel se coloca sobre las estatuas, puertas, etc.*)

![Logo][font-image]

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

[front-image]:canopy.jpg

[screenshot]: data:image/png;base64,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ak9RCgAAAADUnqIUAAAAAKg9RSkAAAAAUHuKUgAAAACg9hSlAAAAAEDtKUoBAAAAgNobtih9++23AwAAAADAVDdsURpEREREREREREREahBFqYiIiIiIiIiIiNQ+ilIRERERERERERGpfRSlIiIiIiIiIiIiUvsoSkVEREREREREZNzyxz/+se3999+HUSv+lsYjilIRERERERERERmXxELrn//wu/D/7H0sfGrnd8In/vEuGLX4G4q/pfibGo+yVFEqIiIiIiIiIiJjnlhkvfKvv1OQMubibyr+tsa6LFWUioiIiIiIiIjImCYWWO+99174f/b+pFls/dX+n4WT776VrRUZXeJvKP6W4m8q/rbib2wsy1JFqYiIiIiIiIiIjGlieXXmzJn2bFIlqYxV4m8pn1Uaf2OKUhERERERERERmbCJ5dXbb7/dLLQikbFM/ruKvzFFqYiIiIiIiIiITNjE8ur06dOKUhmX5L+r+BtTlIqIiIiIiIiIyITN+++/ryiVcUuxKI2/tbGKolRERERERERERMY0ilIZzyhKRURERERERERkUkRROnWz99TRcOMrPwgzd61u+k+vPBJ++9bxbO35iaJUREREREREREQmRRSlUzOvnh4MM361qv295q7Z+Z1w5J03s1Hjn/y4ilIREREREREREZnQUZROzXxr/9PN7/M///an4bXTg83i9PZ/eaK57NsHns1GjX/y35WiVEREREREREREJnQUpVMz8379YPP7fOPMULYkNGeSxmVffOn72ZLxT/67UpSKiIiIiIiIiMiEjqJ0aub/+NXdXd/nHxvishm/+nZrwXlI/rtSlIqIiIiIiIiIyITOhStKXwh/mR3zEy9sCYeypSPL6+HhFx4ID/8++/P3W8L8c9pf72z7Tetc//LVbMEkzfn+nvPjKUpFRERERERERGRC54IVpa/+qH3MT/xjoezsO7EkrWw7jkXpVMn5/p7z4ylKRURERERERERkQufCFKWdkvMvf/NA87jz976erWvl0N7q8nybH4Vt7X93NMcVi9JCEVvdd7mkraxv7+NH4S+zY8T15RmlhdmwRYWCNh/fEs95/PO1PT8uHLM/dx14Jtt6fJIfR1EqIiIiIiIiIiITOhekKC0Wmj1mgZ5TUdqlMOu0UpK2/eaF1vqufbS2HUlRWi5Jy+vGM13H7MPV/3h3tvX4JD+OolRERERERERERCZ0LkRRWi5BO7NLi7ffD1+UFv9O3HpfWFYuODsFa+dZo3npmW2T2EdMeT+FFIrVUolaKEbzz9K17RgnHmM0xjP5MRSlIiIiIiIiIiIyoXP+i9LugrO7FD3HorRXSZlYH9PPmGRRWihJ2+dZWFZV/HzjkdQx+zGeyY+hKBURERERERERkQmd816UDlMkFp/l2V2U5jM/z6EoTcz2jBldUVq4/T6/bT9muM9XHDcOSR6zD+OZ/BiKUhERERERERERmdA530Vp8vmdBXkRmZeX7XKx/WzRcylK821ShWe2n76K0s5+quN6lbHnI63rM3LjmfwYilIREREREREREZnQOb9FaaWULKR3MVpVLUozcbuzFqWN9Psyp+GK0p6zRlvnli6Duz/zWKf7mP0Zz+THUJSKiIiIiIiIiMiEznktSvOSMjXbsl0+dm6/LxaO8/e+kBWjnfWl0rPfojSmUpaWnh06BkVpTLUsLR1/nFI83kiMZ/JjKEpFRERERERERGRC5/zOKJXxTP4djtR4Jj+GolRERERERERERCZ0FKVTJ/Nf+q/t77FfX9q9Ltt6fJIfR1EqIiIiIiIiIiITOorSqZOh994OD7++PSzoozCNY+LYU++9k209PsmPpygVEREREREREZEJHUWpjGcUpSIiIiIiIiIiMimiKJXxjKJUREREREREREQmRRSlMp5RlIqIiIiIiIiIyKSIolTGM4pSERERERERERGZFPnjH//YLLE+tfM7zULr5LtvZWtEzi3xtxR/U/G3FX9j8bc2VlGUioiIiIiIiIjImCaWV2+//Xa4bc9PmqXWX+3/mbJUzjnxNxR/S/E3FX9b8TemKBURERERERERkQmbWF6dOXMm/NPvD7RnlcJYib+p+NuKvzFFqYiIiIiIiIiITNjE8uq9994Lb731Vnjh2P5w255HFaacs/gbir+l+JuKv634G1OUioiIiIiIiIjIhE4ssN59991moRXLp8HBwfDGG2/AqMXfUPwtxd9U/G2NZUkaoygVEREREREREZFxST6zNN4iHZ8nGV++A6MVf0PxtzTWM0nzKEpFRERERERERGTcEgut3Pvvvw+jVvwtjUcUpSIiIiIiIiIiIlL7KEpFRERERERERESk9hm2KD1w4EAAAAAAAJiqDh06FI4cOTJ8URrfJAUAAAAAMFWd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