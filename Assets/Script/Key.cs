using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{

    public enum KeyType
    {
        Char,
        Number,
        Other
    }

    public KeyType type;
    private TextMeshProUGUI _text;
    private char _c;
    public char getLowerChar()
    {
        return char.ToLower(_c);
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        if (type != KeyType.Other)
            _c = _text.text[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (type != KeyType.Other)
            _text.text = ""+_c;
    }

    public void setCap(bool b)
    {
        if (type == KeyType.Char)
        {
            if (b == true)
            {
                _c = char.ToUpper(_c);
            }
            else
            {
                _c = char.ToLower(_c);
            }
        }
    }

    public override bool Equals(object other)
    {
        return this._c.Equals(((Key)other).getLowerChar());
    }

}
