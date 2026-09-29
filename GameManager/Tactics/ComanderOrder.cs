class ComanderOrder : ITactic
{
    public string Name => "Приказ командира";
    Tank? OrderTactic;
    public Tank SelectTank(Tank attaker, List<Tank> enemies)
    {
        if (OrderTactic == null || !enemies.Contains(OrderTactic))
        {
            OrderTactic = enemies[Random.Shared.Next(enemies.Count)];
        }
        return OrderTactic;
    }
    public void Reload() => OrderTactic = null;
}