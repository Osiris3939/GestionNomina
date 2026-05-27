// Franklyn Enmanuel Santana Rodriguez
// Matrícula: 2025 2'90
// Práctica de Programación 2 - Sistema de Nómina

using System;

namespace GestionNomina
{
    // Clase principal con el menú de la aplicación.
    class Program
    {
        private static readonly GestionNomina nomina = new GestionNomina();

        static void Main(string[] args)
        {
            // Cambiar codificación para mostrar símbolos de dinero correctamente
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Sistema de Gestión de Nómina ---");
                Console.WriteLine("1. Registrar empleado asalariado");
                Console.WriteLine("2. Registrar empleado por horas");
                Console.WriteLine("3. Registrar empleado por comisión");
                Console.WriteLine("4. Registrar empleado asalariado por comisión");
                Console.WriteLine("5. Actualizar empleado");
                Console.WriteLine("6. Mostrar reporte semanal");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción (1-7): ");

                string opcion = Console.ReadLine()?.Trim();

                switch (opcion)
                {
                    case "1":
                        RegistrarAsalariado();
                        break;
                    case "2":
                        RegistrarPorHoras();
                        break;
                    case "3":
                        RegistrarPorComision();
                        break;
                    case "4":
                        RegistrarAsalariadoPorComision();
                        break;
                    case "5":
                        ActualizarEmpleado();
                        break;
                    case "6":
                        nomina.MostrarReporteSemanal();
                        break;
                    case "7":
                        continuar = false;
                        Console.WriteLine("\nSaliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida.");
                        break;
                }
            }
        }

        // --- REGISTRO DE EMPLEADOS ---

        private static void RegistrarAsalariado()
        {
            Console.WriteLine("\n--- Registrar Empleado Asalariado ---");
            string nss = LeerSeguroSocial();
            string nombre = LeerTextoNoVacio("Nombre: ");
            string apellido = LeerTextoNoVacio("Apellido: ");
            decimal salario = LeerDecimalNoNegativo("Salario semanal: ");

            Empleado emp = new EmpleadoAsalariado(nombre, apellido, nss, salario);
            if (nomina.RegistrarEmpleado(emp))
            {
                Console.WriteLine("\nEmpleado registrado correctamente.");
            }
        }

        private static void RegistrarPorHoras()
        {
            Console.WriteLine("\n--- Registrar Empleado por Horas ---");
            string nss = LeerSeguroSocial();
            string nombre = LeerTextoNoVacio("Nombre: ");
            string apellido = LeerTextoNoVacio("Apellido: ");
            decimal sueldoHora = LeerDecimalNoNegativo("Sueldo por hora: ");
            decimal horas = LeerDecimalNoNegativo("Horas trabajadas: ");

            Empleado emp = new EmpleadoPorHoras(nombre, apellido, nss, sueldoHora, horas);
            if (nomina.RegistrarEmpleado(emp))
            {
                Console.WriteLine("\nEmpleado registrado correctamente.");
            }
        }

        private static void RegistrarPorComision()
        {
            Console.WriteLine("\n--- Registrar Empleado por Comisión ---");
            string nss = LeerSeguroSocial();
            string nombre = LeerTextoNoVacio("Nombre: ");
            string apellido = LeerTextoNoVacio("Apellido: ");
            decimal ventas = LeerDecimalNoNegativo("Ventas totales: ");
            decimal tarifa = LeerDecimalNoNegativo("Tarifa de comisión (ej. 0.10 para 10%): ");

            Empleado emp = new EmpleadoPorComision(nombre, apellido, nss, ventas, tarifa);
            if (nomina.RegistrarEmpleado(emp))
            {
                Console.WriteLine("\nEmpleado registrado correctamente.");
            }
        }

        private static void RegistrarAsalariadoPorComision()
        {
            Console.WriteLine("\n--- Registrar Empleado Asalariado por Comisión ---");
            string nss = LeerSeguroSocial();
            string nombre = LeerTextoNoVacio("Nombre: ");
            string apellido = LeerTextoNoVacio("Apellido: ");
            decimal ventas = LeerDecimalNoNegativo("Ventas totales: ");
            decimal tarifa = LeerDecimalNoNegativo("Tarifa de comisión (ej. 0.10 para 10%): ");
            decimal salarioBase = LeerDecimalNoNegativo("Salario base: ");

            Empleado emp = new EmpleadoAsalariadoPorComision(nombre, apellido, nss, ventas, tarifa, salarioBase);
            if (nomina.RegistrarEmpleado(emp))
            {
                Console.WriteLine("\nEmpleado registrado correctamente.");
            }
        }

