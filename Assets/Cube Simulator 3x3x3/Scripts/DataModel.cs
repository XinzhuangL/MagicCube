using System;
using System.Collections;
using System.Collections.Generic;

public class DataModel
{
    // 每个面完成的状态
    // 横竖相加均为 15
    private int[,] cempeletData ={
        {6,1,8 },
        {7,5,3 },
        {2,9,4 }
    };

    // 是否还原
    bool isRestore = false;
    // 存储复原步骤，用于 unity 里魔方的旋转
    string restoreSteps;
    // 每种颜色所对应的数值
    private List<char> whiteCount = new List<char> { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' };
    private List<char> greenCount = new List<char> { 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g' };
    private List<char> redCount = new List<char> { 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'r', 'r' };
    private List<char> blueCount = new List<char> { 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
    private List<char> orangeCount = new List<char> { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' };
    private List<char> yellowCount = new List<char> { 'y', 'y', 'y', 'y', 'y', 'y', 'y', 'y', 'y' };

    private int[] cornerT = { 2, 4, 6, 8 };
    private int[] edgeT = { 1, 3, 7, 9 };
    private int centerT = 5;

    // 角块位置
    private int[,] corner = {
    {2,4,6} , {2,4,8} , {4,6,8} , {2,6,8} ,
    {6,6,8} , {6,8,8} , {2,4,4} , {2,2,4}};

    // 边块位置
    private int[,] edge = {
    {1,9} , {3,7}, {1,9} , {3,7},
    {1,9} , {3,7}, {1,9} , {3,7},
    {1,9} , {3,7}, {1,9} , {3,7},};

    // 中心块位置
    private int[,] center = {
        {1,1 },{1,1 },{1,1 },{1,1 },{1,1 },{1,1 }
    };

    private char[,,] datas;

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="data"></param>
    public void SetData(Dictionary<int, string[,]> data)
    {
        for (int i = 0; i < data.Keys.Count; i++)
        {
            if (data.ContainsKey(0))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
            if (data.ContainsKey(1))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
            if (data.ContainsKey(2))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
            if (data.ContainsKey(3))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
            if (data.ContainsKey(4))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
            if (data.ContainsKey(5))
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        datas[i, j, k] = ConvertData(data[i][j, k]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 转换数据（将颜色数据转换为 int 类型）
    /// </summary>
    /// <param name="color"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private char ConvertData(string color)
    {
        Random random = new Random();
        char temp = 'n';
        switch (color)
        {
            case "white":
                temp = 'w';
                whiteCount.Remove('w');
                break;
            case "green":
                temp = 'g';
                greenCount.Remove('g');
                break;
            case "red":
                temp = 'r';
                redCount.Remove('r');
                break;
            case "blue":
                temp = 'b';
                blueCount.Remove('b');
                break;
            case "orange":
                temp = 'o';
                orangeCount.Remove('o');
                break;
            case "yellow":
                temp = 'y';
                yellowCount.Remove('y');
                break;
        }
        return temp;
    }

    /// <summary>
    /// 还原数据
    /// </summary>
    public void Restore()
    {
        if (isRestore)
        {
            return;
        }
        // 还原底部十字
        RestoreDownCross();
    }

    #region restore funcations

    /// <summary>
    /// 还原底部十字
    /// </summary>
    private void RestoreDownCross()
    {
        bool isUpCross = false;
        while (!isUpCross)
        {
            if (datas[5, 0, 1] == 'y' &&
                datas[5, 1, 0] == 'y' &&
                datas[5, 1, 2] == 'y' &&
                datas[5, 2, 1] == 'y' &&
                datas[1, 2, 1] == 'g' &&
                datas[2, 2, 1] == 'r' &&
                datas[3, 2, 1] == 'b' &&
                datas[4, 2, 1] == 'o')
                isUpCross = true;

            if (datas[1, 2, 1] == 'g' && datas[5, 1, 0] == 'y')
                for (int i = 0; i < 4; i++)
                {
                    if (datas[1, 2, 1] == 'g' && datas[5, 1, 0] == 'y')
                        break;
                    RotateL();
                }
            if (datas[2, 2, 1] == 'r' && datas[5, 0, 1] == 'y')
                for (int i = 0; i < 4; i++)
                {
                    if (datas[2, 2, 1] == 'r' && datas[5, 0, 1] == 'y')
                        break;
                    RotateF();
                }
            if (datas[3, 2, 1] == 'b' && datas[5, 1, 2] == 'y')
                for (int i = 0; i < 4; i++)
                {
                    if (datas[3, 2, 1] == 'b' && datas[5, 1, 2] == 'y')
                        break;
                    RotateR();
                }
            if (datas[4, 2, 1] == 'o' && datas[5, 2, 1] == 'y')
                for (int i = 0; i < 4; i++)
                {
                    if (datas[4, 2, 1] == 'o' && datas[5, 2, 1] == 'y')
                        break;
                    RotateR();
                }
            RotateU();
        }
    }
    /// <summary>
    /// 还原底部角块
    /// </summary>
    private void RestoreDownCorner()
    {
        bool isDownCorner = false;
        if (datas[2, 0, 0] == datas[2, 1, 1] && datas[1, 0, 2] == datas[1, 1, 1] && datas[0, 2, 0] == datas[0, 1, 1] &&
            datas[2, 0, 0] == datas[2, 1, 1] && datas[1, 0, 2] == datas[1, 1, 1] && datas[0, 2, 0] == datas[0, 1, 1] &&
            datas[2, 0, 0] == datas[2, 1, 1] && datas[1, 0, 2] == datas[1, 1, 1] && datas[0, 2, 0] == datas[0, 1, 1] &&
            datas[2, 0, 0] == datas[2, 1, 1] && datas[1, 0, 2] == datas[1, 1, 1] && datas[0, 2, 0] == datas[0, 1, 1])
            isDownCorner = true;
        while (!isDownCorner)
        {
            if (datas[2, 0, 0] == datas[5, 1, 1] &&
                datas[0, 2, 0] == datas[2, 1, 1] &&
                datas[1, 0, 2] == datas[1, 1, 1])
            {
                RotateU();
                RotateL(); RotateL(); RotateL();
                RotateU(); RotateU(); RotateU();
                RotateL();
            }
            if (true)
            {
                //TODO
            }
        }
    }
    /// <summary>
    /// 还原侧棱块
    /// </summary>
    private void RestoreSideEdge()
    {
        bool isSideEdge = false;
        if (datas[1, 1, 0] == 'g' && datas[1, 1, 1] == 'g' && datas[1, 1, 2] == 'g' &&
            datas[2, 1, 0] == 'r' && datas[2, 1, 1] == 'r' && datas[2, 1, 2] == 'r' &&
            datas[3, 1, 0] == 'b' && datas[3, 1, 1] == 'b' && datas[3, 1, 2] == 'b' &&
            datas[4, 1, 0] == 'o' && datas[4, 1, 1] == 'o' && datas[4, 1, 2] == 'o')
            isSideEdge = true;
        while (!isSideEdge)
        {
            if (true)
            {

            }
        }
    }
    #endregion

    #region rotate funcation

    /// <summary>
    /// 转动前面（顺时针）
    /// </summary>
    private void RotateF()
    {
        char temp;
        temp = datas[0, 2, 0];
        datas[0, 2, 0] = datas[1, 2, 2];
        datas[1, 2, 2] = datas[5, 0, 2];
        datas[5, 0, 2] = datas[3, 0, 0];
        datas[3, 0, 0] = temp;
        temp = datas[0, 2, 1];
        datas[0, 2, 1] = datas[1, 1, 2];
        datas[1, 1, 2] = datas[5, 0, 1];
        datas[5, 0, 1] = datas[3, 1, 0];
        datas[3, 1, 0] = temp;
        temp = datas[0, 2, 2];
        datas[0, 2, 2] = datas[1, 0, 2];
        datas[1, 0, 2] = datas[5, 0, 0];
        datas[5, 0, 0] = datas[3, 2, 0];
        datas[3, 2, 0] = temp;
        temp = datas[2, 0, 0];
        datas[2, 0, 0] = datas[2, 2, 0];
        datas[2, 2, 0] = datas[2, 2, 2];
        datas[2, 2, 2] = datas[2, 0, 2];
        datas[2, 0, 2] = temp;
        temp = datas[2, 0, 1];
        datas[2, 0, 1] = datas[2, 1, 0];
        datas[2, 1, 0] = datas[2, 2, 1];
        datas[2, 2, 1] = datas[2, 1, 2];
        datas[2, 1, 2] = temp;
        restoreSteps += "F";    // 将旋转写入步骤里
    }
    /// <summary>
    /// 转动后面（顺时针）
    /// </summary>
    private void RotateB()
    {
        char temp;
        temp = datas[0, 0, 2];
        datas[0, 0, 2] = datas[3, 2, 2];
        datas[3, 2, 2] = datas[5, 0, 2];
        datas[5, 0, 2] = datas[1, 0, 0];
        datas[1, 0, 0] = temp;
        temp = datas[0, 0, 1];
        datas[0, 0, 1] = datas[3, 1, 2];
        datas[3, 1, 2] = datas[5, 2, 1];
        datas[5, 2, 1] = datas[1, 1, 0];
        datas[1, 1, 0] = temp;
        temp = datas[0, 0, 0];
        datas[0, 0, 0] = datas[3, 0, 2];
        datas[3, 0, 2] = datas[5, 2, 2];
        datas[5, 2, 2] = datas[1, 2, 0];
        datas[1, 2, 0] = temp;
        temp = datas[4, 0, 0];
        datas[4, 0, 0] = datas[4, 2, 0];
        datas[4, 2, 0] = datas[4, 2, 2];
        datas[4, 2, 2] = datas[4, 0, 2];
        datas[4, 0, 2] = temp;
        temp = datas[4, 0, 1];
        datas[4, 0, 1] = datas[4, 1, 0];
        datas[4, 1, 0] = datas[4, 2, 1];
        datas[4, 2, 1] = datas[4, 1, 2];
        datas[4, 1, 2] = temp;
        restoreSteps += "B";
    }
    /// <summary>
    /// 转动左面（顺时针）
    /// </summary>
    private void RotateL()
    {
        char temp;
        temp = datas[0, 0, 0];
        datas[0, 0, 0] = datas[4, 2, 2];
        datas[4, 2, 2] = datas[5, 0, 0];
        datas[5, 0, 0] = datas[2, 0, 0];
        datas[2, 0, 0] = temp;
        temp = datas[0, 1, 0];
        datas[0, 1, 0] = datas[4, 1, 2];
        datas[4, 1, 2] = datas[5, 1, 0];
        datas[5, 1, 0] = datas[2, 1, 0];
        datas[2, 1, 0] = temp;
        temp = datas[0, 2, 0];
        datas[0, 2, 0] = datas[4, 0, 2];
        datas[4, 0, 2] = datas[5, 2, 0];
        datas[5, 2, 0] = datas[2, 2, 0];
        datas[2, 2, 0] = temp;
        temp = datas[1, 0, 0];
        datas[1, 0, 0] = datas[1, 2, 0];
        datas[1, 2, 0] = datas[1, 2, 2];
        datas[1, 2, 2] = datas[1, 0, 2];
        datas[1, 0, 2] = temp;
        temp = datas[1, 0, 1];
        datas[1, 0, 1] = datas[1, 1, 0];
        datas[1, 1, 0] = datas[1, 2, 1];
        datas[1, 2, 1] = datas[1, 1, 2];
        datas[1, 1, 2] = temp;
        restoreSteps += "L";
    }
    /// <summary>
    /// 转动右侧
    /// </summary>
    private void RotateR()
    {
        char temp;
        temp = datas[0, 0, 2];
        datas[0, 0, 2] = datas[2, 0, 2];
        datas[2, 0, 2] = datas[5, 0, 2];
        datas[5, 0, 2] = datas[4, 2, 0];
        datas[4, 2, 0] = temp;
        temp = datas[0, 1, 2];
        datas[0, 1, 2] = datas[2, 1, 2];
        datas[2, 1, 2] = datas[5, 1, 2];
        datas[5, 1, 2] = datas[4, 1, 0];
        datas[4, 1, 0] = temp;
        temp = datas[0, 2, 2];
        datas[0, 2, 2] = datas[2, 2, 2];
        datas[2, 2, 2] = datas[5, 2, 2];
        datas[5, 2, 2] = datas[4, 0, 0];
        datas[4, 0, 0] = temp;
        temp = datas[3, 0, 0];
        datas[3, 0, 0] = datas[3, 2, 0];
        datas[3, 2, 0] = datas[3, 2, 2];
        datas[3, 2, 2] = datas[3, 0, 2];
        datas[3, 0, 2] = temp;
        temp = datas[3, 0, 1];
        datas[3, 0, 1] = datas[3, 1, 0];
        datas[3, 1, 0] = datas[3, 2, 1];
        datas[3, 2, 1] = datas[3, 1, 2];
        datas[3, 1, 2] = temp;
        restoreSteps += "R";

    }
    /// <summary>
    /// 转动顶部
    /// </summary>
    private void RotateU()
    {
        char temp;
        temp = datas[1, 0, 0];
        datas[1, 0, 0] = datas[2, 0, 0];
        datas[2, 0, 0] = datas[3, 0, 0];
        datas[3, 0, 0] = datas[4, 0, 0];
        datas[1, 0, 0] = temp;
        temp = datas[1, 0, 1];
        datas[1, 0, 1] = datas[2, 0, 1];
        datas[2, 0, 1] = datas[3, 0, 1];
        datas[3, 0, 1] = datas[4, 0, 1];
        datas[4, 0, 1] = temp;
        temp = datas[1, 0, 2];
        datas[1, 0, 2] = datas[2, 0, 2];
        datas[2, 0, 2] = datas[3, 0, 2];
        datas[3, 0, 2] = datas[4, 0, 2];
        datas[4, 0, 2] = temp;
        temp = datas[0, 0, 0];
        datas[0, 0, 0] = datas[0, 2, 0];
        datas[0, 2, 0] = datas[0, 2, 2];
        datas[0, 2, 2] = datas[0, 0, 2];
        datas[0, 0, 2] = temp;
        temp = datas[0, 0, 1];
        datas[0, 0, 1] = datas[0, 1, 0];
        datas[0, 1, 0] = datas[0, 2, 1];
        datas[0, 2, 1] = datas[0, 1, 2];
        datas[0, 1, 2] = temp;
        restoreSteps += "U";
    }
    /// <summary>
    /// 转动底部
    /// </summary>
    private void RotateD()
    {
        char temp;
        temp = datas[1, 2, 0];
        datas[1, 2, 0] = datas[4, 2, 0];
        datas[4, 2, 0] = datas[3, 2, 0];
        datas[3, 2, 0] = datas[2, 2, 0];
        datas[2, 2, 0] = temp;
        temp = datas[1, 2, 1];
        datas[1, 2, 1] = datas[4, 2, 1];
        datas[4, 2, 1] = datas[3, 2, 1];
        datas[3, 2, 1] = datas[2, 2, 1];
        datas[2, 2, 1] = temp;
        temp = datas[1, 2, 2];
        datas[1, 2, 2] = datas[4, 2, 2];
        datas[4, 2, 2] = datas[3, 2, 2];
        datas[3, 2, 2] = datas[2, 2, 2];
        datas[2, 2, 2] = temp;
        temp = datas[5, 0, 0];
        datas[5, 0, 0] = datas[5, 2, 0];
        datas[5, 2, 0] = datas[5, 2, 2];
        datas[5, 2, 2] = datas[5, 0, 2];
        datas[5, 0, 2] = temp;
        temp = datas[5, 0, 1];
        datas[5, 0, 1] = datas[5, 1, 0];
        datas[5, 1, 0] = datas[5, 2, 1];
        datas[5, 2, 1] = datas[5, 1, 2];
        datas[5, 1, 2] = temp;
        restoreSteps += "D";
    }
    #endregion
}
