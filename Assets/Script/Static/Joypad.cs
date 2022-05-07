using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joypad : MonoBehaviour
{

    private void Update()
    {
        waitingControl();
        if (Joypad.CONSOLE_ON) Test();
    }

    public static bool CONSOLE_ON = true;
    private static int _SET_WAITING_PRESSION_TIME = 5;
    private static int _WAITING_PRESSION_TIME = 0;

    #region GAMEPAD COMMANDS

    public static bool OnButtonPressed_A()
    {
        if (Hinput.anyGamepad.A.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;                                                                                                                   
    }
    public static bool OnButtonPressed_B()
    {
        if (Hinput.anyGamepad.B.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_X()
    {
        if (Hinput.anyGamepad.X.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_Y()
    {
        if (Hinput.anyGamepad.Y.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_RB()
    {
        return Hinput.anyGamepad.rightBumper.pressed;
    }
    public static bool OnButtonPressed_LB()
    {
        return Hinput.anyGamepad.leftBumper.pressed;
    }
    public static bool OnButtonPressed_RT()
    {
        return Hinput.anyGamepad.rightTrigger.pressed;
    }
    public static bool OnButtonPressed_LT()
    {
        return Hinput.anyGamepad.leftTrigger.pressed;
    }
    public static bool OnButtonPressed_RightArrow()
    {
        if (Hinput.anyGamepad.dPad.right.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_LeftArrow()
    {
        if (Hinput.anyGamepad.dPad.left.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_UpArrow()
    {
        if (Hinput.anyGamepad.dPad.up.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_DownArrow()
    {
        if (Hinput.anyGamepad.dPad.down.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }

    public static void Vibrate()
    {
        Hinput.anyGamepad.Vibrate();
    }

    #endregion

    private static bool canPress()
    {
        if (_WAITING_PRESSION_TIME == 0) return true;
        return false;
    }

    private static void setPression()
    {
        _WAITING_PRESSION_TIME = _SET_WAITING_PRESSION_TIME;
    }

    private void waitingControl()
    {
        if (_WAITING_PRESSION_TIME > 0) _WAITING_PRESSION_TIME -= 1;
        if (_WAITING_PRESSION_TIME < 0) _WAITING_PRESSION_TIME = 0;
    }

    public void Test()
    {
        if (!Hinput.anyGamepad.isConnected) Debug.LogWarning("Gamepad is not connected!");
        if (OnButtonPressed_A()) Debug.Log("Pressed A");
        if (OnButtonPressed_B()) Debug.Log("Pressed B");
        if (OnButtonPressed_X()) Debug.Log("Pressed X");
        if (OnButtonPressed_Y()) Debug.Log("Pressed Y");
        if (OnButtonPressed_RB()) Debug.Log("Pressed RB");
        if (OnButtonPressed_LB()) Debug.Log("Pressed LB");
        if (OnButtonPressed_RT()) Debug.Log("Pressed RT");
        if (OnButtonPressed_LT()) Debug.Log("Pressed LT");
        if (OnButtonPressed_UpArrow()) Debug.Log("Pressed Up");
        if (OnButtonPressed_DownArrow()) Debug.Log("Pressed Down");
        if (OnButtonPressed_RightArrow()) Debug.Log("Pressed Right");
        if (OnButtonPressed_LeftArrow()) Debug.Log("Pressed Left");
    }

}
