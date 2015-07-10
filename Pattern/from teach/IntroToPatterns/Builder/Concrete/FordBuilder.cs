namespace Builder.Concrete
{
    /// <summary>
    /// Конкретний будівельник для Ford
    /// </summary>
    public class FordBuilder : IVehicleBuilder
    {
        private readonly Vehicle _vehicle = new Vehicle();
        public void SetModel()
        {
            _vehicle.Model = "Ford";
        }

        public void SetEngine()
        {
            _vehicle.Engine = "4 Stroke";
        }

        public void SetTransmission()
        {
            _vehicle.Transmission = "100 Km/hr";
        }

        public void SetBody()
        {
            _vehicle.Body = "Aluminum";
        }

        public void SetAccessories()
        {
            _vehicle.Accessories.Add("On board PC");
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }
    }
}
