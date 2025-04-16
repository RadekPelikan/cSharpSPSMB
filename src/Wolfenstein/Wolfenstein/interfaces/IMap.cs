using System.Collections.Generic;

namespace Wolfenstein.interfaces;

public interface IMap : IGameObject
{
    List<IWallSegment> WallSegments { get; }
    IPlayer Player { get; }
}