        // --- ACTUALIZACIÓN DE DATOS ---

        private static void ActualizarEmpleado()
        {
            Console.WriteLine("\n--- Actualizar Empleado ---");
            Console.Write("Ingrese el número de seguro social: ");
            string nss = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nss))
            {
                Console.WriteLine("[Error] El seguro social no puede estar vacío.");
                return;
            }

            Empleado emp = nomina.BuscarEmpleado(nss);

            if (emp == null)
            {
                Console.WriteLine("\nNo se encontró ningún empleado con ese seguro social.");
                return;
            }

            Console.WriteLine($"\nEmpleado encontrado: {emp.PrimerNombre} {emp.ApellidoPaterno}");
            Console.WriteLine("(Presione Enter para no modificar un campo)\n");

            // Nombre y apellido comunes
            string nuevoNombre = LeerTextoOpcional($"Nuevo nombre ({emp.PrimerNombre}): ");
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) emp.PrimerNombre = nuevoNombre;

            string nuevoApellido = LeerTextoOpcional($"Nuevo apellido ({emp.ApellidoPaterno}): ");
            if (!string.IsNullOrWhiteSpace(nuevoApellido)) emp.ApellidoPaterno = nuevoApellido;

            // Según el tipo específico, actualizamos sus campos particulares
            if (emp is EmpleadoAsalariadoPorComision empAsalCom)
            {
                decimal? ventas = LeerDecimalOpcional($"Nuevas ventas ({empAsalCom.VentasBrutas:C}): ");
                if (ventas.HasValue) empAsalCom.VentasBrutas = ventas.Value;

                decimal? tarifa = LeerDecimalOpcional($"Nueva tarifa de comisión ({empAsalCom.TarifaComision}): ");
                if (tarifa.HasValue) empAsalCom.TarifaComision = tarifa.Value;

                decimal? baseSalario = LeerDecimalOpcional($"Nuevo salario base ({empAsalCom.SalarioBase:C}): ");
                if (baseSalario.HasValue) empAsalCom.SalarioBase = baseSalario.Value;
            }
            else if (emp is EmpleadoPorComision empCom)
            {
                decimal? ventas = LeerDecimalOpcional($"Nuevas ventas ({empCom.VentasBrutas:C}): ");
                if (ventas.HasValue) empCom.VentasBrutas = ventas.Value;

                decimal? tarifa = LeerDecimalOpcional($"Nueva tarifa de comisión ({empCom.TarifaComision}): ");
                if (tarifa.HasValue) empCom.TarifaComision = tarifa.Value;
            }
            else if (emp is EmpleadoAsalariado empAsal)
            {
                decimal? salario = LeerDecimalOpcional($"Nuevo salario semanal ({empAsal.SalarioSemanal:C}): ");
                if (salario.HasValue) empAsal.SalarioSemanal = salario.Value;
            }
            else if (emp is EmpleadoPorHoras empHoras)
            {
                decimal? sueldo = LeerDecimalOpcional($"Nuevo sueldo por hora ({empHoras.SueldoPorHora:C}): ");
                if (sueldo.HasValue) empHoras.SueldoPorHora = sueldo.Value;

                decimal? horas = LeerDecimalOpcional($"Nuevas horas trabajadas ({empHoras.HorasTrabajadas}): ");
                if (horas.HasValue) empHoras.HorasTrabajadas = horas.Value;
            }

            Console.WriteLine("\nDatos actualizados correctamente.");
        }

        // --- MÉTODOS PARA LEER Y VALIDAR ENTRADAS ---

        private static string LeerSeguroSocial()
        {
            while (true)
            {
                Console.Write("Seguro social: ");
                string entrada = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(entrada)) return entrada;
                Console.WriteLine("[Error] El seguro social no puede estar vacío.");
            }
        }

        private static string LeerTextoNoVacio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(entrada)) return entrada;
                Console.WriteLine("[Error] Este campo no puede quedar vacío.");
            }
        }

        private static decimal LeerDecimalNoNegativo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim();
                if (decimal.TryParse(entrada, out decimal valor) && valor >= 0)
                {
                    return valor;
                }
                Console.WriteLine("[Error] Por favor, ingrese un número válido mayor o igual a 0.");
            }
        }

        private static string LeerTextoOpcional(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        private static decimal? LeerDecimalOpcional(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(entrada)) return null;

                if (decimal.TryParse(entrada, out decimal valor) && valor >= 0)
                {
                    return valor;
                }
                Console.WriteLine("[Error] Ingrese un número válido mayor o igual a 0.");
            }
        }
    }
}
