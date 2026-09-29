class HE : Ammo
{
    public override int Damage => 5;
    public override int Weight => 2;
    public HE()
    {
        Type = AmmoType.HE;
        Name = "ОФ";
    }

}