class Rifled : Weapon
{
    public override int Weight => 15;
    public override string Name =>"Нарезное";
    protected override int MinDamage => 20;
    protected override int MaxDamage => 30;
    protected override float Accuracy => 0.1f;
    public override int ShootPerBurst => 1;
    protected override int Cooldown => 0;
    public override bool CanFire(AmmoType type) => true;

    public override int CalculateDamage()
    {
        return Random.Next(MinDamage, MaxDamage +1);
    }
}