using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;
    public GameObject target;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = null;
    }

    private void FixedUpdate()
    {
        if(target != null)
            rb.MovePosition(transform.position + 
                (target.transform.position - transform.position) * Time.deltaTime * speed);
    }
    public void StartMotion(GameObject target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        target = null;
    }
}
