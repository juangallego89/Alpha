# Alpha
• Describa  y  defienda  su  modelo  de  datos  indicando  como  soluciona el  manejo  de  consecutivos solicitado  en  el  enunciado del problema. 

  Se propone la creación de de las siguientes tablas:
  
  •ADM.Persona => Registro de los datps básicos y de contacto de las personas que estarían relacionadas al sistema (Administradores, Gestores documentales, remitentes, destinatarios)
  
  •ADM.Usuario => Registro de usuarios que interactuan directamente con el sistema (Administradores, Gestores documentales)
  
  •ADM.Rol => Registro de roles para validar permisos a las funcionalidades del sistema 
  
  •COR.Correspondencia => Registro de todas las comunicaciones radicadas
  
  •COR.Archivos => Registro de la información y ruta de acceso a los archivos de cada comunicación radicada.
  
  •AUD.Auditoria => Registro de eventos en las tablas del sistema (INSERT, DELETE, UPDATE)
    
  Para dar solución a la generación de consecutivos se plantea la creación de dos secuencias, una para cada tipo de comunicaciones, Internas y Externas. 
  Al registrar una nueva comunicación mediante un procedimiento almacenado se valida el tipo de comunicación, se genera el consecutivo con el respectivo prefijo("CI", "CU")  y se incrementa automáticamente la secuencia respectiva. 

  •COR.CorrespondenciaInterna => Secuencia para generar el número de radicado de comunicaciones internas
  
  •COR.CorrespondenciaExterna => Secuencia para generar el número de radicado de comunicaciones externas
  

• Seleccione  dos  tablas  del  modelo  entidad  relación  modelado  en  el  punto  uno  (al  menos  una  de  ellas  debe  tener claves foráneas) y escriba las sentencias DDL usando T-SQL para crear la base de datos y las 2 tablas se leccionadas con sus constraints. 

  Resultado:
  https://github.com/juangallego89/Alpha/blob/develop/DataBase/TABLE/Table.sql
  https://github.com/juangallego89/Alpha/blob/develop/DataBase/SEEDS/Seeds.sql

• Escriba el código T-SQL de un procedimiento almacenado que permita almacenar una correspondencia que acaba de  llegar  para  radicación.  Hint:  tenga  en  cuenta  que  debe  soportar  los  dos  tipos  de  correspondencia  y  hacer  la asignación del consecutivo. 

  Resultado: 
  https://github.com/juangallego89/Alpha/blob/develop/DataBase/STORED%20PROCEDURES/Stored%20Procedures.sql
  
• Escriba  el  código  T-SQL  para  construir  un  trigger  asociado  a  la  tabla  donde  se  almacena  las  comunicaciones radicadas, que permita registrar todo cambio en las tablas de auditoría definidas en el modelo de datos. 
  
  Resultado: 
  https://github.com/juangallego89/Alpha/blob/develop/DataBase/TRIGGERS/Trigger.sql
  
• Escriba el código T-SQL de una vista que permita consultar todas las radicaciones dado un rango de fechas.

  Resultado: 
  https://github.com/juangallego89/Alpha/blob/develop/DataBase/VIEW/Views.sql
