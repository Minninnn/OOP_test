abstract class Weapon
{
    public abstract string Name {get;}
    protected Random Random = new Random();
    protected abstract int MinDamage{get;}
    protected abstract int MaxDamage{get;}
    protected abstract float Accuracy{get;}
    public abstract int ShootPerBurst{get;}
    public abstract int Weight { get;}
    protected abstract int Cooldown{get;}
    public abstract bool CanFire(AmmoType type);
    public abstract int CalculateDamage();

    public int CurrentCooldown = 0;
    public bool IsReady() => CurrentCooldown <= 0;
    public bool TryToHit() => Random.NextDouble() < (0.8f + Accuracy);
    
}