Autor: Juan Sebastián Villanueva Muriel

¿Qué ventaja ofrece usar una interfaz en lugar de una clase concreta?
Respuesta:
La principal ventaja es la flexibilidad.
Una interfaz define qué debe hacer una clase, pero no cómo. Esto permite que diferentes clases implementen la misma interfaz con comportamientos distintos, manteniendo un mismo "contrato". Así, puedes intercambiar clases sin afectar el resto del sistema.

Además, las interfaces:

- Facilitan la reutilización de código.

- Separan la lógica de la estructura.

- Mejoran el mantenimiento y la organización del código.

¿Por qué separamos la lógica de selección de entrega del objeto Pedido?
Respuesta:
Por modularidad y responsabilidad única.
Cada clase cumple una función específica. El objeto Pedido solo gestiona datos del pedido, y la lógica de entrega se maneja por separado. Esto:

- Hace el código más limpio.

- Facilita los cambios en entregas sin tocar la lógica del pedido.

- Mejora escalabilidad y mantenimiento.

¿Qué principio SOLID se aplica más en este ejercicio?
Respuesta:
El Principio de Responsabilidad Única (SRP).
Cada clase tiene una única responsabilidad. Por ejemplo:

- Pedido se encarga del pedido.

- MetodoEntrega o sus derivadas se encargan de cómo se entrega.

- Esto permite modificar o escalar el sistema sin generar errores o dependencias innecesarias.


¿Cómo favorece esto el mantenimiento del sistema?
Respuesta:
Los patrones y principios aplicados hacen que el sistema sea:

- Modular: Cada parte se puede cambiar sin afectar las demás.

- Reutilizable: Componentes pueden ser usados en otros proyectos.

- Escalable: Fácil de agregar nuevas funcionalidades como más métodos de entrega.

- Comprensible: El código se entiende mejor por estar bien estructurado.

¿En qué casos reales usarías el patrón Singleton?
Respuesta:
Cuando se necesita una única instancia global en todo el sistema.
Ejemplos:

- Gestor de conexión a la base de datos.

- Administrador de configuración global.

- Registro de logs.

- Esto evita múltiples instancias innecesarias y mantiene el control centralizado.


 Funcionalidad de la App
 Permite registrar pedidos con destino, peso, distancia y método de entrega.

 Métodos de entrega:

- Bicicleta

- Motocicleta

- Camión

-Dron

- Los pedidos se filtran por tipo de entrega en un ComboBox.

 -El costo de entrega se calcula automáticamente según:

- Método elegido

- Distancia

- Peso

![image](https://github.com/user-attachments/assets/db210a1f-6815-4418-8759-82d89ecca26e)
![image](https://github.com/user-attachments/assets/5aa2ab45-a36d-4cf4-ac79-26e49d273ac0)
![image](https://github.com/user-attachments/assets/971a21e3-3680-4b35-90a1-7139a67e6118)



