using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private ParticleSystem par;
    [SerializeField] private GameObject ob;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueSword")
        {

            Vector3 point = other.ClosestPoint(transform.position);

            Vector3 hitNormal = transform.position - point;

            Debug.Log(hitNormal);


            //Vector3 swordCollider = other.GetComponent<Collider>().bounds.center;
            //Vector3 boxCollider = this.GetComponent<Collider>().bounds.center;

            //Vector3 hitDir = (boxCollider - swordCollider).normalized;

           

            //Vector3 hitEffect = boxCollider - hitDir *  1f;

            //Vector3 tt = other.GetComponent<Collider>().ClosestPoint(swordCollider);
            //Debug.Log(tt);

            //Instantiate(ob, hitEffect, Quaternion.identity);

            
            //ParticleSystem par = Instantiate(this.par, hitEffect, transform.rotation);
            //par.Play(); 

             
        }
        //Į ���� ������ �ڽ� �簢�� �ȿ��� ��� ��ġ�� �ִ��� ������� �ʿ䰡 �մ�
        //    xy ��ġ ����


    }


    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("�浹��");
    }

}
