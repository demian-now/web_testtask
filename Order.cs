namespace TestTaskWeb
{
    public class Order
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureAddress { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingAddress { get; set; }
        public decimal Weight { get; set; }
        public string DepartureDate { get; set; }

        public override string ToString()
        {
            return $"Order #{Id} </br> From {DepartureCity}, {DepartureAddress}</br> In {ReceivingCity}, {ReceivingAddress}</br>Weight: {Weight} </br> DepartureDate: {DepartureDate}" + "</br></br>";
        }
    }
}
