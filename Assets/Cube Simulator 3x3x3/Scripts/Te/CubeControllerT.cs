using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeTags
{
    bottom, up, left, right, fornt, back
}

public class CubeControllerT : MonoBehaviour
{
    public Transform core;  //作为旋转的基准

    public Transform[] centers;//中心块组
    public Transform[] edges;  //边块组
    public Transform[] cornors; //角块组
    public GameObject[] colorCubesB;
    public GameObject[,] colorCubes;
    public CubeBase[] baseCubes;

    private string tempStr;

    private void Awake()
    {
        CFOP.SideColors = new string[6];
        centers = new Transform[6];
        edges = new Transform[12];
        cornors = new Transform[8];
        colorCubesB = new GameObject[54];
        for (int i = 0; i < 6; i++)
            centers[i] = GameObject.FindGameObjectWithTag("Center Piece " + (i + 1)).transform;
        for (int i = 0; i < 12; i++)
            edges[i] = GameObject.FindGameObjectWithTag("Edge Piece " + (i + 1)).transform;
        for (int i = 0; i < 8; i++)
            cornors[i] = GameObject.FindGameObjectWithTag("Corner Piece " + (i + 1)).transform;



    }

    void Start()
    {


    }

    void Update()
    {

    }

    /// <summary>
    /// 根据颜色设置面（默认白色为底面）
    /// 白（底）-黄（顶），红（左）-绿（右），蓝（前）-橙（后）
    /// </summary>
    public void SetColorStr() 
    {
        for (int i = 0; i < colorCubesB.Length - 1; i++)
        {
            switch (colorCubesB[i].GetComponent<CubeBase>().CubeColor)
            {
                case CubeColor.BLUE:
                    tempStr += "b";
                    break;
                case CubeColor.GREEN:
                    tempStr += "g";
                    break;
                case CubeColor.ORANGE:
                    tempStr += "o";
                    break;
                case CubeColor.RED:
                    tempStr += "r";
                    break;
                case CubeColor.WHITE:
                    tempStr += "w";
                    break;
                case CubeColor.YELLOW:
                    tempStr += "y";
                    break;
                default:
                    // do nothing
                    break;
            }
        }
        StartCoroutine(WriteData());
    }

    public IEnumerator WriteData()
    {
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 9; j++)
            {
                switch (colorCubesB[i].tag)
                {
                    case "bottom":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    case "up":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    case "left":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    case "right":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    case "fornt":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    case "back":
                        CFOP.SideColors[i] += colorCubesB[i];
                        break;
                    default:
                        //
                        break;
                }
            }
        yield return CP();
    }

    public static IEnumerator CP()
    {
        Steps.Clear();
        if (Rubik.ImportColor(CFOP.SideColors) == "")
        {
            CFOP.TopCross();
            CFOP.TopCorner();
            CFOP.SecondLayer();
            CFOP.BottomCross();
            CFOP.BottomCorner();
            CFOP.ThirdLayerCorner();
            CFOP.ThirdLayerCornerSnap();
            CFOP.ThirdLayerBorderSnap();
        }
        //步骤保存在steps对象中
        for (int i = 0; i < Steps.Count; i++)
        {
            Steps.Index = i;
        }
        yield return 0;
    }
}
