using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : Calculator
{
    public override void Calculate() // 계산함수
    {
        if (ButtonClick.Instance.isSign == true)
        {
            ButtonClick.Instance.number = null;

            if (!string.IsNullOrEmpty(ButtonClick.Instance.answer.text))// 식에 +가 포함되어있는지 체크 (+포함되어있을경우)
            {
                string[] split = ButtonClick.Instance.form.text.Split("+"); // +기준으로 앞뒤로 잘라서 split 배열 변수로 지정

                pre = float.Parse(split[0]);    // +앞부분
                after = float.Parse(ButtonClick.Instance.answer.text);  // + 뒷부분

                ButtonClick.Instance.form.text = string.Empty;  // 식을 비어있는 공간으로 초기화
                ButtonClick.Instance.answer.text = string.Empty;

                var value = pre + after;// + 결과값 value에 저장
                pre = value;
                after = 0;

                ButtonClick.Instance.form.text += pre;  // 식에 결과값 더해주기
                ButtonClick.Instance.answer.text = string.Empty;
                ButtonClick.Instance.form.text += "+";
            }
         
            base.Calculate();

            ButtonClick.Instance.isSign = false;
        }
    }


}
