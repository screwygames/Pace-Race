using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    //TODO: Refactor this as an array (unless zero indexing is a problem but even so)
    private static int p1Car = 0;
    private static int p2Car = 0;
    private static int p3Car = 0;
    private static int p4Car = 0;
    private static int nLaps = 3;
    private static int place = 1;
    private static string[][] inputs = new string[4][];


    public static void setCars(int p1, int p2, int p3, int p4)
    {
        Debug.Log("" + p1 + "" + p2.ToString() + "" + p3.ToString() + "" + p4.ToString());
        p1Car = p1;
        p2Car = p2;
        p3Car = p3;
        p4Car = p4;
    }

    public static int getCar(int pnum)
    {
        switch (pnum)
        {
            case 1:
                return p1Car;
            case 2:
                return p2Car;
            case 3:
                return p3Car;
            case 4:
                return p4Car;
            default:
                return p1Car;
        }
    }

    public static int getPlace()
    {
        return place++;
    }

    public static void setLaps(int laps)
    {
        nLaps = laps;
    }

    public static int getLaps()
    {
        return nLaps;
    }

    public static void setControls(int pNum, string xAxis, string triggerAxis)
    {
        inputs[pNum - 1] = new string[] { xAxis, triggerAxis };
    }

    public static void setControls(int pNum, string[] controls)
    {
        inputs[pNum - 1] = controls;
    }

    public static string[] getControls(int pNum)
    {
        return inputs[pNum - 1];
    }
}