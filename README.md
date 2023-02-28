# Instrucciones para ejecutar la API

Antes de iniciar la API, es necesario iniciar el contenedor de `Docker`, podemos revisar la configuracion en la carpeta **servidor** en el  archivo `docker-compose.yml` aqui tenemos la configuracion para crear una instancia de **SQL SERVER** corremos el comando `docker-compose up -d` para iniciar el contenedor dentro de la carpeta **servidor**.

	/* dentro del folder servidor */
    docker-compose up -d

Una ves ya inicializado el contenedor, podemos revisar que este corriendo con el comando `docker ps` y veremos algo como esto:

	CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS                    NAMES
	1b0b1b1b1b1b1        mssql-server        "/opt/mssql/bin/sqls…"   2 minutes ago       Up 2 minutes
	

Ahora que ya tenemos el contenedor corriendo, podemos iniciar la API, dentro del mismo folder corremos el comando:

	/* dentro del folder servidor */
		dotnet run

Una vez la api este corriendo correctamente, podemos pobrar la conexion apuntando a la ruta `http://localhost:5022/dbConnection` y veremos algo como esto:

	{
		"status": "success",
		"message": "Connection to database successful"
	}

### Se cuentan con los siguientes endpoins para la API	

|Ruta| Cuerpo de la SOlicitud | Descripcion
|--|--|--|
| `GET /dbConnection`     | N/A | Validar conexion con el contenedor de SQL Server  |
| `GET /api/user/`        | N/A | Obtener Usuarios |
| `GET /api/user/{id}`    | N/A | Obtener Usuario por Id |
| `POST  /api/user/`      | Aplica  | Crear un nuevo usuario |
| `PUT /api/user/{id}`    | Aplica | Modificar un usuario existente  |
| `DELETE /api/user/{id}` |N/A | Eliminar un usuario existente  |


Ejemplo del cuerpo de la solicitud para crear un usuario:

	{
			"name": "Christian",
			"lastName": "Moreno",
			"username": "andresMore",
			"age": 20,
			"phone": 123456789,
			"email": "andres@gmail.com"
	}


# Instrucciones para ejecutar el cliente

Para iniciar el cliente, es necesario tener instalado `Node.js` y `Angular CLI` para poder ejecutar el proyecto, una vez instalado, dentro de la carpeta **cliente** corremos el comando `npm install` para instalar las dependencias del proyecto.

	/* dentro del folder cliente */
		npm install

Una vez instaladas las dependencias, podemos iniciar el proyecto con el comando `ng serve` y apuntar a la ruta `http://localhost:4200/` para ver el proyecto.

	/* dentro del folder cliente */
		ng serve
		
		




## Tecnologías utilizadas
 - Angular
 - .NET Core 6
 - ntity Framework Core
 - SQL Server
 - Docker



## Créditos
Este proyecto fue desarrollado por Christian Moreno como parte de trabajo.