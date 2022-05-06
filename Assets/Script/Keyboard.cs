using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keyboard : MonoBehaviour
{

    private bool isCaps = false;
    public List<Key> listOfKeys;

    private void Update()
    {
        if (StringBuffer.CONSOLE_ON) StringBuffer.getString();
    }

    private void pressedCharacter(char c)
    {
        StringBuffer.addChar(c);
    }

    #region NUMBERS

    public void onCharPressed_1()
    {
        pressedCharacter('1');
    }

    // Create every number here

    #endregion

    #region LETTERS

    public void onCharPressed_Q()
    {
        Tuple<char, char> ch = new Tuple<char, char>('q', 'Q');
        if (!isCaps) pressedCharacter(ch.Item1);
        else pressedCharacter(ch.Item2);
    }

    // Create every character here

    #endregion

    #region COMMANDS
    
    public void onBackspacePressed()
    {
        StringBuffer.removeChar();
    }

    public void onCursorLeftPressed()
    {
        StringBuffer.moveCursorToLeft();
    }
    
    public void onCursorRightPressed()
    {
        StringBuffer.moveCursorToRight();
    }

    public void onCapsPressed()
    {
        if (isCaps) isCaps = false;
        else isCaps = true;
        foreach (Key k in listOfKeys)
        {
            k.setCap(isCaps);
        }
    }

    #endregion

}
