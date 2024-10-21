using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    [SerializeField] private BoxColor swordColor;
    [SerializeField] private Transform test;

    //LightSaber 보관대 > Socket Interactor
    private Vector3 blueSwordPos = new Vector3(-1.7f, 0.3f, -1.3f);
    private Vector3 redSwordPos = new Vector3(-1.7f, 0.3f, -0.8f);

     
    private void OnTriggerEnter(Collider other)
    {
        BoxDir boxDir;

        if (other.gameObject.tag == "Box")
        {

            //현재 들고있는 칼의 색과 박스의 색이 같을 때에만 유효 타격
            if (swordColor == other.gameObject.GetComponent<Box>().curBoxColor)
            {
                //현재 박스의 타격 위치
                boxDir = other.GetComponent<Box>().BoxDir;

                //타격 위치를 받아와서 비교  
                Vector3 hitPoint = transform.position - other.transform.position;

                if (hitPoint.y > hitPoint.x)
                {
                    if (hitPoint.y > -hitPoint.x)
                    {
                        if (boxDir == BoxDir.Up)
                        {
                            other.gameObject.GetComponent<Box>().DestroyBox(hitPoint);
                            ScorePlusUpdate();
                        }
                        else
                        {
                            ScoreMinusUpdate();
                        }
                    }
                    else
                    {
                        if (boxDir == BoxDir.Left)
                        {
                            other.gameObject.GetComponent<Box>().DestroyBox(hitPoint);
                            ScorePlusUpdate();
                        }
                        else
                        {
                            ScoreMinusUpdate();
                        }
                    }
                }
                else
                {
                    if (hitPoint.y > -hitPoint.x)
                    {
                        if (boxDir == BoxDir.Right)
                        {
                            other.gameObject.GetComponent<Box>().DestroyBox(hitPoint);
                            ScorePlusUpdate();
                        }
                        else
                        {
                            ScoreMinusUpdate();
                        }
                    }
                    else
                    {
                        if (boxDir == BoxDir.Down)
                        {
                            other.gameObject.GetComponent<Box>().DestroyBox(hitPoint);
                            ScorePlusUpdate();
                        }
                        else
                        {
                            ScoreMinusUpdate();
                        }
                    }
                } 
            }
            else
            { 
                ScoreMinusUpdate();
            }

        }
    }


    public void ScoreMinusUpdate()
    {
        GameManager.Instance.Score -= 10;
        UIManager.Instance.OnScoreUI?.Invoke();
    }

    public void ScorePlusUpdate()
    {
        GameManager.Instance.Score += 10;
        UIManager.Instance.OnScoreUI?.Invoke();
    }




}
