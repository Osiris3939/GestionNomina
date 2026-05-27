# Sistema de Gestión de Nómina (Práctica de Programación 2)

**Estudiante:** Franklyn Enmanuel Santana Rodriguez  
**Matrícula:** 2025 2089 
**Tecnología:** C# .NET 8 (Aplicación de consola)

Este proyecto es una aplicación de consola en C# diseñada bajo los principios de la Programación Orientada a Objetos (POO) y el enfoque KISS (Keep It Simple, Stupid). Gestiona el registro y cálculo de nómina de diferentes tipos de empleados utilizando polimorfismo y herencia.

---

##  Estructura y Conceptos del Proyecto

El sistema utiliza las siguientes clases:
*   **`Empleado.cs` (Clase Abstracta):** Define los atributos comunes de todo empleado (Nombre, Apellido, Seguro Social) y obliga a las clases hijas a implementar el método abstracto `CalcularPago()`.
*   **`EmpleadoAsalariado.cs`:** Representa a los empleados con un sueldo semanal fijo.
*   **`EmpleadoPorHoras.cs`:** Calcula el pago por horas trabajadas, aplicando una tarifa extra de 1.5x para las horas que excedan de las 40 semanales.
*   **`EmpleadoPorComision.cs`:** Calcula el pago basado en un porcentaje (comisión) de las ventas brutas realizadas.
*   **`EmpleadoAsalariadoPorComision.cs`:** Hereda de la clase de comisión, sumando un sueldo base garantizado más un incentivo adicional del 10% sobre dicho sueldo base.
*   **`GestionNomina.cs`:** Controla la lista de empleados en memoria (añadir, buscar por seguro social, y generar el reporte semanal).

---

##  Cómo Ejecutar el Proyecto

1. Asegúrate de tener instalado el **.NET 8 SDK**.
2. Abre una terminal en la carpeta raíz del proyecto.
3. Ejecuta el siguiente comando:
   ```bash
   dotnet run
   ```

---


<img width="579" height="196" alt="image" src="https://github.com/user-attachments/assets/738719b0-77c3-4f89-baa0-168450ea7d4c" />

<img width="651" height="418" alt="image" src="https://github.com/user-attachments/assets/ed027827-b39a-45bc-9f0b-9b795d574886" />
<img width="592" height="441" alt="image" src="https://github.com/user-attachments/assets/0c3da0e5-63f5-40fe-8e69-3ae357871901" />
<img width="602" height="425" alt="image" src="https://github.com/user-attachments/assets/4572baa0-1355-4db5-a36a-65ba955b5d8f" />
<img width="700" height="455" alt="image" src="https://github.com/user-attachments/assets/7aba40a9-42e3-4280-9a36-036fbf63a942" />
<img width="819" height="546" alt="image" src="https://github.com/user-attachments/assets/12522bab-48a4-497d-bc65-81b7a07ab069" />
<img width="860" height="785" alt="image" src="https://github.com/user-attachments/assets/f5272c44-e6bc-4664-b89e-bacbc9e0df84" />

```


