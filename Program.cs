using System.Reflection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Warehouse warehouse = new Warehouse(400);

var teams = new List<Team>()
{
    new Team(1, "Bravo", new ComanderOrder()),
    new Team(2, "Alfa", new TypePriority()),
    new Team(3, "Omega", new ComanderOrder()),
};

teams[0].Add(new LightTank("L1"));
teams[0].Add(new MediumTank("M1"));
teams[0].Add(new MediumTank("M1.1"));
teams[1].Add(new HeavyTank("H2"));
teams[1].Add(new MediumTank("M2"));
teams[2].Add(new HeavyTank("H3"));
teams[2].Add(new MediumTank("M3"));

foreach (var tank in teams.SelectMany(t => t.Tanks))
{
    Warehouse.EqupedTank(tank);
    Warehouse.EqupedAmmo(tank);
}

Console.WriteLine(teams.Count(t => t.TeamIsAlive()));

int round = 1;
while (teams.Count(t => t.TeamIsAlive()) > 1 && round < 40)
{
    Console.WriteLine($"Раунд {round++} ");
    var shots = new List<Shot>();

    foreach (var team in teams)
    {
        team.Tactic.Reload();
        foreach (var tank in team.GetAlive())
        {
            if (!tank.Weapons.Any(w => tank.Magazine.Any(a => w.CanFire(a.Type))))
            {
                Console.WriteLine($"У {tank.TankName} закончились боеприпасы");
                Warehouse.EqupedAmmo(tank);
            }

        }
    }

    foreach (var team in teams.Where(t => t.TeamIsAlive()))
    {
        var enemy = teams.Where(t => t.Id != team.Id).SelectMany(t => t.Tanks).Where(t => t.IsAlive()).ToList();

        if (!enemy.Any()) continue;

        foreach (var attaker in team.GetAlive())
        {
            var target = team.Tactic.SelectTank(attaker, enemy);
            shots.AddRange(attaker.Attack(target));
        }
    }

    int roundDamage = 0;

    foreach(var shot in shots)
    {
        int damage = shot.CalculateFinalDamage();
        if (damage > 0)
        {
            shot.Target.TakeDamage(damage);
            Console.WriteLine($"{shot.Target.TankName}:-{damage}HP  ({shot.Target.CurrentHP})");
            roundDamage += damage;
        }
    }

}
var winner = teams.FirstOrDefault(t => t.TeamIsAlive());
Console.WriteLine($"Победила {winner?.Name}");

enum AmmoType{HE, AP, HEAT};