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

            Vector2 hitNormal = (transform.position - point).normalized;

            Debug.Log(hitNormal);



            //ParticleSystem par = Instantiate(this.par, hitEffect, transform.rotation);
            //par.Play(); 

             
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint pt = collision.contacts[0];

        Vector3 hit = pt.point;

        Debug.Log(hit);


    }

}
