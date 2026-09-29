interface ITactic
{
    string Name { get; }
    Tank SelectTank(Tank attaker, List<Tank> enemies);
    void Reload();
}