namespace Stuff.Core;

public class Weapon
{
    private readonly Projectile _projectile;

    public Weapon(Projectile projectile)
    {
        _projectile = projectile;
    }

    public void Fire()
    {
        _projectile.Detonate();
    }
}