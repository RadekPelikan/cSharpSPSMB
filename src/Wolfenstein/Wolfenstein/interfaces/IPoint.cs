namespace Wolfenstein.interfaces;

public interface IPoint
{
    IWallSegment WallSegment { get; }
    IRay Ray { get; }
}