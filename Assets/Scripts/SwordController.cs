using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{


    private Vector3 blueSwordPos = new Vector3(-1.7f, 0.3f, -1.3f);
    private Vector3 redSwordPos = new Vector3(-1.7f,0.3f,-0.8f);
    



    

    public void DropSword()
    {
        Debug.Log("�����");
    }

    public void TEst()
    {
        Debug.Log("��ħ");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            //Box�� ������ �����ͼ� ���� ����� ��ġ�ϸ� ���� ����, ���� �߰�
            //
        }

    }


}
