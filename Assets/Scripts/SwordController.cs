using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    [SerializeField] private BoxColor swordColor;

    //LightSaber 보관대 > Socket Interactor
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
             
            //현재 들고있는 칼의 색과 박스의 색이 같을 때에만 유효 타격
            if (swordColor == other.gameObject.GetComponent<Box>().curBoxColor)
            {
                //타격 위치를 받아와서 비교 

                

                ScoreUpdate();
                //other.gameObject.GetComponent<Box>().DestroyBox();

            }
            else
            {
                //점수 - 10
            }
             
        }
    }

   


    public void ScoreUpdate()
    {
        GameManager.Instance.Score += 10;
        UIManager.Instance.OnScoreUI?.Invoke();
    }
    



}
