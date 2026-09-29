class AP : Ammo
{
    public override int Damage => 10;
    public override int Weight => 1;
    public AP()
    {
        Type = AmmoType.AP;
        Name = "БП";

    }
}