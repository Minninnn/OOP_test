class Finifing : ITactic 
{
    public string Name => "Добивание";

    public Tank SelectTank(Tank attaker, List<Tank> enemies)
    {
        return enemies.MinBy(t => t.CurrentHP)!;
    }
    public void Reload() { }
}