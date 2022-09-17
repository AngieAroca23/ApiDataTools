# DataTools

#PasoSeguidos 
1.	Se realiza una web api con NET  Core 3.1 para los métodos de registrar y consultar (la aplicación en general solo contiene INSERT UPDATE Y SELECT).
2.	Se creó una aplicación en MVC con Framework 4.8 para el consumo del api realizada. 
3.	Se realizó una base de datos que contiene las tablas y procedimientos almacenados utilizados.
4.	Se creo una biblioteca de clases llamada ApiDataTools.Context que es la que se encarga de hacer los procesos de la base de datos dentro del API. Los proceso anteriores son usados mediante interfaces y contiene una inyección de dependencia (SOLO EL API).
5.	En la aplicación antes mencionada se creó un login y pagina básica, además se activan las opciones de errores para reportar errores y devolver a cierta páginas con el fin de mostrar los mensajes amarillos.
6.	La aplicación tiene más funcionalidades para el manejo de errores base de datos y validaciones de mensajes son mostrados en la SweetAlert.

#ModoEjecucion
1.	Descargar y ejecutar el script cargado en el repositorio (SQL Server)
2.	Descargar, descomprimir, abrir y ejecutar el proyecto ApiDataTools (Modificar la conexión)
3.	Descargar, descomprimir, abrir y ejecutar el proyecto AppDataTools
4.	Después de ejecutado el sitio se inicia sesión con las siguientes credenciales
    USUARIO : UserPrueba22
    PASSWORD: PruebaDT2022
5.	Al ya haberse iniciado sesión debe permitir registrar empresas.
6.	Después de registradas las empresas se deben registrar los representantes con una misma placa para que después se pueda ver reflejada la consulta general. (Se pueden registrar también con diferentes placas y empresas)
7.	Si se ingresa un número de documento de la empresa o representante legal que ya se encuentran registrados se actualizará automáticamente la información de los mismos  
