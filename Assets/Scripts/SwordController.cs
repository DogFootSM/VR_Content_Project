using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    [SerializeField] private BoxColor swordColor;
    [SerializeField] private Transform test;

    //LightSaber ������ > Socket Interactor
    private Vector3 blueSwordPos = new Vector3(-1.7f, 0.3f, -1.3f);
    private Vector3 redSwordPos = new Vector3(-1.7f, 0.3f, -0.8f);

     
    private void OnTriggerEnter(Collider other)
    {
        BoxDir boxDir;

        if (other.gameObject.tag == "Box")
        {

            //���� ����ִ� Į�� ���� �ڽ��� ���� ���� ������ ��ȿ Ÿ��
            if (swordColor == other.gameObject.GetComponent<Box>().curBoxColor)
            {
                //���� �ڽ��� Ÿ�� ��ġ
                boxDir = other.GetComponent<Box>().BoxDir;

                //Ÿ�� ��ġ�� �޾ƿͼ� ��  
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
