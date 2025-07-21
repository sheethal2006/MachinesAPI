namespace MachinesAPI.Models
{
    public class Machine
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Location { get; set; }
        public List<MachineStatus> StatusLogs { get; set; } = new();
    }
}
