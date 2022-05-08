using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public enum KeyType
    {
        Char,
        Number,
        Other
    }

    public string ID;
    public KeyType type;
    private TextMeshProUGUI _text;
    private char _c;
    private bool highlighted = false;
    private Image img;

    public string getID()
    {
        if (ID == "")
            return _text.text.ToUpper();
        else return ID.ToUpper();
    }

    public char getLowerChar()
    {
        return char.ToLower(_c);
    }

    public void setHighlight(bool highlight)
    {
        this.highlighted = highlight;
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = this.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        if (type != KeyType.Other)
            _c = _text.text[0];
        img = this.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type != KeyType.Other)
            _text.text = ""+_c;
        if (highlighted) img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        else img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
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

    public static bool operator !=(Key k1, Key k2)
    {
        if (k1 is null)
        {
            return k2 is not null;
        }
        if (k2 is null)
        {
            return k1 is not null;
        }

        return !k1.Equals(k2);
    }


    public static bool operator ==(Key k1, Key k2)
    {
        if (k1 is null)
        {
            return k2 is null;
        }
        if (k2 is null)
        {
            return k1 is null;
        }

        return k1.Equals(k2);
    }

    public override bool Equals(object other)
    {
        return this._text.text.ToLower().Equals(((Key)other)._text.text.ToLower());
    }

    public override string ToString()
    {
        return "{ Key " + this._text.text + " }";
    }

}
