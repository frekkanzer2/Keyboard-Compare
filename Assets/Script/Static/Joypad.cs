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
    public static bool OnButtonPressed_Start()
    {
        if (Hinput.anyGamepad.start.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnButtonPressed_Select()
    {
        if (Hinput.anyGamepad.back.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnRightStickPressed()
    {
        if (Hinput.anyGamepad.rightStickClick.justPressed)
        {
            if (!canPress()) return false;
            setPression();
            return true;
        }
        return false;
    }
    public static bool OnLeftStickPressed()
    {
        if (Hinput.anyGamepad.leftStickClick.justPressed)
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

    public static bool OnLeftStickMoved_Up()
    {
        return (Hinput.anyGamepad.leftStick.angle > 45f && Hinput.anyGamepad.leftStick.angle <= 135f);
    }
    public static bool OnLeftStickMoved_Down()
    {
        return (Hinput.anyGamepad.leftStick.angle <= -45f && Hinput.anyGamepad.leftStick.angle > -135f);
    }
    public static bool OnLeftStickMoved_Right()
    {
        return (Hinput.anyGamepad.leftStick.angle > -45f && Hinput.anyGamepad.leftStick.angle <= 45f && Hinput.anyGamepad.leftStick.angle != 0);
    }
    public static bool OnLeftStickMoved_Left()
    {
        return (
            (Hinput.anyGamepad.leftStick.angle > 135f && Hinput.anyGamepad.leftStick.angle <= 180f) || 
            (Hinput.anyGamepad.leftStick.angle <= -135f && Hinput.anyGamepad.leftStick.angle >= -180f)
        );
    }
    public static bool OnRightStickMoved_Up()
    {
        return (Hinput.anyGamepad.rightStick.angle > 45f && Hinput.anyGamepad.rightStick.angle <= 135f);
    }
    public static bool OnRightStickMoved_Down()
    {
        return (Hinput.anyGamepad.rightStick.angle <= -45f && Hinput.anyGamepad.rightStick.angle > -135f);
    }
    public static bool OnRightStickMoved_Right()
    {
        return (Hinput.anyGamepad.rightStick.angle > -45f && Hinput.anyGamepad.rightStick.angle <= 45f && Hinput.anyGamepad.rightStick.angle != 0);
    }
    public static bool OnRightStickMoved_Left()
    {
        return (
            (Hinput.anyGamepad.rightStick.angle > 135f && Hinput.anyGamepad.rightStick.angle <= 180f) ||
            (Hinput.anyGamepad.rightStick.angle <= -135f && Hinput.anyGamepad.rightStick.angle >= -180f)
        );
    }
    public enum Arrow
    {
        Up, Down, Left, Right, Center
    }
    public static Arrow OnLeftStickMoved()
    {
        if (OnLeftStickMoved_Up()) return Arrow.Up;
        if (OnLeftStickMoved_Down()) return Arrow.Down;
        if (OnLeftStickMoved_Left()) return Arrow.Left;
        if (OnLeftStickMoved_Right()) return Arrow.Right;
        return Arrow.Center;
    }
    public static Arrow OnRightStickMoved()
    {
        if (OnRightStickMoved_Up()) return Arrow.Up;
        if (OnRightStickMoved_Down()) return Arrow.Down;
        if (OnRightStickMoved_Left()) return Arrow.Left;
        if (OnRightStickMoved_Right()) return Arrow.Right;
        return Arrow.Center;
    }

    public static void Vibrate()
    {
        Hinput.anyGamepad.Vibrate();
    }

    #endregion

    #region Internal commands, do not touch them

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
        Arrow a = OnLeftStickMoved();
        if (a != Arrow.Center) Debug.Log("Left stick movement at " + a);
        a = OnRightStickMoved();
        if (a != Arrow.Center) Debug.Log("Right stick movement at " + a);
    }

    #endregion

}
