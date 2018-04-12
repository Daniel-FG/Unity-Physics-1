using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//火箭引擎
public class RocketEngine : MonoBehaviour
{
    public float fuelMass;  //燃料重量  [kg]
    public float maxThrust;  //最大推力，千牛頓  [kg * m/s^2]

    [Range (0f, 1f)]
    public float thrustPercent;  //推力比例
    public Vector3 thrustDirectionVector;  //推力方向

    private PhysicsEngine physicsEngine;
    private float currentThrust;  //目前推力  牛頓  [kg * m/s^2]

    private void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.mass = physicsEngine.mass + fuelMass;
    }
    private void FixedUpdate()
    {
        float usedFuelThisUpdate = FuelThisUpdate();

        if(fuelMass - usedFuelThisUpdate >= 0f)
        {
            fuelMass = fuelMass - usedFuelThisUpdate;
            physicsEngine.mass = physicsEngine.mass - usedFuelThisUpdate;
            ExertForce();
        }
        else
        {
            Debug.LogWarning("Out of fuel");
        }
        
    }
    float FuelThisUpdate()
    {
        float exhaustMassFlow;
        float effectiveExhaustVelocity = 4462f;  //液態氫氧引擎  [m/s]

        //thrust = massFlow * exhaustVelocity
        //massFlow = thrust / exhaustVelocity

        exhaustMassFlow = currentThrust / effectiveExhaustVelocity;

        return exhaustMassFlow * Time.deltaTime;
    }
    void ExertForce()
    {
        currentThrust = maxThrust * thrustPercent * 1000f;  //牛頓  [kg * m/s^2]
        Vector3 thrustVector = currentThrust * thrustDirectionVector.normalized;  //牛頓  [kg * m/s^2]
        physicsEngine.AddForce(thrustVector);
    }
}
