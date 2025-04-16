using System;
using Microsoft.Xna.Framework;

namespace TestGames.Extensions;

public static class GameServiceContainerExtensions
{
    public static TService GetServiceOrThrow<TService>(this GameServiceContainer gameServiceContainer) where TService : class
    {
        var service = gameServiceContainer.GetService<TService>();
        if (service is null)
            throw new ArgumentNullException($"The service of type {typeof(TService).Name} was not found.");
        
        return service;
    }
}