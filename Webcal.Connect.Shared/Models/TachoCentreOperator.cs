namespace Connect.Shared.Models
{
    public class TachoCentreOperator : BaseModel
    {
        public ConnectUser OperatorUser { get; set; }

        public ConnectUser TachographCentreUser { get; set; }
    }
}