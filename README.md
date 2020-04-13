# ProyectoFormacionBS

Proyecto realizado para lo formación de BeSoftware. Se trata de un sistema simple de gestión de usuarios, en el que he querido practicar sobre C#, una aplicación de escritorio con un CRUD a una base de datos remota MySql, que paralelamente cree y guarde la información con las preferencias de cada usuario, en una archivo XML.

El sistema contempla dos tipos de usuarios, un SuperUsuario y un usuario normal (que además puede ser admin.). El SuperUsuario, puede creer usuarios, normales y admin, y eliminarlos. Con la restricción de que en el sistema ha de haber 3 usuarios como mínimo, y al menos, 1 de ellos tiene que ser admin. El usuario normal, tiene que generar obligatoriamente su archivo de configuración xml, con las preferencias deseadas. Estas preferencias son: Color de fondo, color de letra, ancho pantalla, alto pantalla, especio libre de disco (el cual se calcula automáticamente y se hace sobre el disco "C") y fecha. Este usuario, elige la ruta deseada donde guardar el XML, y también lo puede visualizar. Adicionalmente en la pantalla de usuario normal, existen un botón de play y pause, el cual reproduce y pausa, una canción.

El SuperUsuario, tiene credenciales especiales para acceder al sistema. Usará como user=>admin y como pass=>0. El usuario normal, entrará al sistema con user=>"nombre de usuario" y pass=>"la establecida por el SuperUsuario".

Hay muchas mejoras y características que se pueden añadir al sistema. Este sistema es una primera aproximación para practicar el funcionamiento. Hay algunos patrones de diseño que pueden ser implementados y mejorados los que ya están. También, se debería de organizar en una estructura de carpetas que permita tenerlo todo más ordenado.
