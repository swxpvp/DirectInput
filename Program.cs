using Microsoft.Win32;
using System;

class Program
{
    static void Main()
    {
        RegistryKey hive = Registry.CurrentUser;
        string subkey = @"Software\Microsoft\DirectInput";

        using (RegistryKey key = hive.OpenSubKey(subkey))
        {
            if (key != null)
            {
                string[] subkeys = key.GetSubKeyNames();

                if (subkeys.Length > 0)
                {
                    Console.WriteLine($"Subkeys under {subkey}:");
                    foreach (string subKeyName in subkeys)
                    {
                        Console.WriteLine($"[+] {subKeyName}");
                    }
                }
                else
                {
                    Console.WriteLine($"No subkeys found under {subkey}.");
                }
            }
            else
            {
                Console.WriteLine($"Registry key {subkey} not found.");
            }
        }

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine(); // Wait for user input before closing
    }
}
