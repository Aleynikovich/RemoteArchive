# RemoteArchive

Este programa ha sido diseñado para correr como servicio de windows en segundo plano.

Queda a la espera de recibir flanco de subida sobre la entrada que el usuario declare (Hay que declarar e inicializar la variable <int $inBckpPlc>
en USER GLOBALS en el archivo $config.dat. El valor de esta variable será la entrada que esperará el servicio.

Una vez recibido el flanco de subida sobre la entrada, el robot realiza un backup en la ruta y nombre
D:\PlcBackup\\{FechaHora}{NombreRobot}.zip
