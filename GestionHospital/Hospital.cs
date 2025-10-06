using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class Hospital
    {
        private List<Medico> medicos = new List<Medico>();
        private List<Paciente> pacientes = new List<Paciente>();
        private List<Administrativo> administrativos = new List<Administrativo>();
        private int siguienteId = 1;
        public void AgregarMedico()
        {
            var medico = new Medico();
            medico.Id = siguienteId++;
            Console.Write("Nombre del médico: ");
            medico.Nombre = Console.ReadLine();
            Console.Write("Especialidad: ");
            medico.Especialidad = Console.ReadLine();
            medicos.Add(medico);
            Console.WriteLine("Médico agregado con éxito.");
        }
        public void AgregarPaciente()
        {
            var paciente = new Paciente();
            paciente.Id = siguienteId++;
            Console.Write("Nombre del paciente: ");
            paciente.Nombre = Console.ReadLine();
            Console.Write("Enfermedad: ");
            paciente.Enfermedad = Console.ReadLine();
            pacientes.Add(paciente);
            Console.WriteLine("Paciente agregado con éxito.");
        }
        public void AgregarAdministrativo()
        {
            var administrativo = new Administrativo();
            administrativo.Id = siguienteId++;
            Console.Write("Nombre del personal administrativo: ");
            administrativo.Nombre = Console.ReadLine();
            Console.Write("Departamento: ");
            administrativo.Departamento = Console.ReadLine();
            administrativos.Add(administrativo);
            Console.WriteLine("Administrativo agregado con éxito.");
        }
        public void AsignarPacienteAMedico()
        {
            ListarPacientes();
            Console.Write("Id del paciente a asignar: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            ListarMedicos();
            Console.Write("Id del médico: ");
            int idMedico = Convert.ToInt32(Console.ReadLine());

            Paciente paciente = pacientes.Find(p => p.Id == idPaciente);
            Medico medico = medicos.Find(m => m.Id == idMedico);

            if (paciente != null && medico != null)
            {
                medico.Pacientes.Add(paciente);
                paciente.IdMedicoAsignado = medico.Id;
                Console.WriteLine("Paciente asignado correctamente.");
            }
            else
            {
                Console.WriteLine("Paciente o médico no encontrado.");
            }
        }
        public void ListarMedicos()
        {
            Console.WriteLine("Lista de médicos:");
            foreach (var med in medicos)
                Console.WriteLine(med);
        }
        public void ListarPacientesDeMedico()
        {
            ListarMedicos();
            Console.Write("Id del médico: ");
            int idMedico = Convert.ToInt32(Console.ReadLine());

            var medico = medicos.Find(m => m.Id == idMedico);
            if (medico != null)
            {
                Console.WriteLine($"Pacientes del doctor {medico.Nombre}:");
                foreach (var pac in medico.Pacientes)
                {
                    Console.WriteLine($"{pac.Id}: {pac.Nombre} - {pac.Enfermedad}");
                }
            }
            else
            {
                Console.WriteLine("Médico no encontrado.");
            }
        }
        public void EliminarPaciente()
        {
            ListarPacientes();
            Console.Write("Id del paciente a eliminar: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            var paciente = pacientes.Find(p => p.Id == idPaciente);
            if (paciente != null)
            {
                pacientes.Remove(paciente);
                foreach (var m in medicos)
                    m.Pacientes.RemoveAll(p => p.Id == idPaciente);
                Console.WriteLine("Paciente eliminado.");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        public void EliminarMedico()
        {
            ListarMedicos();
            Console.Write("Id del médico a eliminar: ");
            int idMedico = Convert.ToInt32(Console.ReadLine());

            var medico = medicos.Find(m => m.Id == idMedico);
            if (medico != null)
            {
                medicos.Remove(medico);
                foreach (var pac in medico.Pacientes)
                    pac.IdMedicoAsignado = 0;
                Console.WriteLine("Médico eliminado.");
            }
            else
            {
                Console.WriteLine("Médico no encontrado.");
            }
        }
        public void EliminarAdministrativo()
        {
            ListarAdministrativos();
            Console.Write("Id del administrativo a eliminar: ");
            int idAdmin = Convert.ToInt32(Console.ReadLine());

            var admin = administrativos.Find(a => a.Id == idAdmin);
            if (admin != null)
            {
                administrativos.Remove(admin);
                Console.WriteLine("Administrativo eliminado.");
            }
            else
            {
                Console.WriteLine("Administrativo no encontrado.");
            }
        }
        public void ListarPacientes()
        {
            Console.WriteLine("Lista de pacientes:");
            foreach (var pac in pacientes)
                Console.WriteLine(pac);
        }
        public void ListarAdministrativos()
        {
            Console.WriteLine("Lista de administrativos:");
            foreach (var admin in administrativos)
                Console.WriteLine(admin);
        }
        public void VerPersonasHospital()
        {
            ListarMedicos();
            ListarPacientes();
            ListarAdministrativos();
        }
    }
}
