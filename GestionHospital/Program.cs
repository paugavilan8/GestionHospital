using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║   Menú Gestión Hospital       ║");
                Console.WriteLine("╠═══════════════════════════════╣");
                Console.WriteLine("║ 1. Alta médico                ║");
                Console.WriteLine("║ 2. Alta paciente              ║");
                Console.WriteLine("║ 3. Alta administrativo        ║");
                Console.WriteLine("║ 4. Asignar paciente           ║");
                Console.WriteLine("║ 5. Listar médicos             ║");
                Console.WriteLine("║ 6. Listar pacientes de médico ║");
                Console.WriteLine("║ 7. Eliminar paciente          ║");
                Console.WriteLine("║ 8. Eliminar médico            ║");
                Console.WriteLine("║ 9. Eliminar administrativo    ║");
                Console.WriteLine("║10. Ver personas hospital      ║");
                Console.WriteLine("║ 0. Salir                      ║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1: hospital.AgregarMedico(); break;
                    case 2: hospital.AgregarPaciente(); break;
                    case 3: hospital.AgregarAdministrativo(); break;
                    case 4: hospital.AsignarPacienteAMedico(); break;
                    case 5: hospital.ListarMedicos(); break;
                    case 6: hospital.ListarPacientesDeMedico(); break;
                    case 7: hospital.EliminarPaciente(); break;
                    case 8: hospital.EliminarMedico(); break;
                    case 9: hospital.EliminarAdministrativo(); break;
                    case 10: hospital.VerPersonasHospital(); break;
                    case 0: salir = true; break;
                    default: Console.WriteLine("Opción inválida"); break;
                }
            }
        }
    }
}
