namespace Wolfenstein.interfaces;

public interface IMapGenerator : IGameObject
{
    IMap GenerateRandomMap();
}