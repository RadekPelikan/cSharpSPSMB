using System.Collections.Generic;

namespace Wolfenstein.interfaces;

public interface IMap
{
    List<IWallSegment> WallSegments { get; }
    IPlayer Player { get; }
}