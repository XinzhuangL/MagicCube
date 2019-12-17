using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBase : MonoBehaviour
{
    public Type Type { get; set; }
    public CubeType CubeType { get; set; }
    public CubeColor CubeColor { get; set; }

    public void SetType()
    {
        switch (CubeColor)
        {
            case CubeColor.BLUE:
                
                break;
            case CubeColor.GREEN:
                break;
            case CubeColor.ORANGE:
                break;
            case CubeColor.RED:
                break;
            case CubeColor.WHITE:
                break;
            case CubeColor.YELLOW:
                break;
            default:
                break;
        }
    }
}

/// <summary>
/// 面的类型（前后左右上下）
/// </summary>
public enum Type
{
    NULL = 0,
    BOTTOM, UP,
    LEFT, RIGHT,
    FRONT, BACK
}
/// <summary>
/// Cube类型（中心块、边块、角块）
/// </summary>
public enum CubeType
{
    CENTER = 1,
    EDGE = 2,
    CORNER = 3
}
/// <summary>
/// Cube颜色
/// </summary>
public enum CubeColor
{
    BLUE = 1,
    GREEN = 2,
    ORANGE = 3,
    RED = 4,
    WHITE = 5,
    YELLOW = 6
}
