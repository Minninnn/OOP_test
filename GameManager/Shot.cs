class Shot
{
    private int RawDamage;
    public Tank Target;
    private AmmoType AmmoType;

    public Shot(int rawDamage, Tank target, AmmoType ammoType)
    {
        RawDamage = rawDamage;
        Target = target;
        AmmoType = ammoType;
    }

    public int CalculateFinalDamage()
    {
        if (Target.TryToDodge() || Target.CurrentArmor == null) return 0;
        int finalDamage = Target.CurrentArmor.CutDamage(RawDamage, AmmoType);
        return finalDamage;
    }
}