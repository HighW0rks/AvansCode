using Avans.StatisticalRobot;
using SimpleMqtt;
class Program
{
    static LCD16x2 lcd = new LCD16x2(0x3E);
    static Ultrasonic ultrasonic = new Ultrasonic(5);
    static DHT11 humiditySensor = new DHT11(18);
    static int textDistance = 0;
    static SimpleMqttClient? client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("Robot1");

    static async Task Main()
    {
        lcd.Clear();
        lcd.SetText("Ultrasoon Test");
        
        // Initialize MQTT client once
        try
        {
            client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("Robot1");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to initialize MQTT client: {ex.Message}");
        }
        
        // AvoidanceBehavior();
        await GetData();
    }

    private static async void AvoidanceBehavior()
    {
        while (true)
        {
            int distance = ultrasonic.GetUltrasoneDistance();
            if (distance != textDistance)
            {
                textDistance = distance;
                try
                {
                    lcd.SetText(textDistance.ToString() + " cm");
                }
                catch (IOException)
                {
                    // Ignore I2C errors when clearing the LCD
                    Console.WriteLine("I2C communication error while clearing the LCD.");
                }
            }

            if (distance < 20)
            {
                MotorDrive.StopMotors();
                Robot.Wait(500);
                MotorDrive.DriveMotor(200, 200);
                Robot.Wait(500);
            }
            else if (distance < 50 && distance >= 20)
            {
                MotorDrive.StopMotors();
                Robot.Wait(500);
                MotorDrive.DriveMotor(-200, 0);
                Robot.Wait(500);
            }
            else if (distance < 50)
            {
                MotorDrive.DriveSlow(true);
            }
            else if (distance < 100)
            {
                MotorDrive.DriveMedium(true);
            }
            else if (distance >= 100)
            {
                MotorDrive.DriveFast(true);
            }

            Robot.Wait(500);
        }

        // MotorDrive.DriveMotor(100, 100);
        // Robot.Wait(2000);
        // MotorDrive.DriveMotor(0, 0);
        // MotorDrive.DriveMotor(-100, 0);
        // Robot.Wait(2000);
        // MotorDrive.DriveMotor(0, 0);
    }
    
    private static async Task GetData()
    {
        while (true)
        {
            try
            {
                int[] dhtData = humiditySensor.GetTemperatureAndHumidity();
                if(dhtData[0] > 0 && dhtData[2] > 0)
                {
                    Console.WriteLine($"Humidity: {dhtData[0]}%, Temperature: {dhtData[2]}°C");
                    await SendData("robot/sensor/humidity", dhtData[0].ToString());
                    await SendData("robot/sensor/temperature", dhtData[2].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading sensor data: {ex.Message}");
            }
            
            await Task.Delay(2000); // DHT11 requires 2 seconds between reads
        }
    }
    
    private static async Task SendData(string topic, string message)
    {
        if (client == null)
        {
            Console.WriteLine("MQTT client not initialized");
            return;
        }
        
        try
        {
            await client.PublishMessage(new SimpleMqttMessage() 
            { 
                Message = message, 
                Topic = topic 
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error publishing MQTT message: {ex.Message}");
        }
    }
}