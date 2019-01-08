using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public static class GameVariables
{ 
    public static bool gotKey = false;
    public static bool buttonPressed = false ;
    public static bool gotPin = false;
    public static int gotCoin = 0;
    public static bool[] correctLeverState = new bool[4];
    public static bool leversMoving = false;
    public static bool sacksInRow = false;

    public static void resetVariables()
    {
        gotKey = false;
        buttonPressed = false;
        gotPin = false;
        gotCoin = 0;
        for (int i = 0; i < correctLeverState.Length; ++i) {
            correctLeverState[i] = false;
        }
        leversMoving = false;
        sacksInRow = false;
    }

}