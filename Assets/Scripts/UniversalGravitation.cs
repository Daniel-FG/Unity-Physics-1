using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour
{
    private PhysicsEngine[] physicsEngineArray;
    private const float gravityConstant = 6.673e-11f;
    private void Start()
    {
        physicsEngineArray = FindObjectsOfType<PhysicsEngine>();
    }
    private void FixedUpdate()
    {
        CalculateGravity();
    }
    void CalculateGravity()
    {
        foreach (PhysicsEngine physicsEngineA in physicsEngineArray)
        {
            foreach (PhysicsEngine physicsEngineB in physicsEngineArray)
            {
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {
                    Debug.Log("Calculating force exerted on " + physicsEngineA.name + " due to the gravity of " + physicsEngineB.name);

                    Vector3 distanceVector = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(distanceVector.magnitude, 2f);
                    float gravitationalForce = gravityConstant * physicsEngineA.mass * physicsEngineB.mass / rSquared;
                    Vector3 gravityFeltVector = gravitationalForce * distanceVector.normalized;
                    physicsEngineA.AddForce(-gravityFeltVector);
                }
            }
        }
    }
}
