using SimpleMqtt;

var client = SimpleMqttClient.CreateSimpleMqttClientForHiveMQ("client1");
await client.SubscribeToTopic("hello");

client.OnMessageReceived += (s, e) =>
{
    Console.WriteLine($"Nieuw bericht op topic {e.Topic}: {e.Message}");
};

await client.PublishMessage(new SimpleMqttMessage(){Message = "Hallo HiveMQ!", Topic = "hello"});

Console.ReadLine();
