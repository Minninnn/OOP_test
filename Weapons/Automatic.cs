class Automatic : Weapon
{
    public override int Weight => 25;
    public override string Name =>"Автоматическое";
    protected override int MinDamage => 10;
    protected override int MaxDamage => 15;
    protected override float Accuracy => -0.1f;
    public override int ShootPerBurst => 3;
    protected override int Cooldown => 1;
    public override bool CanFire(AmmoType type) => type != AmmoType.HEAT;
    public override int CalculateDamage()
    {
        return Random.Next(MinDamage, MaxDamage +1);
    }
}