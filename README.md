# Proyecto WcfStudents con arquitectura DDD e inyección de dependencias con Autocat

## Introducción

Este proyecto consiste en el manejo de datos de una lista de estudiantes con un fichero txt, xml o json.

Las implementaciones usadas en este proyecto:

- Arquitectura DDD
- Inyección con Autofac
- Segregación de interfaces
- Factorías (Factory pattern)
- Adaptación (Adapter pattern)
- WCF
- Configuración de protocolos (Rest y Soap)
- Logger Log4Net y Serilog

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

