using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringBuffer
{

    public static List<char> _buffer = new List<char>();
    public static int _bufferindex;
    private static string _POINTER_CHAR = "?";
    public static bool CONSOLE_ON = true;

    public static void addChar(char c)
    {
        _buffer.Insert(_bufferindex, c);
        _bufferindex++;
    }

    public static void removeChar()
    {
        if (_buffer.Count <= 0 || _bufferindex-1 < 0) return;
        _buffer.RemoveAt(_bufferindex-1);
        _bufferindex--;
    }

    public static void moveCursorToLeft()
    {
        if (_bufferindex > 0)
            _bufferindex--;
    }

    public static void moveCursorToRight()
    {
        if (_bufferindex < _buffer.Count)
            _bufferindex++;
    }

    public static string getString()
    {
        string toReturn;
        if (_buffer.Count == 0)
        {
            toReturn = _POINTER_CHAR;
        }
        else
        {
            string _temp_buffer = new string(_buffer.ToArray());
            toReturn = _temp_buffer.Insert(_bufferindex, _POINTER_CHAR);
        }
        if (CONSOLE_ON) Debug.Log("Pointer at " + _bufferindex + " > " + toReturn);
        return toReturn;
    }

}
