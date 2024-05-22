namespace Stuff.Core;

public class Projectile
{
    public bool Detonated { get; set; }

    public void Detonate()
    {
        Detonated = true;
    }
}