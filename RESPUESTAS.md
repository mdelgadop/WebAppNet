# Responde aquí las preguntas del enunciado
> Estamos diseñando unos nuevos DEA que nos van a indicar su estado de forma continua, mandando datos de estado de la batería, estado de las palas, uso de electricidad, riesgos (por ejemplo, que la humedad sea demasiado alta)... Y vamos a mantener un registro de la evolución del estado del dispositivo, ¿como enfocarías el caso de uso (sólo backend) para recibir un flujo constante de datos de miles de dispositivos?

---
>Haznos un pequeño resumen de cómo implementarías un sistema de monitorización en este servicio y que alertas desplegarías en el entorno productivo.

Personalmente, montaría un pequeño demonio en cada DEA que, cada X minutos, comprobaría todos los datos y los enviaría via WebService a un servidor en la zona, que tuviera los datos de forma local (por ciudad, por ejemplo). Cada servidor en la zona tendría un demonio que mirara si se han recibido datos de todos los DEA. Si uno de los DEA no ha recibido datos en 2X minutos, se enviaría un warning al siguiente sistema explicado. Si no se reciben datos en 3X minutos, se enviaría un danger.

Por otra parte, un sistema backend centralizado tendría dos partes:
 - La primera, sería un Web Service que recibiera las alertas anteriormente explicadas. Estas alertas serían gestionadas para avisos, y a modo de histórico.
 - La segunda mantendría los datos históricos, haciendo una petición a cada Web Service local por la noche, a una hora a la que los servicios se usen poco para evitar sobrecargas. Esto permitiría limpiar de datos los servicios locales para que sean más ligeros, y facilitaría el backup de datos para hacer estudios estadísticos sobre el funcionamiento de los DEA.