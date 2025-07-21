using MachinesAPI.Models;

namespace MachinesAPI.Repositories
{
    public class MachineRepository
    {
        private readonly List<Machine> _machines = new();

        public Machine AddMachine(Machine machine)
        {
            _machines.Add(machine);
            return machine;
        }

        public List<Machine> GetAll() => _machines;

        public Machine? GetById(Guid id) =>
            _machines.FirstOrDefault(m => m.Id == id);

        public void AddStatus(Guid machineId, MachineStatus status)
        {
            var machine = GetById(machineId);
            if (machine != null)
            {
                machine.StatusLogs.Add(status);
            }
        }
    }
}
