using System;

public static class Rubik
{
    public static int[,,] Sides = new int[7, 3, 3];
    public static int[] Position = new int[6];

    public static string ImportColor(string[] SideColors)
    {
        try
        {
            int[] Check = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
            {
                string szColors = SideColors[i];
                if (szColors.Length != 9) return "len(Side" + i + ")=" + szColors.Length;
                for (int j = 0; j < 9; j++)
                {
                    int nColor = ColorT.Value(szColors.Substring(j, j + 1));
                    if (nColor == 0) return "Side" + i + "," + j + "=" + szColors.Substring(j, j + 1);
                    int y = j % 3;
                    int x = (j - y) / 3;
                    Check[nColor - 1]++;
                    Sides[i, x, y] = nColor;
                    if (j == 4) Position[i] = nColor;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (Check[i] != 9) return "Check" + i + "=" + Check[i];
            }
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public static void ChangeViewToColor(int nColor)
    {
        int nNewCenter = -1;
        for (int i = 0; i < 6; i++)
        {
            if (Sides[i, 1, 1] == nColor) nNewCenter = i;
        }

        if (nNewCenter == 0) return;
        if (nNewCenter == 1)
        {
            CopyMatrics(0, 6, 0);
            CopyMatrics(1, 0, 0);
            CopyMatrics(2, 1, 0);
            CopyMatrics(3, 2, 0);
            CopyMatrics(6, 3, 0);
            CopyMatrics(5, 6, 0);
            CopyMatrics(6, 5, 1);
            CopyMatrics(4, 6, 0);
            CopyMatrics(6, 4, 2);
        }
        if (nNewCenter == 2)
        {
            CopyMatrics(0, 6, 0);
            CopyMatrics(2, 0, 0);
            CopyMatrics(6, 2, 0);
            CopyMatrics(1, 6, 0);
            CopyMatrics(3, 1, 0);
            CopyMatrics(6, 3, 0);
            CopyMatrics(5, 6, 0);
            CopyMatrics(6, 5, 3);
            CopyMatrics(4, 6, 0);
            CopyMatrics(6, 4, 3);
        }
        if (nNewCenter == 3)
        {
            CopyMatrics(0, 6, 0);
            CopyMatrics(3, 0, 0);
            CopyMatrics(2, 3, 0);
            CopyMatrics(1, 2, 0);
            CopyMatrics(6, 1, 0);
            CopyMatrics(5, 6, 0);
            CopyMatrics(6, 5, 2);
            CopyMatrics(4, 6, 0);
            CopyMatrics(6, 4, 1);
        }
        if (nNewCenter == 4)
        {
            CopyMatrics(0, 6, 0);
            CopyMatrics(4, 0, 0);
            CopyMatrics(2, 4, 3);
            CopyMatrics(5, 2, 3);
            CopyMatrics(6, 5, 0);
            CopyMatrics(3, 6, 0);
            CopyMatrics(6, 3, 2);
            CopyMatrics(1, 6, 0);
            CopyMatrics(6, 1, 1);
        }
        if (nNewCenter == 5)
        {
            CopyMatrics(0, 6, 0);
            CopyMatrics(5, 0, 0);
            CopyMatrics(2, 5, 3);
            CopyMatrics(4, 2, 3);
            CopyMatrics(6, 4, 0);
            CopyMatrics(3, 6, 0);
            CopyMatrics(6, 3, 1);
            CopyMatrics(1, 6, 0);
            CopyMatrics(6, 1, 2);
        }
    }

    public static void CopyMatrics(int A, int B, int n)
    {
        //Copy from A to B
        //n=0:DirectCopy  1:ClockWiseCopy  2:AntiClockCop  3:Reverse copy
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (n == 0) Sides[B, i, j] = Sides[A, i, j];
                if (n == 1) Sides[B, j, 2 - i] = Sides[A, i, j];
                if (n == 2) Sides[B, 2 - j, i] = Sides[A, i, j];
                if (n == 3) Sides[B, i, j] = Sides[A, 2 - i, 2 - j];
            }
        }
    }

    public static void ChangeViewFromTopByNextColor(int nColor)
    {
        int nNextColorCenter = -1;
        for (int i = 0; i < 6; i++)
        {
            if (Sides[i, 1, 1] == nColor) nNextColorCenter = i;
        }

        if (nNextColorCenter == 4) ChangeViewFromTop(false);
        if (nNextColorCenter == 5) ChangeViewFromTop(true);
        if (nNextColorCenter == 3)
        {
            ChangeViewFromTop(true);
            ChangeViewFromTop(true);
        }
    }

    public static void ChangeViewFromTop(bool ClockWise)
    {
        int Next1 = 3, Next2 = 1;
        if (!ClockWise) { Next1 = 1; Next2 = 3; }

        int nType = ClockWise ? 1 : 2;
        CopyMatrics(0, 6, 0);
        CopyMatrics(6, 0, nType);
        CopyMatrics(5, 6, 0);
        CopyMatrics(Next1, 5, nType);
        CopyMatrics(4, Next1, nType);
        CopyMatrics(Next2, 4, nType);
        CopyMatrics(6, Next2, nType);
        CopyMatrics(2, 6, 0);
        CopyMatrics(6, 2, 3 - nType);
    }

    public static void RotateBottomSide(bool ClockWise)
    {
        int temp = 0;
        int i;

        CopyMatrics(2, 6, ClockWise ? 2 : 1);
        CopyMatrics(6, 2, 0);
        if (ClockWise)
        {
            for (i = 0; i < 3; i++)
            {
                temp = Sides[5, 0, i];
                Sides[5, 0, i] = Sides[3, 2 - i, 0];
                Sides[3, 2 - i, 0] = Sides[4, 2, 2 - i];
                Sides[4, 2, 2 - i] = Sides[1, i, 2];
                Sides[1, i, 2] = temp;
            }
        }
        else
        {
            for (i = 0; i < 3; i++)
            {
                temp = Sides[5, 0, i];
                Sides[5, 0, i] = Sides[1, i, 2];
                Sides[1, i, 2] = Sides[4, 2, 2 - i];
                Sides[4, 2, 2 - i] = Sides[3, 2 - i, 0];
                Sides[3, 2 - i, 0] = temp;
            }
        }
    }

    public static void RotateRealSide(int nColor, bool ClockWise, int nQuarter)
    {
        int nCenter = -1;
        int[] arOpposite = { 2, 3, 0, 1, 5, 4 };
        for (int i = 0; i < 6; i++)
        {
            if (Position[i] == nColor) nCenter = i;
        }
        int nOppositeColor = Position[arOpposite[nCenter]];

        if (nCenter == 2)
        {
            //什么都不做
        }
        if (nCenter == 1)
        {
            RotatePaw();
        }
        if (nCenter == 0)
        {
            RotatePaw();
            RotatePaw();
        }
        if (nCenter == 3)
        {
            RotateBottom(false);
            RotateBottom(false);
            RotatePaw();
        }
        if (nCenter == 4)
        {
            RotateBottom(false);
            RotatePaw();
        }
        if (nCenter == 5)
        {
            RotateBottom(true);
            RotatePaw();
        }
        ChangeViewToColor(nOppositeColor);

        for (int i = 0; i < nQuarter; i++)
        {
            RotateBottomSide(!ClockWise);
        }
    }

    public static void RotateBottom(bool ClockWise)
    {
        if (ClockWise)
        {
            int n = Position[5];
            Position[5] = Position[3];
            Position[3] = Position[4];
            Position[4] = Position[1];
            Position[1] = n;
        }
        else
        {
            int n = Position[5];
            Position[5] = Position[1];
            Position[1] = Position[4];
            Position[4] = Position[3];
            Position[3] = n;
        }
    }

    public static void RotatePaw()
    {
        //只有前进
        int n = Position[0];
        Position[0] = Position[3];
        Position[3] = Position[2];
        Position[2] = Position[1];
        Position[1] = n;
    }

    public static int FindCenter(int nColor)
    {
        int nCenter = -1;
        for (int i = 0; i < 6; i++)
        {
            if (Sides[i, 1, 1] == nColor) nCenter = i;
        }
        return nCenter;
    }

    public static int FindCornerCell(int Color1, int Color2, int Color3)
    {
        int nReturn = 0;
        int nCheck = Color1 * 100 + Color2 * 10 + Color3;

        //第一层
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[0, 0, 2], Sides[5, 2, 2], Sides[1, 0, 0], 0, 5, 1);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[0, 0, 0], Sides[5, 2, 0], Sides[3, 0, 2], 0, 5, 3);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[0, 2, 0], Sides[4, 0, 0], Sides[3, 2, 2], 0, 4, 3);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[0, 2, 2], Sides[4, 0, 2], Sides[1, 2, 0], 0, 4, 1);
        if (nReturn > 0) return 1000 + nReturn;

        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[2, 0, 0], Sides[5, 0, 2], Sides[1, 0, 2], 2, 5, 1);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[2, 0, 2], Sides[5, 0, 0], Sides[3, 0, 0], 2, 5, 3);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[2, 2, 2], Sides[4, 2, 0], Sides[3, 2, 0], 2, 4, 3);
        if (nReturn == 0) nReturn = CheckCorner(nCheck, Sides[2, 2, 0], Sides[4, 2, 2], Sides[1, 2, 2], 2, 4, 1);
        if (nReturn > 0) return 2000 + nReturn;
        return 0;
    }

    public static int CheckCorner(int CheckValue, int c1, int c2, int c3, int p1, int p2, int p3)
    {
        if (c1 * 100 + c2 * 10 + c3 == CheckValue) return p1 * 100 + p2 * 10 + p3;
        if (c1 * 100 + c3 * 10 + c2 == CheckValue) return p1 * 100 + p3 * 10 + p2;
        if (c2 * 100 + c1 * 10 + c3 == CheckValue) return p2 * 100 + p1 * 10 + p3;
        if (c2 * 100 + c3 * 10 + c1 == CheckValue) return p2 * 100 + p3 * 10 + p1;
        if (c3 * 100 + c1 * 10 + c2 == CheckValue) return p3 * 100 + p1 * 10 + p2;
        if (c3 * 100 + c2 * 10 + c1 == CheckValue) return p3 * 100 + p2 * 10 + p1;
        return 0;
    }

    public static int FindBorderCell(int Color1, int Color2)
    {
        int nReturn = 0;
        int c1 = 0, c2 = 0;
        //第一层
        c1 = Sides[0, 0, 1]; c2 = Sides[5, 2, 1];
        if (c1 == Color1 && c2 == Color2) return 105;
        if (c1 == Color2 && c2 == Color1) return 150;
        c1 = Sides[0, 1, 0]; c2 = Sides[3, 1, 2];
        if (c1 == Color1 && c2 == Color2) return 103;
        if (c1 == Color2 && c2 == Color1) return 130;
        c1 = Sides[0, 2, 1]; c2 = Sides[4, 0, 1];
        if (c1 == Color1 && c2 == Color2) return 104;
        if (c1 == Color2 && c2 == Color1) return 140;
        c1 = Sides[0, 1, 2]; c2 = Sides[1, 1, 0];
        if (c1 == Color1 && c2 == Color2) return 101;
        if (c1 == Color2 && c2 == Color1) return 110;
        //第二层
        c1 = Sides[4, 1, 2]; c2 = Sides[1, 2, 1];
        if (c1 == Color1 && c2 == Color2) return 241;
        if (c1 == Color2 && c2 == Color1) return 214;
        c1 = Sides[4, 1, 0]; c2 = Sides[3, 2, 1];
        if (c1 == Color1 && c2 == Color2) return 243;
        if (c1 == Color2 && c2 == Color1) return 234;
        c1 = Sides[5, 1, 0]; c2 = Sides[3, 0, 1];
        if (c1 == Color1 && c2 == Color2) return 253;
        if (c1 == Color2 && c2 == Color1) return 235;
        c1 = Sides[5, 1, 2]; c2 = Sides[1, 0, 1];
        if (c1 == Color1 && c2 == Color2) return 251;
        if (c1 == Color2 && c2 == Color1) return 215;
        //第三层
        c1 = Sides[4, 2, 1]; c2 = Sides[2, 2, 1];
        if (c1 == Color1 && c2 == Color2) return 342;
        if (c1 == Color2 && c2 == Color1) return 324;
        c1 = Sides[1, 1, 2]; c2 = Sides[2, 1, 0];
        if (c1 == Color1 && c2 == Color2) return 312;
        if (c1 == Color2 && c2 == Color1) return 321;
        c1 = Sides[5, 0, 1]; c2 = Sides[2, 0, 1];
        if (c1 == Color1 && c2 == Color2) return 352;
        if (c1 == Color2 && c2 == Color1) return 325;
        c1 = Sides[3, 1, 0]; c2 = Sides[2, 1, 2];
        if (c1 == Color1 && c2 == Color2) return 332;
        if (c1 == Color2 && c2 == Color1) return 323;
        return 0;
    }
}

