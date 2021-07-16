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
	- WcfStudent.Domain.StudentMain
		- Contracts
			- Repository
				- IStudentRepository
	- WcfStudent.Domain.Entity
		- Student.cs


- Infrastructure Layer
	- WcfStudent.Infrastructure.Repository
		- Implementation
			- StudentRepository.cs
	- WcfStudent.Infrastructure.Util
		- Contracts
			- ISerilace
		- Implementation
			- FileManager
			- Serilace

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

### 3. Entidades del dominio

Importante empezar con las entidades del proyecto, ya que serán la base.

En nuestro proyecto tiene 1 entidad:

Student:
	- StudentId
	- Name
	- Surname
	- Age
	- Birthday
	
### 4.1. Infrastructure: Utils

Se ha creado un proyecto nuevo con metodos por separado ha Repository para seguir el principio de SRP y poder separar cada funcionalidad
en una casa. Se ha creado los proyectos de FileManager y Serilace.

FileManager -> Controla el fichero.
Serilace -> Lee y escribe un fichero.

### 4.2. 
