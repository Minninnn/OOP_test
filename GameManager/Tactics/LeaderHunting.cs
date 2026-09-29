class LeaderHunting : ITactic
{
    public string Name => "Охота на лидера";

    public Tank SelectTank(Tank attaker, List<Tank> enemies)
    {
        return enemies.MaxBy(t => t.CurrentHP)!;
    }
    public void Reload() { }
}
