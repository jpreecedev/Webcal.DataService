namespace Webcal.Connect.Data
{
    public class Node
    {
        public int Id { get; set; }

        public Company Company { get; set; }

        public bool IsAuthorized { get; set; }

        public string MachineKey { get; set; }
    }
}