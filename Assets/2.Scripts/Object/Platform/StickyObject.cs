using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyObject : MonoBehaviour
{
    [SerializeField] private float collisionDrag;
    [SerializeField] private PhysicMaterial stickyMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Collider>().material = stickyMaterial;
        }
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

    //    rb.drag = collisionDrag;
    //}

    private void OnCollisionExit(Collision collision)
    {
        //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        //rb.drag = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Collider>().material = null;
        }
    }
}
