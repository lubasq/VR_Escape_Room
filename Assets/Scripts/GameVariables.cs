﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{ 
    public static bool gotKey = false;
    public static bool buttonPressed = false ;
    public static bool gotPin = false;
    public static int gotCoin = 0;
    public static bool[] correctLeverState = new bool[4];

    public static void resetVariables()
    {
        gotKey = false;
        buttonPressed = false;
        gotPin = false;
        gotCoin = 0;
        for (int i = 0; i < correctLeverState.Length; ++i) {
            correctLeverState[i] = false;
        }
    }

}