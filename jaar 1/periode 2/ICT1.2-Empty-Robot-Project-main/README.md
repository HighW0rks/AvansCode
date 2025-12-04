# ICT1.2 - Empty Robot Project

This repository is a minimal starter project for students building a robot application.

It contains a quick example in `Program.cs` prints a greeting and toggles an LED:

```csharp
Console.WriteLine("Hello Robot!");

Led redLed = new Led(5); // kies wel de juiste pin!
redLed.SetOn();
```

What this project contains

-- Minimal .NET project targeting `net8.0`.

Getting started

1. Prerequisites

- .NET 8 SDK (to match `net8.0` target)
- Visual Studio Code (recommended)
- Install the Avans-StatisticalRobot VS Code extension to connect to the robot

2. Build

From the project root run:

```
dotnet build RobotProject.csproj
```

3. Run

Use the VS Code extension to deploy to the robot

Notes and tips for students

- Make sure you connect to the robot before attempting hardware-specific code. Use the Avans-StatisticalRobot extension for VS Code.
- Start by experimenting with sensors and actuators to learn the hardware APIs.
- When moving from experiments to a real application, design a simple class structure and avoid putting everything into `Program.cs`. A small class diagram helps.
- If you need MQTT communication, add the required NuGet package and the SimpleMQTTclient to the project.
- The `Led` example uses a pin number — choose the correct pin for your robot hardware before turning things on.

More information

- Avans Robot Library: https://github.com/AvansICT/ICT1.2-Avans_Robot_Library

Good luck and have fun building your robot!
