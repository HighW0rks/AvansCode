using System;
using Avans.StatisticalRobot;

static class MotorDrive
{
    private static int left_motor = 0;
    private static int right_motor = 0;

    public static void DriveMotor(int left, int right)
    {
        const int step = 5;
        const int delayMs = 20;

        while (true)
        {
            if (left_motor < left)
            {
                left_motor = Math.Min(left_motor + step, left);
            }
            else if (left_motor > left)
            {
                left_motor = Math.Max(left_motor - step, left);
            }

            if (right_motor < right)
            {
                right_motor = Math.Min(right_motor + step, right);
            }
            else if (right_motor > right)
            {
                right_motor = Math.Max(right_motor - step, right);
            }

            try
            {
                Robot.Motors((short)left_motor, (short)right_motor);
            }
            catch (System.IO.IOException)
            {
                // Ignore I2C errors and continue ramping
                // Optionally: log something with Console.WriteLine if you want
                Console.WriteLine("I2C communication error while setting motor speeds.");
            }

            Robot.Wait(delayMs);

            if (left_motor == left && right_motor == right)
            {
                break;
            }
        }
    }

    public static void DriveMotor(int percent){
        int movementSpeed = 300 / 100 * percent;
        DriveMotor(movementSpeed, movementSpeed);
    }

    public static void DriveSlow(bool reverse = false){
        if (reverse){
            DriveMotor(-30, -30);
            return;
        }
        DriveMotor(30, 30);
    }

    public static void DriveMedium(bool reverse = false){
        if (reverse){
            DriveMotor(-75, -75);
            return;
        }
        DriveMotor(75, 75);
    }

    public static void DriveFast(bool reverse = false){
        if (reverse){
            DriveMotor(-150, -150);
            return;
        }
        DriveMotor(150, 150);
    }

    public static void StopMotors()
    {
        Robot.Motors(0, 0);
    }
    
}