class AmmoFabric
{
    private static List<Ammo> Storrage = new();
    private Random Random = new Random();

    public AmmoFabric(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ammo ammo = Random.Next(3) switch
            {
                0 => new HE(),
                1 => new AP(),
                _ => new HEAT()
            };
            Storrage.Add(ammo);
        }
    }


public static List<Ammo> RequestAmmo(int amount)
    {
        int count = Math.Min(amount, Storrage.Count);
        if (count == 0) return new List<Ammo>();

        var pack = Storrage.GetRange(0, count);
        Storrage.RemoveRange(0, count);
        var summary = pack.GroupBy(a => a.Name).Select(g =>$"{g.Key}:{g.Count()}");
        Console.WriteLine($"Выдано {count} снарядов :{ string.Join(",", summary)}");
        return pack;
    }
}