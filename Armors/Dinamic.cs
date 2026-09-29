class Dinamic : Armor
{
    public override int Weight => 20;
    public override string Name =>"Динамическая";
    public override int CutDamage(int dmg, AmmoType type)
    {
        Random random = new Random();
        if (type == AmmoType.HEAT && random.NextDouble() < 0.2)
        {
            return 0;
        }
        else return (int)(dmg * 0.8);
    }
}