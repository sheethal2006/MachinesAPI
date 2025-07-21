namespace MachinesAPI.Models
{
    public class MachineStatus
    {
        public DateTime? Timestamp { get; set; }  //nullable
        public MachineStatusType Status { get; set; }
    }
}
