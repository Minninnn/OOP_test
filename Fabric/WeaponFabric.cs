class WeaponFabric
{
    public static  List<Weapon> GetRandom(Tank tank)
    {
        List<Weapon> weapons = new List<Weapon>();

        for (int i = 0; i < tank.GetMaxWeapon(); i++)
        {
            weapons.Add(Random.Shared.Next(3) switch
            {
                1 => new Automatic(),
                2 => new Rifled(),
                _ => new Smooth()
            });
        }
        return weapons;
    }
}