class Smooth : Weapon
{
    public override int Weight => 12;
    public override string Name =>"Гладкоствольное";
    protected override int MinDamage => 35;
    protected override int MaxDamage => 45;
    protected override float Accuracy => 0.0f;
    public override int ShootPerBurst => 1;
    protected override int Cooldown => 0;
    public override bool CanFire(AmmoType type) => true;

    public override int CalculateDamage()
    {
        return Random.Next(MinDamage, MaxDamage +1);
    }
}