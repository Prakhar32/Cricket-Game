using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowing : MonoBehaviour
{
    public bool startedDragging;
    public void BeginThrow()
    {
        if(!GetComponent<Rigidbody>().isKinematic)
            startedDragging = true;
    }

    public void RunSelected(GameObject run) 
    {
        if(startedDragging)
            GetComponent<Trajectory>().StartMotion(run);
        startedDragging = false;
    }

    public void InvalidSelection()
    {
        startedDragging = false;
    }
}
