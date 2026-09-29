class Composite : Armor
{
    public override int Weight => 10;
    public override string Name =>"Композитная";
    public override int CutDamage(int dmg, AmmoType type)
    {
        if (type == AmmoType.HEAT)
        {
            return (int)(dmg * 0.6f);
        }
        else return (int)(dmg * 0.85f);
        
    }
}