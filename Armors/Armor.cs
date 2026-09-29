abstract class Armor
{
    public abstract string Name{get;}
    public abstract int Weight { get; }
    public abstract int CutDamage(int dmg, AmmoType type);
}