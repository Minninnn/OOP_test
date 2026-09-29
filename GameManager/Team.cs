class Team
{
    public int Id { get;}
    public string Name { get;}
    public List<Tank> Tanks { get; } = new();
    public ITactic Tactic { get; set;}

    public Team(int id, string name, ITactic tactic)
    {
        Id = id;
        Name = name;
        Tactic = tactic;
    }

    public void Add(Tank tank) => Tanks.Add(tank);
    public bool TeamIsAlive() => Tanks.Any(t => t.IsAlive());
    public List<Tank> GetAlive() => Tanks.Where(t => t.IsAlive()).ToList();
}