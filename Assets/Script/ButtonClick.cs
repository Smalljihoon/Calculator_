using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private static ButtonClick instance;    // �̱���
    public static ButtonClick Instance
    {
        get { return instance; }
    }

    public Button[] buttons; //���� ��ư
    public TMP_Text form;   // ��
    public TMP_Text answer; // ��

    public Calculator[] calculators = new Calculator[5];

    public string number = string.Empty; // Ŭ������ �޴� �Ű����� ��� ��
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

    public void CalculateCheck()    // ������ ��ư Ŭ���� �Ŀ� �����ڰ� �ִ��� üũ�ϰ� ������ ������ִ� �Լ� -> �� ������ ���� �Ǵ� �� ���
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

    public void CalculateChange(string calculator)    // �����ڸ� �־��ִ� �Լ� -> �� �����ڰ� ������ �־��ְ� ������ �������� ���� �����ڷ� ��ü
    {
        if (!string.IsNullOrEmpty(currentcalculator) && currentcalculator != calculator)    //  ���� �Ŀ� �����ڰ� �ְ� �� �����ڰ� ���� Ŭ���� �����ڿ� �ٸ� �� 
        {
            string temp = form.text;

            form.text = temp.Replace(currentcalculator, calculator);        // �Ŀ� �ִ� ���� �����ڸ� �������� Ŭ���� �����ڷ� ��ü
            currentcalculator = calculator;         // 
        }
        else if(string.IsNullOrEmpty(currentcalculator))    // ���� �Ŀ� �����ڰ� ���� ��
        {
            currentcalculator = calculator;     // Ŭ���� �����ڸ� �Ŀ� �־��ֱ� 

            form.text = answer.text;                // answer�� �ִ� ���� �Ŀ� �־��ְ�
            form.text += calculator;                // ������ �־��ְ�
            answer.text = string.Empty;         // answer �ʱ�ȭ
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
