class MediumTank : Tank
{
    public MediumTank(string name):base(name)
    {
        MaxHP = CurrentHP = 550;
        DodgeChance = 0.07f;
        MaxWeight = 100;
    }
}