public static class Steps
{
    public static int Count = 0;
    public static int Index = -1;
    private static int[] arColor = new int[200];
    private static bool[] arClockWise = new bool[200];
    private static int[] arQuarter = new int[200];
    public static void Clear()
    {
        Count = 0;
        Index = -1;
    }
    public static void AddStep(int SideNum, bool ClockWise, int Quarter)
    {
        arColor[Count] = Rubik.Sides[SideNum, 1, 1];
        arClockWise[Count] = ClockWise;
        arQuarter[Count] = Quarter;
        Count++;
    }
    public static int Color()
    {
        return arColor[Index];
    }
    public static bool ClockWise()
    {
        return arClockWise[Index];
    }
    public static int Quarter()
    {
        return arQuarter[Index];
    }
}

public static class ColorT
{
    public static int Y = 1;
    public static int B = 2;
    public static int R = 3;
    public static int W = 4;
    public static int O = 5;
    public static int G = 6;




    public static string Text(int n)
    {
        switch (n)
        {
            case 1:
                return "Y";
            case 2:
                return "B";
            case 3:
                return "R";
            case 4:
                return "W";
            case 5:
                return "O";
            case 6:
                return "G";
            default:
                return n + "";
        }
    }
    public static int Value(string c)
    {
        if (c.Equals("Y") || c.Equals("y")) return 1;
        if (c.Equals("B") || c.Equals("b")) return 2;
        if (c.Equals("R") || c.Equals("r")) return 3;
        if (c.Equals("W") || c.Equals("w")) return 4;
        if (c.Equals("O") || c.Equals("o")) return 5;
        if (c.Equals("G") || c.Equals("g")) return 6;
        return 0;
    }
}

