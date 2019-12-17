using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CFOP
{
    public static string[] SideColors;
    //public static void Main(string[] Arg)
    //{
    //    Steps.Clear();
    //    if (Rubik.ImportColor(SideColors) == "")
    //    {
    //        TopCross();
    //        TopCorner();
    //        SecondLayer();
    //        BottomCross();
    //        BottomCorner();
    //        ThirdLayerCorner();
    //        ThirdLayerCornerSnap();
    //        ThirdLayerBorderSnap();
    //    }
    //    //步骤保存在steps对象中
    //    for (int i = 0; i < Steps.Count; i++)
    //    {
    //        Steps.Index = i;
    //    }
    //}

    public static void TopCross()
    {
        int GetPos = 0;
        int[] c = new int[5];
        int CurrentStep = Steps.Count;

        c[0] = Rubik.Sides[0, 1, 1];
        c[1] = Rubik.Sides[1, 1, 1];
        c[2] = Rubik.Sides[5, 1, 1];
        c[3] = Rubik.Sides[3, 1, 1];
        c[4] = Rubik.Sides[4, 1, 1];
        for (int i = 1; i < 5; i++)
        {
            CurrentStep = Steps.Count;
            Rubik.ChangeViewToColor(c[0]);
            Rubik.ChangeViewFromTopByNextColor(c[i]);
            GetPos = Rubik.FindBorderCell(c[0], c[i]);

            switch (GetPos)
            {
                case 101:
                    //已经固定的
                    break;
                case 110:
                    Steps.AddStep(1, false, 1);
                    Steps.AddStep(0, true, 1);
                    Steps.AddStep(4, false, 1);
                    Steps.AddStep(0, false, 1);
                    break;
                case 140:
                    Steps.AddStep(4, true, 1);
                    Steps.AddStep(1, true, 1);
                    break;
                case 104:
                    Steps.AddStep(4, true, 1);
                    Steps.AddStep(0, true, 1);
                    Steps.AddStep(4, false, 1);
                    Steps.AddStep(0, false, 1);
                    break;
                case 130:
                    Steps.AddStep(3, true, 1);
                    Steps.AddStep(0, true, 1);
                    Steps.AddStep(4, true, 1);
                    Steps.AddStep(0, false, 1);
                    break;
                case 103:
                    Steps.AddStep(3, true, 1);
                    Steps.AddStep(0, true, 2);
                    Steps.AddStep(3, false, 1);
                    Steps.AddStep(0, false, 2);
                    break;
                case 150:
                    Steps.AddStep(5, false, 1);
                    Steps.AddStep(1, false, 1);
                    break;
                case 105:
                    Steps.AddStep(5, false, 1);
                    Steps.AddStep(0, false, 1);
                    Steps.AddStep(5, true, 1);
                    Steps.AddStep(0, true, 1);
                    break;
                case 241:
                    Steps.AddStep(1, true, 1);
                    break;
                case 214:
                    Steps.AddStep(0, true, 1);
                    Steps.AddStep(4, false, 1);
                    Steps.AddStep(0, false, 1);
                    break;
                case 243:
                    Steps.AddStep(4, true, 2);
                    Steps.AddStep(1, true, 1);
                    Steps.AddStep(4, true, 2);
                    break;
                case 234:
                    Steps.AddStep(0, true, 1);
                    Steps.AddStep(4, true, 1);
                    Steps.AddStep(0, false, 1);
                    break;
                case 253:
                    Steps.AddStep(5, true, 2);
                    Steps.AddStep(1, false, 1);
                    Steps.AddStep(5, true, 2);
                    break;
                case 235:
                    Steps.AddStep(0, false, 1);
                    Steps.AddStep(5, false, 1);
                    Steps.AddStep(0, true, 1);
                    break;
                case 251:
                    Steps.AddStep(1, false, 1);
                    break;
                case 215:
                    Steps.AddStep(0, false, 1);
                    Steps.AddStep(5, true, 1);
                    Steps.AddStep(0, true, 1);
                    break;
                case 312:
                    Steps.AddStep(2, true, 1);
                    Steps.AddStep(5, true, 1);
                    Steps.AddStep(1, false, 1);
                    Steps.AddStep(5, false, 1);
                    break;
                case 321:
                    Steps.AddStep(1, true, 2);
                    break;
                case 342:
                    Steps.AddStep(4, false, 1);
                    Steps.AddStep(1, true, 1);
                    Steps.AddStep(4, true, 1);
                    break;
                case 324:
                    Steps.AddStep(2, true, 1);
                    Steps.AddStep(1, true, 2);
                    break;
                case 352:
                    Steps.AddStep(5, true, 1);
                    Steps.AddStep(1, false, 1);
                    Steps.AddStep(5, false, 1);
                    break;
                case 325:
                    Steps.AddStep(2, false, 1);
                    Steps.AddStep(1, true, 2);
                    break;
                case 332:
                    Steps.AddStep(2, true, 1);
                    Steps.AddStep(4, false, 1);
                    Steps.AddStep(1, true, 1);
                    Steps.AddStep(4, true, 1);
                    break;
                case 323:
                    Steps.AddStep(2, true, 2);
                    Steps.AddStep(1, true, 2);
                    break;
                default:
                    //Do nothing
                    break;
            }

            for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
            {
                Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
            }
            Rubik.ChangeViewToColor(c[0]);
        }
    }

    public static void TopCorner()
    {
        int CurrentStep = Steps.Count;
        int GetPos = 0;
        int[] c = new int[5];
        int nTopPos = 0;
        int nOtherPos = 0;
        int nSum = 0;
        bool bFlag = false;

        c[0] = Rubik.Sides[0, 1, 1];
        c[1] = Rubik.Sides[1, 1, 1];
        c[2] = Rubik.Sides[5, 1, 1];
        c[3] = Rubik.Sides[3, 1, 1];
        c[4] = Rubik.Sides[4, 1, 1];

        for (int i = 1; i < 5; i++)
        {
            Rubik.ChangeViewToColor(c[0]);
            Rubik.ChangeViewFromTopByNextColor(c[i]);

            int j = i + 1;
            if (j == 5) j = 1;
            GetPos = Rubik.FindCornerCell(c[0], c[i], c[j]);

            if (GetPos != 1015)
            {
                //1015 means already fixed
                if (GetPos < 2000)
                {
                    //In top layer, move to bottom first
                    CurrentStep = Steps.Count;
                    nTopPos = GetBit(GetPos, 3);
                    nSum = GetSum(GetPos) - 1;
                    nOtherPos = (nTopPos == 0 ? GetBit(GetPos, 1) : (nSum - nTopPos));
                    if (nOtherPos == 5 && nSum == 6) bFlag = false;
                    if (nOtherPos == 5 && nSum == 8) bFlag = true;
                    if (nOtherPos == 3 && nSum == 8) bFlag = false;
                    if (nOtherPos == 3 && nSum == 7) bFlag = true;
                    if (nOtherPos == 4 && nSum == 7) bFlag = false;
                    if (nOtherPos == 4 && nSum == 5) bFlag = true;
                    if (nOtherPos == 1 && nSum == 5) bFlag = false;
                    if (nOtherPos == 1 && nSum == 6) bFlag = true;

                    Steps.AddStep(nOtherPos, bFlag, 1);
                    Steps.AddStep(2, !bFlag, 1);
                    Steps.AddStep(nOtherPos, !bFlag, 1);

                    for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
                    {
                        Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
                    }
                    Rubik.ChangeViewToColor(c[0]);
                    Rubik.ChangeViewFromTopByNextColor(c[i]);
                    GetPos = Rubik.FindCornerCell(c[0], c[i], c[j]);
                }

                //Now the block has move to bottom, or alreay at bottom
                CurrentStep = Steps.Count;
                nSum = GetSum(GetPos) - 2 - 2; //1st"2":Bottom; 2nd"2":Layer 
                if (nSum == 8) Steps.AddStep(2, false, 1);
                if (nSum == 7) Steps.AddStep(2, true, 2);
                if (nSum == 5) Steps.AddStep(2, true, 1);
                for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
                {
                    Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
                }
                //Now the block is just under the bottom of current corner
                CurrentStep = Steps.Count;
                Rubik.ChangeViewToColor(c[0]);
                Rubik.ChangeViewFromTopByNextColor(c[i]);
                GetPos = Rubik.FindCornerCell(c[0], c[i], c[j]);
                nTopPos = GetBit(GetPos, 3);
                nSum = GetSum(GetPos) - 2 - 2;

                if (nSum != 6)
                {
                    return;
                }

                if (nTopPos == 1)
                {
                    Steps.AddStep(1, true, 1);
                    Steps.AddStep(2, true, 1);
                    Steps.AddStep(1, false, 1);
                }
                if (nTopPos == 5)
                {
                    Steps.AddStep(5, false, 1);
                    Steps.AddStep(2, false, 1);
                    Steps.AddStep(5, true, 1);
                }
                if (nTopPos == 2)
                {
                    Steps.AddStep(1, true, 1);
                    Steps.AddStep(2, false, 1);
                    Steps.AddStep(1, false, 1);
                    Steps.AddStep(5, false, 1);
                    Steps.AddStep(2, true, 2);
                    Steps.AddStep(5, true, 1);
                }

                for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
                {
                    Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
                }
            }
        }
        Rubik.ChangeViewToColor(c[0]);
    }

    public static void SecondLayer()
    {
        int CurrentStep = Steps.Count;
        int GetPos = 0, cu = 0, cb = 0; //CU:底边颜色; CB: 背面颜色
        int Center1 = 0, Center2 = 0;   //Center1, 旋转中心; center2, 它旁边的另一个中心 
        int ErrC1 = 0, ErrC2 = 0;       //ErrC1 / Errc2, 需要修复的边界
        int[] c = new int[6];
        bool bFlag = true, bClockWise = false;

        c[0] = Rubik.Sides[0, 1, 1];
        c[1] = Rubik.Sides[1, 1, 1];
        c[2] = Rubik.Sides[5, 1, 1];
        c[3] = Rubik.Sides[3, 1, 1];
        c[4] = Rubik.Sides[4, 1, 1];
        c[5] = Rubik.Sides[2, 1, 1];

        while (bFlag)
        {
            bFlag = false;
            ErrC1 = 0;
            for (int i = 1; i < 5; i++)
            {
                Rubik.ChangeViewToColor(c[0]);
                Rubik.ChangeViewFromTopByNextColor(c[i]);
                cu = Rubik.Sides[2, 1, 0];
                cb = Rubik.Sides[1, 1, 2];

                if (cu != c[5] && cb != c[5])
                {
                    //这个可以移动到第二层
                    CurrentStep = Steps.Count;
                    bFlag = true;
                    Center1 = Rubik.FindCenter(cu);
                    Center2 = Rubik.FindCenter(cb);
                    //搬到相反的地方
                    if (Center1 == 1) Steps.AddStep(2, true, 2);
                    if (Center1 == 5) Steps.AddStep(2, false, 1);
                    if (Center1 == 4) Steps.AddStep(2, true, 1);
                    //设置旋转方向
                    if (Center1 == 1 && Center2 == 5) bClockWise = true;
                    if (Center1 == 1 && Center2 == 4) bClockWise = false;
                    if (Center1 == 5 && Center2 == 3) bClockWise = true;
                    if (Center1 == 5 && Center2 == 1) bClockWise = false;
                    if (Center1 == 3 && Center2 == 4) bClockWise = true;
                    if (Center1 == 3 && Center2 == 5) bClockWise = false;
                    if (Center1 == 4 && Center2 == 1) bClockWise = true;
                    if (Center1 == 4 && Center2 == 3) bClockWise = false;
                    //开始旋转
                    Steps.AddStep(Center1, bClockWise, 1);
                    Steps.AddStep(2, !bClockWise, 1);
                    Steps.AddStep(Center1, !bClockWise, 1);
                    Steps.AddStep(2, !bClockWise, 1);
                    Steps.AddStep(Center2, !bClockWise, 1);
                    Steps.AddStep(2, bClockWise, 1);
                    Steps.AddStep(Center2, bClockWise, 1);
                    //Actions
                    for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
                    {
                        Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
                    }
                    Rubik.ChangeViewToColor(c[0]);
                    break;
                }

                //Check if the sencond layer is ok
                if (!bFlag && ErrC1 == 0)
                {
                    if (Rubik.Sides[1, 1, 1] != Rubik.Sides[1, 0, 1] || Rubik.Sides[5, 1, 1] != Rubik.Sides[5, 1, 2])
                    {
                        ErrC1 = Rubik.Sides[1, 1, 1];
                        ErrC2 = Rubik.Sides[5, 1, 1];
                    }
                }
            }
        }

        //Now All the blocks in bottom has been moved to second layer
        if (ErrC1 > 0)
        {
            //if there are still error blocks in second layer, move to bottom first
            Rubik.RotateRealSide(ErrC1, true, 1);
            Rubik.RotateRealSide(c[5], false, 1);
            Rubik.RotateRealSide(ErrC1, false, 1);
            Rubik.RotateRealSide(c[5], false, 1);
            Rubik.RotateRealSide(ErrC2, false, 1);
            Rubik.RotateRealSide(c[5], true, 1);
            Rubik.RotateRealSide(ErrC2, true, 1);
            Rubik.ChangeViewToColor(c[0]);
            SecondLayer();
        }
    }

    public static void BottomCross()
    {
        int CurrentStep = Steps.Count;

        //Change view to the bottom
        int c = Rubik.Sides[2, 1, 1];
        int[] b = new int[4];
        int[] d = { 5, 3, 4, 1 };
        Rubik.ChangeViewToColor(c);

        int nSum = 0, nPos = 0;
        b[0] = Rubik.Sides[0, 0, 1];
        b[1] = Rubik.Sides[0, 1, 0];
        b[2] = Rubik.Sides[0, 2, 1];
        b[3] = Rubik.Sides[0, 1, 2];
        for (int i = 0; i < 4; i++)
        {
            if (b[i] == c)
            {
                nSum++;
                nPos += d[i];
            }
        }

        if (nSum == 4) return;
        if (nSum == 0)
        {
            CurrentStep = Steps.Count;
            Steps.AddStep(1, false, 1);
            Steps.AddStep(4, false, 1);
            Steps.AddStep(0, false, 1);
            Steps.AddStep(4, true, 1);
            Steps.AddStep(0, true, 1);
            Steps.AddStep(1, true, 1);
            Steps.AddStep(3, false, 1);
            Steps.AddStep(0, false, 1);
            Steps.AddStep(5, false, 1);
            Steps.AddStep(0, true, 1);
            Steps.AddStep(5, true, 1);
            Steps.AddStep(3, true, 1);
        }
        if (nSum == 2)
        {
            CurrentStep = Steps.Count;
            if (nPos == 4) Rubik.ChangeViewFromTop(true);
            if (nPos == 4 || nPos == 9)
            {
                Steps.AddStep(1, false, 1);
                Steps.AddStep(4, false, 1);
                Steps.AddStep(0, false, 1);
                Steps.AddStep(4, true, 1);
                Steps.AddStep(0, true, 1);
                Steps.AddStep(1, true, 1);
            }
            else
            {
                if (nPos == 6) Rubik.ChangeViewFromTop(false);
                if (nPos == 7) Rubik.ChangeViewFromTop(true);
                if (nPos == 5)
                {
                    Rubik.ChangeViewFromTop(true);
                    Rubik.ChangeViewFromTop(true);
                }
                Steps.AddStep(1, false, 1);
                Steps.AddStep(0, false, 1);
                Steps.AddStep(4, false, 1);
                Steps.AddStep(0, true, 1);
                Steps.AddStep(4, true, 1);
                Steps.AddStep(1, true, 1);
            }
        }
        for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
        {
            Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
        }
        Rubik.ChangeViewToColor(c);
    }

    public static void BottomCorner()
    {
        int CurrentStep = Steps.Count;
        int c = Rubik.Sides[0, 1, 1];
        int[] b = new int[4];
        int[] d = { 5, 3, 4, 1 };
        int[] Pos2 = { -1, -1 };
        int nSum = 0, nPos = 0, nFirst = 0, nSecond = 0;
        bool bDirect = true, bMoreTime = false;
        b[0] = Rubik.Sides[0, 0, 2];
        b[1] = Rubik.Sides[0, 0, 0];
        b[2] = Rubik.Sides[0, 2, 0];
        b[3] = Rubik.Sides[0, 2, 2];
        for (int i = 0; i < 4; i++)
        {
            if (b[i] == c)
            {
                nSum++;
                nPos = d[i];
            }
            else
            {
                if (Pos2[0] == -1) Pos2[0] = i;
                else Pos2[1] = i;
            }
        }

        if (nSum == 4) return;
        if (nSum == 1)
        {
            Rubik.ChangeViewFromTopByNextColor(Rubik.Sides[nPos, 1, 1]);
            bDirect = (Rubik.Sides[1, 0, 0] == c);
            if (bDirect) nFirst = 5;
            else nFirst = 3;
            Steps.Clear();
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(0, bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
            Steps.AddStep(0, bDirect, 1);
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(0, bDirect, 2);
            Steps.AddStep(nFirst, !bDirect, 1);
        }
        if (nSum == 2)
        {
            for (int i = 0; i < Pos2[0]; i++) Rubik.ChangeViewFromTop(true);
            bDirect = (Rubik.Sides[1, 0, 0] == c);
            nFirst = bDirect ? 5 : 1;
            nSecond = 6 - nFirst;
            Steps.Clear();
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(nSecond, !bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
            Steps.AddStep(nSecond, bDirect, 1);
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(nSecond, !bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
            Steps.AddStep(nSecond, bDirect, 1);
            Steps.AddStep(0, true, Pos2[1] - Pos2[0]);
            Steps.AddStep(nSecond, !bDirect, 1);
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(nSecond, bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
            Steps.AddStep(nSecond, !bDirect, 1);
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(nSecond, bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
        }
        if (nSum == 0)
        {
            bMoreTime = true;
            for (int i = 0; i < 4; i++)
            {
                if (Rubik.Sides[1, 0, 0] == c && Rubik.Sides[1, 2, 0] == c) break;
                Rubik.ChangeViewFromTop(true);
            }
            nFirst = 3;
            bDirect = false;
            Steps.Clear();
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(0, bDirect, 1);
            Steps.AddStep(nFirst, !bDirect, 1);
            Steps.AddStep(0, bDirect, 1);
            Steps.AddStep(nFirst, bDirect, 1);
            Steps.AddStep(0, bDirect, 2);
            Steps.AddStep(nFirst, !bDirect, 1);
        }
        for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
        {
            Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
        }
        Rubik.ChangeViewToColor(c);
        if (bMoreTime) BottomCorner();
    }

    public static void ThirdLayerCorner()
    {
        int CurrentStep = Steps.Count;
        int c = Rubik.Sides[0, 1, 1];
        bool bMoreTime = true;

        for (int i = 0; i < 4; i++)
        {
            if (Rubik.Sides[1, 0, 0] == Rubik.Sides[1, 2, 0])
            {
                if (Rubik.Sides[5, 2, 0] == Rubik.Sides[5, 2, 2]) return;
                else
                {
                    bMoreTime = false;
                    break;
                }
            }
            Rubik.ChangeViewFromTop(true);
        }

        Steps.AddStep(5, true, 1);
        Steps.AddStep(3, false, 1);
        Steps.AddStep(5, true, 1);
        Steps.AddStep(1, true, 2);
        Steps.AddStep(5, false, 1);
        Steps.AddStep(3, true, 1);
        Steps.AddStep(5, true, 1);
        Steps.AddStep(1, true, 2);
        Steps.AddStep(5, true, 2);

        for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
        {
            Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
        }

        Rubik.ChangeViewToColor(c);
        if (bMoreTime) ThirdLayerCorner();
    }

    public static void ThirdLayerCornerSnap()
    {
        int c = Rubik.Sides[0, 1, 1];
        int nBorderColor = Rubik.Sides[1, 0, 0];
        int nCenter = Rubik.FindCenter(nBorderColor);
        int CurrentStep = Steps.Count;

        if (nCenter == 5) Steps.AddStep(0, false, 1);
        if (nCenter == 3) Steps.AddStep(0, false, 2);
        if (nCenter == 4) Steps.AddStep(0, true, 1);

        for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
        {
            Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
        }

        Rubik.ChangeViewToColor(c);
    }

    public static void ThirdLayerBorderSnap()
    {
        int c = Rubik.Sides[0, 1, 1];
        bool bMoreTime = true;
        bool bDirect = true;

        for (int i = 0; i < 4; i++)
        {
            if (Rubik.Sides[1, 0, 0] == Rubik.Sides[1, 1, 0])
            {
                if (Rubik.Sides[5, 2, 0] == Rubik.Sides[5, 2, 1]) return;
                else
                {
                    bDirect = (Rubik.Sides[5, 2, 1] == Rubik.Sides[4, 1, 1]);
                    bMoreTime = false;
                    break;
                }
            }
            Rubik.ChangeViewFromTop(true);
        }

        int CurrentStep = Steps.Count;

        Steps.AddStep(3, true, 2);
        Steps.AddStep(0, bDirect, 1);
        Steps.AddStep(4, false, 1);
        Steps.AddStep(5, true, 1);
        Steps.AddStep(3, true, 2);
        Steps.AddStep(5, false, 1);
        Steps.AddStep(4, true, 1);
        Steps.AddStep(0, bDirect, 1);
        Steps.AddStep(3, true, 2);

        for (Steps.Index = CurrentStep; Steps.Index < Steps.Count; Steps.Index++)
        {
            Rubik.RotateRealSide(Steps.Color(), Steps.ClockWise(), Steps.Quarter());
        }

        Rubik.ChangeViewToColor(c);
        if (bMoreTime) ThirdLayerBorderSnap();
    }

    public static int GetBit(int n, int m)
    {
        double nFilter = Math.Pow(10.0, m - 1);
        n = (int)Math.Floor(n / nFilter);
        return n % 10;
    }

    public static int GetSum(int n)
    {
        int nReturn = 0;
        while (n > 0)
        {
            nReturn += n % 10;
            n = (n - n % 10) / 10;
        }
        return nReturn;
    }

}

