using SimpleMqtt;

namespace MsSqlTest
{
    public class MqttToDbService
    {
        private SimpleMqttClient? client;
        private readonly MsSqlService _sqlService;
        private bool isRunning = false;

        public MqttToDbService(MsSqlService sqlService)
        {
            _sqlService = sqlService;
        }

        public async Task StartMqttClient()
        {
            try
            {
                client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("client1");
                await client.SubscribeToTopic("temperatuur");

                client.OnMessageReceived += async (s, e) =>
                {
                    Console.WriteLine($"Nieuw bericht op topic {e.Topic}: {e.Message}");
                    if (!string.IsNullOrEmpty(e.Topic) && !string.IsNullOrEmpty(e.Message))
                    {
                        await SaveMessageToDatabase(e.Topic, e.Message);
                    }
                };
                
                isRunning = true;
                Console.WriteLine("MQTT client started and subscribed to 'temperatuur' topic");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting MQTT client: {ex.Message}");
            }
        }

        private async Task SaveMessageToDatabase(string topic, string message)
        {
            try
            {
                // Parse the message to extract sensor data
                // Assuming message format: temperature value or JSON
                if (float.TryParse(message, out float value))
                {
                    // Insert sensor data into database
                    var sql = @"INSERT INTO sensor_data (Timestamp, Robot_Id, Sensor_Id, Value) 
                               VALUES (@Timestamp, @RobotId, @SensorId, @Value)";
                    
                    int sensorId = 1; // Default sensor ID, adjust as needed
                    if (topic == "robot/sensor/temperature")
                    {
                        sensorId = 1; // Temperature sensor ID
                    }
                    else if (topic == "robot/sensor/humidity")
                    {
                        sensorId = 2; // Humidity sensor ID
                    }
                    var parameters = new
                    {
                        Timestamp = DateTime.Now,
                        RobotId = 1, // Default robot ID, adjust as needed
                        SensorId = sensorId, // Use the determined sensor ID
                        Value = value
                    };

                    await _sqlService.ExecuteAsync(sql, parameters);
                    Console.WriteLine($"Saved to database: {value} at {DateTime.Now}");
                }
                else
                {
                    Console.WriteLine($"Could not parse message as float: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to database: {ex.Message}");
            }
        }

        public void StopMqttClient()
        {
            if (client != null)
            {
                client.Dispose();
                isRunning = false;
                Console.WriteLine("MQTT client stopped");
            }
        }

        public bool IsRunning => isRunning;
    }
}