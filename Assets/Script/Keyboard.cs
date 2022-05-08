using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keyboard : MonoBehaviour
{

    private bool isCaps = false;
    private Matrix<Key> keys;

    public List<RowOfKeys> keyboard_rows;

    [Serializable]
    public class RowOfKeys
    {
        public List<Key> keyboard_columns;
        public List<Key> getKeys()
        {
            return keyboard_columns;
        }
        public int Count()
        {
            return keyboard_columns.Count;
        }
        public void resizeWithNull(int size)
        {
            if (size > Count())
            {
                int toAdd = Count() - size;
                for (int i = 0; i < toAdd; i++)
                    keyboard_columns.Add(null);
            }
        }
    }

    private void Start()
    {
        int max_count = -1;
        foreach (RowOfKeys rok in keyboard_rows)
            if (max_count < rok.Count())
                max_count = rok.Count();
        foreach (RowOfKeys rok in keyboard_rows)
            rok.resizeWithNull(max_count);
        LoadMatrix(keyboard_rows.Count, max_count);
    }

    private void Update()
    {
        if (StringBuffer.CONSOLE_ON) StringBuffer.getString();
    }

    private void LoadMatrix(int rmax, int cmax)
    {
        keys = new Matrix<Key>(rmax, cmax);
        int rowCounter = 0;
        foreach (RowOfKeys rok in keyboard_rows)
        {
            foreach (Key k in rok.getKeys())
                keys.AddIn(k, rowCounter);
            rowCounter++;
        }
        keys.Debug_View();
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
        /*foreach (Key k in ???)
        {
            k.setCap(isCaps);
        }*/
    }

    #endregion

}
