# Aplicación: Meli Forecast

Tabla de contenidos:
1. [ Introducción ](#introduction)
1. [ Sistema MeLi Forecast ](#meliforecast)
    1. [ Modelo de datos ](#datamodel)
    1. [ Web App ](#webapp)
    1. [ API ](#api)
    1. [Job de pronóstico](#job)
1. [ Respuestas del examen ](#examanswers)
- - -

<a name="introduction"></a>
# Introducción
MeLi es una galaxia lejana la cual consta de 3 planetas: Ferengi, Betasoide y Vulcano. Y su clima se verá afectado según su posición con respecto del sol. Para poder tener un pronóstico diario, utilizan el sistema 'MeLi Forecast', publicado en http://meliforecast.azurewebsites.net/.

<a name="meliforecast"></a>
# Sistema MeLi Forecast

<a name="datamodel"></a>
## Modelo de datos
El modelo de datos, tanto para las clases del proyecto como el esquema de la base de datos se encuentran https://drive.google.com/file/d/1RSYfeetFlA2hLT86YqUnuOnNmNe_DfbW/view?usp=sharing

<a name="webapp"></a>
## Web App
En la Home del sitio de MeLi Forecast hay una interfaz interactiva para predecir el pronóstico de la galaxia. Partiendo de un estado inicial en el que en el día 0 los planetas están alineados con el sol, sobre el eje X de un sistema de ejes cartesianos imaginario.

Para ver el pronóstico de los días siguientes, se debe incrementar el día en el control numérico de la sección superior. Se puede introducir manualmente un número y luego incrementar o decrementar para forzar el salto; presionando los botones del lado derecho del control o con las flechas arriba y abajo del teclado

Están las leyendas con información sobre la ubicación de los planetas, su alineación con respecto del sol y el clima.

Esta aplicación web obtiene los datos atacando a la API de MeLi_Forecast

<a name="api"></a>
## API
La Url de la API es http://meliforecast.azurewebsites.net/api, con un método para obtener el clima: /forecast?day={dayBaseZero}. Es una API REST, por lo que se puede hacer una consulta directamente desde el navegador, poniendo una Url como por ejemplo http://meliforecast.azurewebsites.net/api/forecast?day=20

<a name="job"></a>
## Job
El proyecto MeLi_Forecast.Job al ejecutarlo genera una base de datos SQLite guardando los pronósticos de los próximos 10 años partiendo desde el día 0, considerando que cada año tiene 365 días.

Esta base de datos luego es desplegada en la nube para que la API la consuma y devuelva los resultados. La misma se encuentra en este repositorio, dentro de la carpeta de \MeLi_Forecast.App con el nombre de 'MeLi_Forecast.db'

<a name="examanswers"></a>
# Respuestas del examen
Al ejecutar el Job para la creación de la base de datos partiendo del día 0 con un estado inicial de todos los planetas alineados con el sol en el ángulo 0, y un pronóstico para 10 años de 365 días cada uno, se tiene que habrá:
- 51 períodos de sequías
- 112 períodos de condiciones óptimas de presión y temperatura
- 1106 períodos de lluvia (teniendo en cuenta que un período de lluvia comienza en el primer día de lluvia y termina en el último día de lluvia)
- El día 2448 es el día que se alcanza un pico máximo de lluvia
