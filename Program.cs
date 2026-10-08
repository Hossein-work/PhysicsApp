class Program
{
    public const float g = 9.8f;
    public const float pi = MathF.PI;

    static void Main(string[] args)
    {
        bool checkToContinue;
        checkToContinue = true;
        while (checkToContinue)
        {
            Console.WriteLine("=== Physics Toolkit ===\r\n1) Projectile Motion\r\n2) " +
            "Free Fall and Timing Simulation\r\n3) Ohm's Law and Electric Power\r\n4) " +
            "Kinetic and Potential Energy\r\n0) Exit");
            byte input = CheckInput();
            switch (input)
            {
                case 0:
                    checkToContinue = false;
                    break;
                case 1:
                    Console.WriteLine("Please enter start velocity (m/s):");
                    float startVelocity = CheckVariable();
                    Console.WriteLine("Please enter degree (not radians):");
                    float degree;
                    degree = CheckVariable();
                    while (degree > 90 || degree < 0)
                    {
                        Console.WriteLine("Please enter between 0 and 90 degrees:");
                        degree = CheckVariable();
                    }

                    Console.WriteLine(ProjectileMotion(startVelocity, degree));
                    break;
                case 2:
                    Console.WriteLine("Please enter height (m):");
                    Console.WriteLine(FreeFall(CheckVariable()));
                    break;
                case 3:
                    OhmsLawAndElectricPower();
                    break;
                case 4:
                    Console.WriteLine("Please enter velocity (m/s):");
                    float velocity = CheckVariable();
                    Console.WriteLine("Please enter mass (kg):");
                    float mass = CheckVariable();
                    Console.WriteLine("Please enter height (m):");
                    float height = CheckVariable();
                    Console.WriteLine(KineticAndPotentialEnergy(height, velocity, mass));
                    break;
            }
            if (input != 0)
            {
                Console.WriteLine("Do you want to continue?(YES/NO)");
                string condition = Console.ReadLine();
                checkToContinue = condition.ToLower() == "yes";
            }

        }
    }
    
    internal static byte CheckInput()
    {
        byte input;
        while (!byte.TryParse(Console.ReadLine(), out input) || input > 4)
            Console.WriteLine("Please enter a valid number :");
        return input;
    }
    internal static float CheckVariable()
    {
        float input;
        while (!float.TryParse(Console.ReadLine(), out input) || input < 0)
            Console.WriteLine("Please enter a valid number :");
        return input;
    }
    static string ProjectileMotion(float startVelocity, float degree)
    {
        float vx, vy, tUp, hMax, tTotal, throwRange;
        if (degree == 90)
        {
            vx = 0;
            vy = startVelocity;
        }else if (degree == 0)
        {
            vx = startVelocity;
            vy = 0;
        }
        else
        {
            vx = startVelocity * MathF.Cos(degree * pi / 180);
            vy = startVelocity * MathF.Sin(degree * pi / 180);
        }

        tUp = vy / g;
        hMax = vy * vy / (2 * g);
        tTotal = 2 * tUp;
        throwRange = vx * tTotal;
        string output = $"Velocity components:Vx = {vx.ToString("N2")}m/s and Vy = {vy.ToString("N2")}m/s\r\n" +
            $"Time up:{tUp.ToString("N2")}s\r\nMaximum height:{hMax.ToString("N2")}m\r\nTotal time:{tTotal.ToString("N2")}s\r\range:{throwRange.ToString("N2")}m";
        return output;
    }
    static string FreeFall(float base_h)
    {
        float base_t, base_v;
        base_t = MathF.Sqrt(2 * base_h / g);
        float t = 0;
        base_v = g * base_t;
        float v = 0;
        float h = base_h;
        string output = "Time(s)         Height(m)       Velocity(m/s)";
        while (t < base_t)
        {
            output += "\n" + t.ToString("N2") + "\t\t" + h.ToString("N2") + "\t\t" + v.ToString("N2");
            t += 0.5f;
            h = base_h - (0.5f * g * t * t);
            v = g * t;
        }

        return output;
    }
    static string KineticAndPotentialEnergy(float h, float v, float m)
    {
        float KE, PE, E_total;
        KE = 0.5f * m * v * v;
        PE = m * g * h;
        E_total = KE + PE;
        string output = $"Kinetic energy = {KE.ToString("N2")}J\r\nGravitational potential energy = {PE.ToString("N2")}J\r\nMechanical energy = {E_total.ToString("N2")}J";
        return output;
    }
    static void OhmsLawAndElectricPower()
    {

        Console.WriteLine("1) Voltage (V = I.R)\r\n2) Current (I = V / R)\r\n3) Resistance (R = V / I)\r\n4) Power (P = V.I)\r\n0)Exit");
        OhmsLawAndElectricPower instance = new(CheckInput());
    }

}
class OhmsLawAndElectricPower
{
    enum Electric
    {
        Voltage, Current, Resistance, Power
    }
    public OhmsLawAndElectricPower(byte input)
    {
        switch (input - 1)
        {
            case -1: 
                break;
            case (byte)Electric.Voltage:
                Console.WriteLine("Voltage is :" + Voltage());
                break;
            case (byte)Electric.Current:
                Console.WriteLine("Current is :" + Current());
                break;
            case (byte)Electric.Resistance:
                Console.WriteLine("Resistance is :" + Resistance());
                break;
            case (byte)Electric.Power:
                Console.WriteLine("Power is :" + Power());
                break;
        }
    }
    string Voltage()
    {
        float i, r;
        Console.WriteLine("Please enter Current (A): ");
        i = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance (Ω): ");
        r = Program.CheckVariable();
        string output = (i * r).ToString("N2");
        return output + "V";
    }
    string Current()
    {
        float v, r;
        Console.WriteLine("Please enter Voltage (V): ");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance (Ω): ");
        r = Program.CheckVariable();
        while (r == 0)
        {
            Console.WriteLine("The value zero is meaningless!! \r\nPlease enter a valid value:");
            r = Program.CheckVariable();
        }
        string output = (v / r).ToString("N2");
        return output + "A";
    }
    string Resistance()
    {
        float v, i;
        Console.WriteLine("Please enter Current (A): ");
        i = Program.CheckVariable();
        while (i == 0)
        {
            Console.WriteLine("The value zero is meaningless!! \r\nPlease enter a valid value:");
            i = Program.CheckVariable();
        }
        Console.WriteLine("Please enter Voltage (V):");
        v = Program.CheckVariable();
        string output = (v / i).ToString("N2");
        return output + "Ω";
    }
    string Power()
    {
        float v, i;
        Console.WriteLine("Please enter Voltage (V): ");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Current (A):");
        i = Program.CheckVariable();
        string output = (v * i).ToString("N2");
        return output + "W";
    }

}