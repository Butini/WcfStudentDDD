# Proyecto WcfStudents con arquitectura DDD e inyección de dependencias con Autocat

## Introducción

Este proyecto consiste en el manejo de datos de una lista de estudiantes con un fichero txt, xml o json.

Las implementaciones usadas en este proyecto:

- Arquitectura DDD
- Inyección con Autofac
- Factorías (Factory pattern)
- Adaptación (Adapter pattern)
- WCF
- Configuración de protocolos (Rest y Soap)
- Logger Log4Net y Serilog
- Princpios SOLID
	- Responsabilidad Única
	- Principio Abierto y Cerrado
	- Substitución de Liskov
	- Segregación de interfaces
	- Inversión de dependencias

## Proceso

### 1. Estructura DDD

Con un proyecto en blanco, primero se van a crear los directorios y proyectos con esta estructura para definir las capas del proyecto:

- Distributed Web Service Layer
	- WcfStudent.Distributed.WebServices
		- Contracts
			- IStusdentWebService.cs
		- StusdentWebService.svc

- Application Layer
	- WcfStudent.Application.Services
		- Contracts
			- IStudentAppService.cs
		- Implementation
			- StudentAppService.cs

- Domain Layer
	- WcfStudent.Domain.Entity
		- Student.cs
	- WcfStudent.Domain.Logger
		- Interfaces
			- ITargetAdapterForLogger
		- Log4Net.cs
		- Serilog.cs

- Infrastructure Layer
	- WcfStudent.Infrastructure.Repository
		- Contracts
			- IStudentRepository.cs
		- Implementation
			- StudentRepository.cs

Al crear la estructura DDD del proyecto, hay que recordar que al cambiar el nombre de nuestro archivo servidor svc / svc.cs, tenemos que
cambiar en el interior del archivo svc el path Service con el nombre nuevo. Para ver la configuración del servidor.svc hay que pulsar
clic derecho/Ver marcador.

Es recomendable cambiar las Propiedades de ejecución del proyecto WcfStudent.Distributed.WebServices para que inicie directamente el servidor: 
Click derecho al proyecto/Propiedades/Web/Página específica/Nombre_Del_Servidor.svc.

También agregaremos con Nugget las siguientes librerias, que nos permitirá realizar inyecciones en nuestro proyecto Wcf:

WcfStudent.Distributed.WebServices -> Autofac / Autofac.Wcf

WcfStudent.Application.Services -> Autofac

### 2. Configuración Web y Protocolos

Primero creamos el servicio:

*(**ADVERTENCIA:** Recordar primero de compilar y comprobar que el servidor WCF se ejecuta correctamente.)*

1. Click derecho a Web.config/Editar configuración de WCF
2. Carpeta de servicios y crear un servicio nuevo
3. Buscamos la Dll de nuestro servidor
4. Buscamos el contrato de nuestro servidor
5. Seleccionamos Http
6. Elegimos la primera opción (Interopabilidad básica)
7. Escribimos la dirección con el nombre de nuestro archivo svc
8. Finalizar
9. Antes de cerrar la ventana, guardar

Vamos a agregar los protocolos Soap y Rest modificando el archivo Web.Config.

En el momento que hemos agregado la configuración anterior, esta ya nos proporciona una configuración Soap (Solo faltaria identificarlo con un nombre).
Para poder añadir el protocolo Rest, solo debemos agregar un nuevo endpoint dentro del path service sin agregar un servidor y añadiendo el binding webHttpBinding.
También es necesario agregar el path endpointBehaivor con el Behaivor de nombre Web para que funcione correctamente.

Compilamos y comprobamos que el servidor sigue funcionando. Más adelante aremos la implementación del servidor con la configuración necesaria para el protocolo Soap
y Rest.

### 3 . Entidades del dominio

Importante empezar con las entidades del proyecto, ya que serán la base.

En nuestro proyecto tiene 2 entidades:

Student:
	- StudentId
	- Name
	- Surname
	- Age
	- Birthday
	
File:
	- Path
	- FileName
	- Extension

### 4.1 Repositorio: Generics

Antes de crear los contratos, sabemos que los archivos tienen permisos de lectura y escritura, además, depende del tipo de archivo al que tenemos que
leer, este se tendrá que serializar de una forma distinta. Podemos separar los métodos en 3 clases genéricas, una de lectura, otra de escritura y otra
para serializar ficheros. Esto nos permite implementar la segregación de interfaces por si en un futuro debemos crear nuevos métodos, por ejemplo,
donde requiera permisos de solo lectura o escritura de un fichero.

### 4.2 Contratos

Implementamos una factoria de ficheros de Students, consiste en 2 interfaces donde uno se encarga de devolver la interfaz que implementa los
métodos. De esta manera, podemos crear más de un tipo de Fichero que necesitemos en la capa de aplicación, además de realizar una inyección de
dependencia con la interfaz factory.