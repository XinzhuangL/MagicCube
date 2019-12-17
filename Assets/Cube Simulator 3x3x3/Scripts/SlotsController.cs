using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsController : MonoBehaviour
{
    #region 获取自定义魔方颜色数据，发送给 Model 处理
    public GameObject[] up;
    public GameObject[] bottom;
    public GameObject[] left;
    public GameObject[] right;
    public GameObject[] front;
    public GameObject[] back;

    [SerializeField] private string[,] upS;
    [SerializeField] private string[,] bottomS;
    [SerializeField] private string[,] leftS;
    [SerializeField] private string[,] rightS;
    [SerializeField] private string[,] frontS;
    [SerializeField] private string[,] backS;

    // 存储获取魔方颜色数据
    private Dictionary<int, string[,]> data;

    /// <summary>
    /// 获取颜色数据
    /// </summary>
    private void GetColorStr()
    {
        // 获取顶面颜色数据
        for (int i = 0; i < up.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    upS[j, k] = up[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
        // 获取底面颜色数据
        for (int i = 0; i < bottom.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    bottomS[j, k] = bottom[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
        // 获取左面颜色数据
        for (int i = 0; i < left.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    leftS[j, k] = left[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
        // 获取右面颜色数据
        for (int i = 0; i < right.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rightS[j, k] = right[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
        // 获取前面颜色数据
        for (int i = 0; i < front.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    frontS[j, k] = front[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
        // 获取后面颜色数据
        for (int i = 0; i < back.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    backS[j, k] = back[i].GetComponent<MeshRenderer>().material.GetTexture("_MainTex").name;
                }
            }
        }
    }

    private void IntegrationColorStr()
    {
        // 将数据写入字典
        data.Add(0, upS);
        data.Add(1, leftS);
        data.Add(2, frontS);
        data.Add(3, rightS);
        data.Add(4, backS);
        data.Add(5, bottomS);
        // 将字典发送到 Model
        dataModel.SetData(data);
    }

    #endregion

    DataModel dataModel;

    private void Start()
    {
        upS = bottomS = leftS = rightS = frontS = backS = new string[3, 3];
        data = new Dictionary<int, string[,]>();
    }

}
