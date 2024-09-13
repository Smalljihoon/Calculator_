using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
     public float pre;
     public float after;
    
    public virtual void Calculate()
    {
        if (ButtonClick.Instance.form.text.Contains("="))
        {
            ButtonClick.Instance.form.text = string.Empty;
            ButtonClick.Instance.form.text += ButtonClick.Instance.answer.text;
            ButtonClick.Instance.answer.text = string.Empty;
        }
    }

}


