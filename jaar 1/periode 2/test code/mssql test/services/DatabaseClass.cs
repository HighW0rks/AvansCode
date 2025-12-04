namespace MsSqlTest
{
    class Robot
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public float Battery_Percentage { get; set; }
        public string Status { get; set; }
    }

    class SensorData
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int Robot_Id { get; set; }
        public int Sensor_Id { get; set; }
        public float Value { get; set; }
    }

    class SensorType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Metric { get; set; }
        public string Unit { get; set; }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    class RobotUserJunction
    {
        public int Id { get; set; }
        public int Robot_Id { get; set; }
        public int User_Id { get; set; }
    }
}