using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{


    private Vector3 blueSwordPos = new Vector3(-1.7f, 0.3f, -1.3f);
    private Vector3 redSwordPos = new Vector3(-1.7f,0.3f,-0.8f);
    



    

    public void DropSword()
    {
        Debug.Log("잡았음");
    }

    public void TEst()
    {
        Debug.Log("놓침");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            //Box의 방향을 가져와서 때린 방향과 일치하면 상자 삭제, 점수 추가
            //
        }

    }


}
