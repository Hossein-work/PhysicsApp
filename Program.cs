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
                Console.WriteLine("Please enter start speed :");
                float start_speed = CheckVariable();
                Console.WriteLine("Please enter degree :");
                float degree = CheckVariable();
                ProjectileMotion(start_speed, degree);
                break;
            case 2:
                Console.WriteLine("Please enter height :");                
                FreeFall(CheckVariable());
                break;
            case 3:
                OhmsLawAndElectricpower();
                break;
            case 4:
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
        float input ;
        while (!float.TryParse(Console.ReadLine(), out input) || input < 0 || input > float.MaxValue)
            Console.WriteLine("Please enter a valid number :");
        return input;
    }
    public const float g = 9.8f;
    public const float pi = MathF.PI;
    static void ProjectileMotion(float start_speed, float degree)
    {
        float vx, vy, t_up, h_max, t_total, throw_range;
        vx = start_speed * MathF.Cos(degree * pi / 180);
        vy = start_speed * MathF.Sin(degree * pi / 180);
        t_up = vy / g;
        t_total = vy * vy / (2 * g);
        throw_range = vx * t_total;
    }

    static void FreeFall(float h)
    {
        float t, v;
        t = MathF.Sqrt(2 * h / g);
        v = g * t;
    }


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
                break;
            case (byte)Electric.Resistance:
                break;
            case (byte)Electric.Power:
                break;
        }
    }
     string Voltage()
    {
        float i, r;
        Console.WriteLine("Please enter Current : ");
        i = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance :");
        r = Program.CheckVariable();
        string output = (i * r).ToString("N4"); 
        return output;
    }
     string Current()
    {
        float v, r;
        Console.WriteLine("Please enter voltage : ");
        v = Program.CheckVariable();
        Console.WriteLine("Please enter Resistance :");
        r = Program.CheckVariable();
        string output = float.Round(v / r,2).ToString("##,##"); 
        return output;
    }

}


//1) Voltage(V = I R)
//2) Current(I = V / R)
//3) Resistance(R = V / I)
//4) Power(P = V I)