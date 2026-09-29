class HEAT : Ammo
{
    public override int Damage => 15;
    public override int Weight => 1;
    public HEAT()
    {
        Type = AmmoType.HEAT;
        Name = "КС";
    }
}