using System.Device.Gpio;
using Avans.StatisticalRobot;

LCD16x2 lcd = new LCD16x2(0x3E);
Ultrasonic ultrasonic = new Ultrasonic(5);

int textDistance = 0;

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
        catch (System.IO.IOException)
        {
            // Ignore I2C errors when clearing the LCD
            Console.WriteLine("I2C communication error while clearing the LCD.");
        }
    }

    if (distance < 50)
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
    else if (distance < 20)
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

    Robot.Wait(500);
}


// MotorDrive.DriveMotor(100, 100);
// Robot.Wait(2000);
// MotorDrive.DriveMotor(0, 0);
// MotorDrive.DriveMotor(-100, 0);
// Robot.Wait(2000);
// MotorDrive.DriveMotor(0, 0);