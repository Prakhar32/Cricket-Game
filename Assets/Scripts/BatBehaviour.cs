using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
    public GameObject HitDestination;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<Rigidbody>())
            return;
        collision.rigidbody.velocity = Vector3.zero;
        collision.gameObject.GetComponent<Trajectory>().StartMotion(HitDestination);
    }

    public void SetBatState(int state)
    {
        GetComponent<Animator>().SetInteger("BatState", state);
    }
}
