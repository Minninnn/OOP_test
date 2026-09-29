class Warehouse
{
    private static List<Ammo> Storrage = new();

    public Warehouse(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ammo ammo = Random.Shared.Next(3) switch
            {
                0 => new HE(),
                1 => new AP(),
                _ => new HEAT()
            };
            Storrage.Add(ammo);
        }
    }

    public static void EqupedTank(Tank tank)
    {
        int guns = Random.Shared.Next(1, tank.GetMaxWeapon() + 1);
        for (int i = 0; i < guns; i++)
        {
            var w = GetRandomWeapon();
            if (tank.CanFit(w.Weight))
            {
                Console.WriteLine($"{tank.TankName} экипирует {w.Name} орудие");
                tank.Weapons.Add(w);
            }
            else
            {
                Console.WriteLine($"{tank.TankName} перегружен");
                break;
            }
        }

        int armor = Random.Shared.Next(1, tank.GetMaxArmor() + 1);

        for (int i = 0; i < armor; i++)
        {
            var w = GetRandomArmor();
            if (tank.CanFit(w.Weight))
            {
                Console.WriteLine($"{tank.TankName} экипирует {w.Name} броню");
                tank.CurrentArmor = w;
            }
            else
            {
                Console.WriteLine($"{tank.TankName} перегружен");
                break;
            }
        }
    }

    public static void EqupedAmmo(Tank tank)
    {
        int ammo = Random.Shared.Next(1, 50);
        for (int i = 0; i < Math.Min(ammo, Storrage.Count); i++)
        {
            var w = Storrage[i];
            if (tank.CanFit(w.Weight))
            {
                Console.WriteLine($"{tank.TankName} экипирует {w.Name} боеприпас");
                tank.Magazine.Add(w);
                Storrage.Remove(w);
            }
            else
            {
                Console.WriteLine($"{tank.TankName} перегружен");
                return;
            }

        }
    }


    private static Weapon GetRandomWeapon() => Random.Shared.Next(3) switch
    {
        0 => new Automatic(),
        1 => new Rifled(),
        _ => new Smooth()
    };

    private static Armor GetRandomArmor() => Random.Shared.Next(3) switch
    {
        0 => new Gomogen(),
        1 => new Dinamic(),
        _ => new Composite()
    };

    private static Ammo GetRandomAmmo() => Random.Shared.Next(3) switch
    {
        0 => new HE(),
        1 => new AP(),
        _ => new HEAT()
    };
}