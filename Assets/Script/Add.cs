using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : Calculator
{
    public override void Calculate() // ����Լ�
    {
        if (ButtonClick.Instance.isSign == true)
        {
            ButtonClick.Instance.number = null;

            if (!string.IsNullOrEmpty(ButtonClick.Instance.answer.text))// �Ŀ� +�� ���ԵǾ��ִ��� üũ (+���ԵǾ��������)
            {
                string[] split = ButtonClick.Instance.form.text.Split("+"); // +�������� �յڷ� �߶� split �迭 ������ ����

                pre = float.Parse(split[0]);    // +�պκ�
                after = float.Parse(ButtonClick.Instance.answer.text);  // + �޺κ�

                ButtonClick.Instance.form.text = string.Empty;  // ���� ����ִ� �������� �ʱ�ȭ
                ButtonClick.Instance.answer.text = string.Empty;

                var value = pre + after;// + ����� value�� ����
                pre = value;
                after = 0;

                ButtonClick.Instance.form.text += pre;  // �Ŀ� ����� �����ֱ�
                ButtonClick.Instance.answer.text = string.Empty;
                ButtonClick.Instance.form.text += "+";
            }
         
            base.Calculate();

            ButtonClick.Instance.isSign = false;
        }
    }


}
