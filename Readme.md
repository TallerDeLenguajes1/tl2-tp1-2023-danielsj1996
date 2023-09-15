Punto 2
Respuestas:

¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
Por Agregacion: Cadete-Cadeteria, Cadete-Pedido
Por composicion: Pedido-Cliente

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

La Clase Cadeteria deberia contener los siguientes metodos:

*Nuevo Pedido (Para agregar un nuevo pedido)
*Asignar Pedido Al Cadete(PAra asignar el nuevo pedido a algun cadete de la lista)
*Cambiar el Estado de un Pëdido (de Pendiente a Entregado o devuelto)
*Reasignar Pedido A otro Cadete(Para reasignar algun pedido de la lista de un cadete a otro)
*Crear Informe(Para ir generando una mini base de datos para mostar al cerrar la app)

La Clase Cadete deberia contar con los siguientes metodos:

*JornalACobrar(para saber cuanto es lo recaudado por cada cadete al final de cada dia)
*CambiarEstadoDelpedido(Para que al cambiar el estado del pedido a Entregado, pueda quedar disponible para asignarle un nuevo pedido)
*AgregarPedido(Para que pueda tomar un pedido para entregarlo luego)
*CantidadDePendientes(Para saber cuantos pedidos tiene actualmente el cadete)
*CantidadDeEntregados(Para saber cuantos pedidos tiene entregados el cadete)

Teniendo en cuenta los principios de abstracción y ocultamiento, qué atributos, propiedades y métodos deberían ser públicos y cuáles privados.

De la Clase Cliente: 
Deberian estar como atributos privados los datos personales como el nombre,la direccion y el telefono y leerlos o acceder a ellos a traves de la propiedad "get".

De la Clase Cadeteria:
Los datos del nro de pedido, sus observaciones y el estado deberian estar como atributos privados y accederlos a traves de la propiedad "get". Los metodos para ver los datos de los clientes y para cambiar el estado de cada pedido a entregado deberian ser publicos para poder acceder desde otros espacios para poder utilizarlos.


De la Clase Cadetes:
Tambien sus datos personales deberian ser colocados como privados y acceder a ellos con el metodo para ver los datos del cadete.


¿Cómo diseñaría los constructores de cada una de las clases?

*Constructor de la Clase Pedido: public Pedido(int nro, string observaciones, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente){}
*Constructor de la Clase Cadete: public Cadete(string id, string nombre, string direccion, string telefono){}
*Constructor de la clase Cliente: public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion){}
*Constructor de la Clase Cadeteria: public Cadeteria(string nombre, string telefono)

