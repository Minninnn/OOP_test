class HeavyTank : Tank
{
    public HeavyTank(string name):base(name)
    {
        MaxHP = CurrentHP = 750;
        DodgeChance = 0.0f;
        MaxWeight = 200;
    }
    protected override int MaxWeapon => 2;
}