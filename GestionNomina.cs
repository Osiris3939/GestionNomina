using System;
using System.Collections.Generic;

namespace GestionNomina
{
    // Esta clase sirve para guardar y controlar la lista de empleados en memoria.
    public class GestionNomina
    {
        // Lista donde se guardan todos los empleados registrados
        private readonly List<Empleado> listaEmpleados = new List<Empleado>();

        // Registra un nuevo empleado si no está repetido su seguro social
        public bool RegistrarEmpleado(Empleado emp)
        {
            if (emp == null) return false;

            // Buscamos si ya existe el seguro social
            Empleado encontrado = BuscarEmpleado(emp.NumeroSeguroSocial);
            if (encontrado != null)
            {
                Console.WriteLine("\n[Error] Ya hay un empleado registrado con ese número de seguro social.");
                return false;
            }

            listaEmpleados.Add(emp);
            return true;
        }

        // Busco el empleado por seguro social para poder modificar sus datos o mostrarlo
        public Empleado BuscarEmpleado(string nss)
        {
            if (string.IsNullOrWhiteSpace(nss)) return null;

            // Recorremos la lista comparando el seguro social
            foreach (Empleado emp in listaEmpleados)
            {
                if (emp.NumeroSeguroSocial.Equals(nss.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return emp; // Lo encontramos
                }
            }
            return null; // No está registrado
        }

        // Muestra el reporte recorriendo todos los empleados de forma polimórfica
        public void MostrarReporteSemanal()
        {
            if (listaEmpleados.Count == 0)
            {
                Console.WriteLine("\nNo hay empleados registrados todavía.");
                return;
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("           REPORTE DE NOMINA            ");
            Console.WriteLine("========================================");

            decimal totalPagar = 0;

            // Recorro todos los empleados y calculo el pago sin preguntar el tipo directamente
            foreach (Empleado emp in listaEmpleados)
            {
                emp.MostrarInformacion();
                decimal pago = emp.CalcularPago(); // Polimorfismo en acción
                Console.WriteLine($"Pago de la semana: {pago:C}");
                Console.WriteLine("----------------------------------------");

                totalPagar += pago;
            }

            Console.WriteLine($"Total a pagar en la semana: {totalPagar:C}");
            Console.WriteLine("========================================\n");
        }
    }
}
