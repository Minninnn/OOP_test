class LightTank : Tank
{
    public LightTank(string name):base(name)
    {
        MaxHP = CurrentHP = 450;
        DodgeChance = 0.15f;
        MaxWeight = 85;
    }
}
