using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour
{
    [Range (1f, 2f)]
    public float velocityExponent;  //速度的次方  介於1次與2次

    public float dragConstant;  //流體阻力常數

    private PhysicsEngine physicsEngine;

	void Start ()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
	}
    private void FixedUpdate()
    {
        Vector3 velocityVector = physicsEngine.velocityVector;
        float speed = velocityVector.magnitude;
        float dragSize = CalculateDrag(speed);
        Vector3 dragVector = dragSize * -velocityVector.normalized;
        physicsEngine.AddForce(dragVector);
    }

    float CalculateDrag(float speed)
    {
        return dragConstant * Mathf.Pow(speed, velocityExponent);
    }
}
