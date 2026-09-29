class Warehouse
{
    private List<Ammo> Storrage = new();
    private Random Random = new Random();

    public Warehouse(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ammo ammo = Random.Next(3) switch
            {
                0 => new HE(),
                1 => new AP(),
                2 => new HEAT()
            };
            Storrage.Add(ammo);
        }
    }
    public List<Ammo> RequestAmmo(int amount)
    {
        int count = Math.Min(amount, Storrage.Count);
        if (count == 0) return new List<Ammo>();
        var pack = Storrage.GetRange(0, count);
        Storrage.RemoveRange(0, count);
        return pack;
    }

}