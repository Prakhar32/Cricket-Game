using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public int Label;
    public GameObject Stumps;
    public GameObject Bat;

    [SerializeField]
    private DecisionMaker decisionMaker;

    public SelectionMapper mapper;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Trajectory>() == null)
            return;
        decisionMaker.SelectRunToScore(this);
    }

    public float GetProbability(int runSelected, BallType type)
    {
        return mapper[type][runSelected];
    }


   /* public void MakeDecision(Collision collision)
    {
        float result = Random.Range(0, 10.0f) / 10;
        if (result <= ProbabilityOfSuccess)
            Success(collision);
        else
            Failure(collision);
    }

    public void Success(Collision collision)
    {
        collision.rigidbody.AddForce(new Vector3(0, 1.5f, 0), ForceMode.VelocityChange);
        collision.gameObject.GetComponent<Trajectory>().StartMotion(Bat);
        Bat.GetComponent<BatBehaviour>().SetBatState(1);
    }

    public void Failure(Collision collision)
    {
        collision.rigidbody.AddForce(new Vector3(0, 1.5f, 0), ForceMode.VelocityChange);
        collision.gameObject.GetComponent<Trajectory>().StartMotion(Stumps);
        Bat.GetComponent<BatBehaviour>().SetBatState(2);
    }*/
}
