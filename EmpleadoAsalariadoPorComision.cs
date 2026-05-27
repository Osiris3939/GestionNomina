using System;

namespace GestionNomina
{
    // Esta clase hereda de EmpleadoPorComision para reutilizar ventas y comisión,
    // pero además le sumamos un sueldo base garantizado y un extra del 10% del sueldo base.
    public class EmpleadoAsalariadoPorComision : EmpleadoPorComision
    {
        public decimal SalarioBase { get; set; }

        public EmpleadoAsalariadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision, decimal salarioBase)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial, ventasBrutas, tarifaComision)
        {
            SalarioBase = salarioBase;
        }

        // Sobrescribimos el cálculo de pago para sumar el sueldo base, 
        // la comisión calculada en la clase padre y el 10% adicional.
        public override decimal CalcularPago()
        {
            decimal pagoDeComisiones = base.CalcularPago(); // Llama a CalcularPago de EmpleadoPorComision
            decimal bonoIncentivo = SalarioBase * 0.10M;
            return pagoDeComisiones + SalarioBase + bonoIncentivo;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Salario Base: {SalarioBase:C}");
            Console.WriteLine($"Bono Incentivo (10%): {(SalarioBase * 0.10M):C}");
        }
    }
}
