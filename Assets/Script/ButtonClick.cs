using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private static ButtonClick instance;    // 싱글톤
    public static ButtonClick Instance
    {
        get { return instance; }
    }

    public Button[] buttons; //숫자 버튼
    public TMP_Text form;   // 식
    public TMP_Text answer; // 답

    public Calculator[] calculators = new Calculator[5];

    public string number = string.Empty; // 클릭으로 받는 매개변수 담는 곳
    public bool isSign = false;

    private string currentcalculator = string.Empty;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        buttons = new Button[] { };
        form.text = string.Empty;
        answer.text = string.Empty;
    }

    public void Equals()
    {
        form.text += answer.text;

        if (form.text.Contains("+"))
        {
            string[] split = form.text.Split('+');
            var front = float.Parse(split[0]);
            var back = float.Parse(split[1]);
            float result = front + back;
            form.text += "=";
            answer.text = string.Empty;
            answer.text = result.ToString();
        }
       else  if (form.text.Contains("-"))
        {
            string[] split = form.text.Split('-');
            var front = float.Parse(split[0]);
            var back = float.Parse(split[1]);
            float result = front - back;
            form.text += "=";
            answer.text = string.Empty;
            answer.text = result.ToString();
        }
        else if (form.text.Contains("x"))
        {
            string[] split = form.text.Split('x');
            var front = float.Parse(split[0]);
            var back = float.Parse(split[1]);
            float result = front * back;
            form.text += "=";
            answer.text = string.Empty;
            answer.text = result.ToString();
        }
        else if (form.text.Contains("/"))
        {
            string[] split = form.text.Split('/');
            var front = float.Parse(split[0]);
            var back = float.Parse(split[1]);
            float result = front / back;
            form.text += "=";
            answer.text = string.Empty;
            answer.text = result.ToString();
        }
    }

    public void CalculateCheck()    // 연산자 버튼 클릭시 식에 연산자가 있는지 체크하고 있으면 계산해주는 함수 -> 즉 연산자 유무 판단 후 계산
    {
        if (form.text.Contains("+"))
        {
            calculators[0].Calculate();
        }
        else if (form.text.Contains("-"))
        {
            calculators[1].Calculate();
        }
        else if (form.text.Contains("x"))
        {
            calculators[2].Calculate();
        }
        else if (form.text.Contains("/"))
        {
            calculators[3].Calculate();
        }
    }

    public void CalculateChange(string calculator)    // 연산자를 넣어주는 함수 -> 즉 연산자가 없으면 넣어주고 있으면 마지막에 누른 연산자로 교체
    {
        if (!string.IsNullOrEmpty(currentcalculator) && currentcalculator != calculator)    //  기존 식에 연산자가 있고 그 연산자가 지금 클릭한 연산자와 다를 때 
        {
            string temp = form.text;

            form.text = temp.Replace(currentcalculator, calculator);        // 식에 있는 기존 연산자를 마지막에 클릭한 연산자로 교체
            currentcalculator = calculator;         // 
        }
        else if(string.IsNullOrEmpty(currentcalculator))    // 기존 식에 연산자가 없을 때
        {
            currentcalculator = calculator;     // 클릭한 연산자를 식에 넣어주기 

            form.text = answer.text;                // answer에 있는 값을 식에 넣어주고
            form.text += calculator;                // 연산자 넣어주고
            answer.text = string.Empty;         // answer 초기화
        }
    }

    public void NumButtonClick(string a)
    {
        if (form.text.Contains("="))
        {
            Cansel();
        }

        number += a;
        answer.text = number;
        isSign = true;
    }

    public void Cansel()
    {
        currentcalculator = string.Empty;
        number = string.Empty;
        form.text = string.Empty;
        answer.text = string.Empty;
        isSign = false;
    }
}
