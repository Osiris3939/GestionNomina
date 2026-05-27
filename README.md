# Sistema de Gestión de Nómina (Práctica de Programación 2)

**Estudiante:** Franklyn Enmanuel Santana Rodriguez  
**Matrícula:** 2025 2'90  
**Tecnología:** C# .NET 8 (Aplicación de consola)

Este proyecto es una aplicación de consola en C# diseñada bajo los principios de la Programación Orientada a Objetos (POO) y el enfoque KISS (Keep It Simple, Stupid). Gestiona el registro y cálculo de nómina de diferentes tipos de empleados utilizando polimorfismo y herencia.

---

## 🛠️ Estructura y Conceptos del Proyecto

El sistema utiliza las siguientes clases:
*   **`Empleado.cs` (Clase Abstracta):** Define los atributos comunes de todo empleado (Nombre, Apellido, Seguro Social) y obliga a las clases hijas a implementar el método abstracto `CalcularPago()`.
*   **`EmpleadoAsalariado.cs`:** Representa a los empleados con un sueldo semanal fijo.
*   **`EmpleadoPorHoras.cs`:** Calcula el pago por horas trabajadas, aplicando una tarifa extra de 1.5x para las horas que excedan de las 40 semanales.
*   **`EmpleadoPorComision.cs`:** Calcula el pago basado en un porcentaje (comisión) de las ventas brutas realizadas.
*   **`EmpleadoAsalariadoPorComision.cs`:** Hereda de la clase de comisión, sumando un sueldo base garantizado más un incentivo adicional del 10% sobre dicho sueldo base.
*   **`GestionNomina.cs`:** Controla la lista de empleados en memoria (añadir, buscar por seguro social, y generar el reporte semanal).

---

## 🚀 Cómo Ejecutar el Proyecto

1. Asegúrate de tener instalado el **.NET 8 SDK**.
2. Abre una terminal en la carpeta raíz del proyecto.
3. Ejecuta el siguiente comando:
   ```bash
   dotnet run
   ```

---

## 📸 ¿Dónde colocar imágenes/capturas de pantalla?

Si deseas agregar capturas de pantalla de la aplicación funcionando a este archivo de descripción:

1. Crea una carpeta llamada `imagenes` en la raíz del proyecto.
2. Guarda tus imágenes ahí (por ejemplo, `reporte.png` o `menu.png`).
3. Enlázalas en este archivo `README.md` usando la siguiente sintaxis de Markdown:

```markdown
![Menú Principal](imagenes/menu.png)
![Reporte Semanal](imagenes/reporte.png)
```

*(Puedes borrar esta sección una vez que agregues tus imágenes).*
