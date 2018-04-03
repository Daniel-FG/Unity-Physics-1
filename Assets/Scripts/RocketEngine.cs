using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//火箭引擎
public class RocketEngine : MonoBehaviour
{
    public float fuelMass;  //燃料重量  [kg]
    public float maxThrust;  //最大推力  [kg * m/s^2]
    public float thrustPercent;  //推力比例
    public Vector3 thrustDirectionVector;  //推力方向

    private PhysicsEngine physicsEngine;

    private void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }
    private void FixedUpdate()
    {
        physicsEngine.AddForce(thrustDirectionVector);
    }
}
