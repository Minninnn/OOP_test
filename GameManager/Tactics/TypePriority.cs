class TypePriority : ITactic
{
    public string Name => "По приоритету типов";

    public Tank SelectTank(Tank attaker, List<Tank> enemies)
    {
        Tank? prefer = attaker switch
        {
            HeavyTank => enemies.FirstOrDefault(t => t is MediumTank),
            MediumTank => enemies.FirstOrDefault(t => t is LightTank),
            _ => null
        };
        return prefer ?? enemies[Random.Shared.Next(enemies.Count)];
    }
    public void Reload() { }
}
