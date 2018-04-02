using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Vector3 forceVector;

    private PhysicsEngine physicsEngine;

    private void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }
    private void FixedUpdate()
    {
        physicsEngine.AddForce(forceVector);
    }
}
