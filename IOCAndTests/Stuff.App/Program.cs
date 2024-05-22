// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Stuff.Core;

var serviceProvider = ContainerTools.CreateContainer();

var spaceship = serviceProvider.GetRequiredService<Spaceship>();
var projectile = serviceProvider.GetRequiredService<Projectile>();

spaceship.Fight();

Console.WriteLine($"Spaceship fired: {projectile.Detonated}");