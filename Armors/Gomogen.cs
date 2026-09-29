class Gomogen : Armor
{
    public override int Weight => 15;
    public override string Name =>"Катанная-гомогенная";
    public override int CutDamage(int dmg, AmmoType type)
    {
        return (int)(dmg * 0.80);
    }
}