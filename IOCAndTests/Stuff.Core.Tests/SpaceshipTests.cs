namespace Stuff.Core.Tests;

public class SpaceshipTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFightDetonatesProjectile()
    {
        var projectile = new Projectile();
        var spaceship = new Spaceship(new Pilot(), new Weapon(projectile));
        
        Assert.That(projectile.Detonated, Is.False);

        spaceship.Fight();
        
        Assert.That(projectile.Detonated, Is.True);
    }
}