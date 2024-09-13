using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : Calculator
{
    public override void Calculate()
    {
        if (ButtonClick.Instance.isSign == true)
        {
            ButtonClick.Instance.number = null;

            if (!string.IsNullOrEmpty(ButtonClick.Instance.answer.text))
            {
                string[] split = ButtonClick.Instance.form.text.Split("/");

                pre = float.Parse(split[0]);
                after = float.Parse(ButtonClick.Instance.answer.text);
                float value = pre / after;
                pre = value;
                after = 0;

                ButtonClick.Instance.form.text = string.Empty;
                ButtonClick.Instance.form.text += pre;

                ButtonClick.Instance.answer.text = string.Empty;
                ButtonClick.Instance.form.text += "/";
            }
  
            base.Calculate();

            ButtonClick.Instance.isSign = false;
        }
    }
}

