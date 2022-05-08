using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keyboard : MonoBehaviour
{

    private class Vector2Int
    {
        public int x;
        public int y;
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void load(Vector2Int v)
        {
            this.x = v.x;
            this.y = v.y;
        }
    }

    private Vector2Int pointer;
    private bool isCaps = false;
    private Matrix<Key> keys;
    private Key pointedKey = null;

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
        pointer = new Vector2Int(0, 0);
    }

    private void Update()
    {
        if (StringBuffer.CONSOLE_ON) StringBuffer.getString();
        pointedKey = keys.Get(pointer.y, pointer.x);
        List<Key> all = keys.GetAll();
        foreach(Key k in all)
        {
            if (k != null)
            {
                if (!k.Equals(pointedKey))
                    k.setHighlight(false);
                else k.setHighlight(true);
            }
        }

        #region Joypad movement

        if (Joypad.OnButtonPressed_RightArrow() && pointer.x < keys.Columns()-1)
        {
            Vector2Int tempPointer = new Vector2Int(0, 0);
            tempPointer.load(pointer);
            tempPointer.x++;
            Key toCheck = keys.Get(tempPointer.y, tempPointer.x);
            if (toCheck != null)
                pointer.load(tempPointer);
        } else if (Joypad.OnButtonPressed_LeftArrow() && pointer.x > 0)
        {
            Vector2Int tempPointer = new Vector2Int(0, 0);
            tempPointer.load(pointer);
            tempPointer.x--;
            Key toCheck = keys.Get(tempPointer.y, tempPointer.x);
            if (toCheck != null)
                pointer.load(tempPointer);
        } else if (Joypad.OnButtonPressed_UpArrow() && pointer.y > 0)
        {
            Vector2Int tempPointer = new Vector2Int(0, 0);
            tempPointer.load(pointer);
            tempPointer.y--;
            Key toCheck = keys.Get(tempPointer.y, tempPointer.x);
            if (toCheck != null)
                pointer.load(tempPointer);
        } else if (Joypad.OnButtonPressed_DownArrow() && pointer.y < keys.Rows()-1)
        {
            Vector2Int tempPointer = new Vector2Int(0, 0);
            tempPointer.load(pointer);
            tempPointer.y++;
            Key toCheck = keys.Get(tempPointer.y, tempPointer.x);
            if (toCheck != null)
                pointer.load(tempPointer);
        }

        #endregion

        #region Joypad selection

        if (Joypad.OnButtonPressed_A())
        {
            onCharPressed_ID(pointedKey.getID());
        }

        #endregion

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

    private void onCharPressed_ID(string ID)
    {
        switch (ID)
        {
            // Add letters here
            case "Q":
                onCharPressed_Q();
                break;
            case "W":
                onCharPressed_W();
                break;
            case "E":
                onCharPressed_E();
                break;
            case "A":
                onCharPressed_A();
                break;
            case "S":
                onCharPressed_S();
                break;
            // Add numbers here
            case "1":
                onCharPressed_1();
                break;
            // Add special characters here

        }
    }

    #region NUMBERS

    public void onCharPressed_1()
    {
        StringBuffer.addChar('1');
    }

    // Create every number here

    #endregion

    #region LETTERS

    public void onCharPressed_Q()
    {
        Tuple<char, char> ch = new Tuple<char, char>('q', 'Q');
        if (!isCaps) StringBuffer.addChar(ch.Item1);
        else StringBuffer.addChar(ch.Item2);
    }
    public void onCharPressed_W()
    {
        Tuple<char, char> ch = new Tuple<char, char>('w', 'W');
        if (!isCaps) StringBuffer.addChar(ch.Item1);
        else StringBuffer.addChar(ch.Item2);
    }
    public void onCharPressed_E()
    {
        Tuple<char, char> ch = new Tuple<char, char>('e', 'E');
        if (!isCaps) StringBuffer.addChar(ch.Item1);
        else StringBuffer.addChar(ch.Item2);
    }
    public void onCharPressed_A()
    {
        Tuple<char, char> ch = new Tuple<char, char>('a', 'A');
        if (!isCaps) StringBuffer.addChar(ch.Item1);
        else StringBuffer.addChar(ch.Item2);
    }
    public void onCharPressed_S()
    {
        Tuple<char, char> ch = new Tuple<char, char>('s', 'S');
        if (!isCaps) StringBuffer.addChar(ch.Item1);
        else StringBuffer.addChar(ch.Item2);
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
        foreach (Key k in keys.GetAll())
        {
            if (k != null)
                k.setCap(isCaps);
        }
    }

    #endregion

}
