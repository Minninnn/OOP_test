abstract class Tank
{
    public int MaxWeight = 0;
    public string TankName;
    public int CurrentHP;
    protected int MaxHP;
    protected float DodgeChance;
    public List<Ammo> Magazine = new();
    public Armor? CurrentArmor;
    public List<Weapon>Weapons = new();
    protected Random Random = new Random();
    public int TeamID;

    public int CurrentWeight => Weapons.Sum(x => x.Weight) + (CurrentArmor?.Weight ?? 0) + Magazine.Sum(x => x.Weight);

    public bool CanFit(int itemWeight)=> CurrentWeight + itemWeight < MaxWeight;

    protected virtual int MaxWeapon => 1;
    protected virtual int MaxArmor => 1;

    public int GetMaxWeapon() => MaxWeapon;
    public int GetMaxArmor() => MaxArmor;

    public Tank(string name)
    {
        TankName = name;
    }

    public bool IsAlive()=> CurrentHP > 0;
    public void TakeDamage(int damage) => CurrentHP = Math.Max(0, CurrentHP - damage);

    //public void EquipWeapon(List<Weapon> weapons)
    //{
    //    foreach (var weapon in weapons)
    //    {
    //        Weapons.Add (weapon);
    //        Console.Write($"{TankName} получил оружие:{weapon.Name}");
    //    }
    //}

    public bool TryToDodge() => Random.NextDouble() < DodgeChance;

    public List<Shot> Attack(Tank target)
    {
        var shot = new List<Shot>();

        foreach(var weapon in Weapons)
        {
            // Проверка перезарядки
            if(!weapon.IsReady())
            {
                weapon.CurrentCooldown--;
                Console.WriteLine($"{TankName} перезаряжается");
                continue;
            }

            if (weapon.Name == "Автоматическое")
            {
                weapon.CurrentCooldown++;
            }

            //Расчет урона
            for(int i = 0; i < weapon.ShootPerBurst; i++)
            {
                //Проверка на попадание
                if (!weapon.TryToHit())
                {
                    Console.WriteLine("Промах");
                    continue;
                }

                int id = Magazine.FindIndex(ammo => weapon.CanFire(ammo.Type));
                if (id < 0)
                {
                    Console.WriteLine($"{TankName} не имеет подходящих боеприпасов");
                    continue;
                }
                    Ammo ammo = Magazine[id];
                Magazine.RemoveAt(id);

                //Расчет урона ствола + боеприпас
                int rawDamage = weapon.CalculateDamage() + ammo.Damage;
                shot.Add(new Shot(rawDamage, target, ammo.Type));
            }
        }
        return shot;
    }

    private bool HasCompatibleAmmo() => Weapons.Any(w=> Magazine.Any(a => w. CanFire(a.Type)));

    public bool TryResupply(AmmoFabric ammoFabric, int threshold, int amount)
    {
        if (HasCompatibleAmmo()) return false;

        var newAmmo = AmmoFabric.RequestAmmo(amount);
        if (newAmmo.Any())
        {
            Magazine.AddRange(newAmmo);
            var summary = newAmmo.GroupBy(a => a.Name).Select(g => $"{g.Key}:{g.Count()}");
            Console.WriteLine($"{TankName} пополнил {newAmmo.Count()} снарядов {string.Join(",", summary)}");
            return true;
        }
        Console.WriteLine("Склад пуст");
        return false;
    }
}