using System.Threading.Channels;

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("=== Physics Toolkit ===\r\n1) Projectile Motion\r\n2) " +
        "Free Fall and Timing Simulation\r\n3) Ohm's Law and Electric Power\r\n4) " +
        "Kinetic and Potential Energy\r\n0) Exit");
        switch (CheckInput())
        {
            case 0:
                break;
            case 1:
                Console.WriteLine("Please enter start speed (km/h):");
                float start_speed = CheckVariable();
                Console.WriteLine("Please enter degree (not radians):");
                float degree = CheckVariable();
                Console.WriteLine(ProjectileMotion(start_speed, degree));
                break;
            case 2:
                Console.WriteLine("Please enter height (m):");
                Console.WriteLine(FreeFall(CheckVariable()));
                break;
            case 3:
                OhmsLawAndElectricpower();
                break;
            case 4:
                Console.WriteLine("Please enter speed (km/h):");
                float speed = CheckVariable();
                Console.WriteLine("Please enter mass (km):");
                float mass = CheckVariable();
                Console.WriteLine("Please enter height (m):");
                float height = CheckVariable();
                Console.WriteLine(KineticAndPotentialEnergy(height, speed, mass));
                break;
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
        while (!float.TryParse(Console.ReadLine(), out input) || input < 0 || input > float.MaxValue)
            Console.WriteLine("Please enter a valid number :");
        return input;
    }
    public const float g = 9.8f;
    public const float pi = MathF.PI;
    static string ProjectileMotion(float start_speed, float degree)
    {
        float vx, vy, t_up, h_max, t_total, throw_range;
        vx = start_speed * MathF.Cos(degree * pi / 180);
        vy = start_speed * MathF.Sin(degree * pi / 180);
        t_up = vy / g;
        t_total = vy * vy / (2 * g);
        throw_range = vx * t_total;
        string output = "";
        return output;
    }

    static string FreeFall(float h)
    {
        float t, v;
        t = MathF.Sqrt(2 * h / g);
        v = g * t;
        string output = "";
        return output;
    }

    static string KineticAndPotentialEnergy(float h, float v, float m)
    {
        float KE, PE, E_total;
        KE = 0.5f * m * v * v;
        PE = m * g * h;
        E_total = KE + KE;
        string output = $"Kinetic energy = {KE.ToString("N2")}J\r\nGravitational potential energy = {PE.ToString("N2")}J\r\nMechanical energy = {E_total.ToString("N2")}J";
        return output;
    }
    /*کاربر وارد میکنه:

جرم m (کیلوگرم)

سرعت v (متر بر ثانیه) — برای انرژی جنبشی

ارتفاع h (متر) — برای انرژی پتانسیل

حساب کنه:

KE = ½ · m · v²

PE = m · g · h

E_total = KE + PE

هر سه رو با واحد ژول (J) چاپ کنه.*/
    static void OhmsLawAndElectricpower()
    {

        Console.WriteLine("1) Voltage (V = I.R)\r\n2) Current (I = V / R)\r\n3) Resistance (R = V / I)\r\n4) Power (P = V.I)");
        OhmsLawAndElectricpower instance = new(CheckInput());
    }

}
class OhmsLawAndElectricpower
{
    enum Electric
    {
        Voltage, Current, Resistance, Power
    }
    public OhmsLawAndElectricpower(byte input)
    {
        switch (input - 1)
        {
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
        Console.WriteLine("Please enter Resistance (Ω):");
        r = Program.CheckVariable();
        string output = (i * r).ToString("N4");
        return output + "V";
    }
    string Current()
    {
        float v, r;
        Console.WriteLine("Please enter voltage : (V)");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance (Ω):");
        r = Program.CheckVariable();
        string output = (v / r).ToString("N4");
        return output + "A";
    }
    string Resistance()
    {
        float v, i;
        Console.WriteLine("Please enter Current (A): ");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance (Ω):");
        i = Program.CheckVariable();
        string output = (v / i).ToString("N4");
        return output + "Ω";
    }
    string Power()
    {
        float v, i;
        Console.WriteLine("Please enter voltage (V): ");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Current (A):");
        i = Program.CheckVariable();
        string output = (v * i).ToString("N4");
        return output + "W";
    }

}


//1) Voltage(V = I R)
//2) Current(I = V / R)
//3) Resistance(R = V / I)
//4) Power(P = V I)