abstract class Ammo
{
    public string Name{get; protected set;} = "";
    public AmmoType Type;
    public abstract int Weight { get; }
    public abstract int Damage {get;}
}