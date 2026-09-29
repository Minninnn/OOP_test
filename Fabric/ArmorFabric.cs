class ArmorFabric
{
    public static Armor GetRandom() => Random.Shared.Next(3) switch
    {
        1 => new Gomogen(),
        2 => new Dinamic(),
        _ => new Composite()
    };
}