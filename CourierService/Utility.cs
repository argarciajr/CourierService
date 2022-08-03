using System;
namespace CourierService
{
    public static class Utility
    {
        public static void ReadMe()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*** User Guide ***", Console.ForegroundColor);
            Console.WriteLine("*", Console.ForegroundColor);
            Console.WriteLine("* Base Delivery Cost: Required. Accepts only numbers or decimal values more than zero i.e 10 or 100.75", Console.ForegroundColor);
            Console.WriteLine("* Number of Package : Required. Accepts only numbers 1 to 5. Configurable in appsettings.", Console.ForegroundColor);
            Console.WriteLine("* PackageID         : Required. Accepts text, numbers or combination i.e pckid1", Console.ForegroundColor);
            Console.WriteLine("* Weight            : Required. Accepts only numbers or decimal values. Minimum weight accepted is 1 (kg)", Console.ForegroundColor);
            Console.WriteLine("* Distance          : Required. Accepts only numbers or decimal values. Minimum distance accepted is 1 (km)", Console.ForegroundColor);
            Console.WriteLine("* OfferCode         : Optional. Accepts text, numbers or combination i.e OFR001", Console.ForegroundColor);
            Console.WriteLine("*", Console.ForegroundColor);
            Console.WriteLine("*******************", Console.ForegroundColor);
            Console.ResetColor();

        }

        public static void ClearInput(int cursorLeft, int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
    }
}
