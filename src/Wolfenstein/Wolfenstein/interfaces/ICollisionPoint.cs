namespace Wolfenstein.interfaces;

public interface ICollisionPoint
{
    IWallSegment WallSegment { get; }
    IRay Ray { get; }
}