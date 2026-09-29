class Concentration : ITactic
{
    public string Name => "Концентрация";
    Tank? ConcentrationTarget;

    public Tank SelectTank(Tank attaker, List<Tank> enemies)
    {
        if (ConcentrationTarget != null && enemies.Contains(ConcentrationTarget) && ConcentrationTarget.IsAlive())
        {
            return ConcentrationTarget;
        }
        return ConcentrationTarget = enemies[Random.Shared.Next(enemies.Count)];
    }
    public void Reload() { }
}