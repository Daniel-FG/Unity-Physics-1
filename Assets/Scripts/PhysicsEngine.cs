using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 v;  //每一個FixedUpdate的平均速度
	void Start ()
    {
		
	}
	void FixedUpdate ()
    {
        //Vector3 deltaS = v * Time.deltaTime;  //在Update()裡用Time.deltaTime至於在FixedUpdate()裡用Time.fixedDeltaTime
                                                                         //Time.deltaTime如果在FixedUpdate()裡呼叫也會回傳Time.fixedDeltaTime
                                                                         //在FixedUpdate()裡  Time.deltaTime等於Time.fixedDeltaTime
        Vector3 deltaS = v * Time.fixedDeltaTime;
        transform.position = transform.position + deltaS;
	}
}
