using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody == null)
        { return; }
        collision.rigidbody.velocity = Vector3.zero;
        SetStumpState(true);
    }

    public void SetStumpState(bool bold)
    {
        GetComponent<Animator>().SetBool("Bold", bold);
    }
}
