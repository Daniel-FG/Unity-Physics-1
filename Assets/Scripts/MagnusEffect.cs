using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//馬格努斯效應
//球在一邊往一個方向前進時與自身旋轉時會有馬格努斯力作用於本身  大小方向為角速度與速度正積
public class MagnusEffect : MonoBehaviour
{
    public float magnusConstant = 1f;  //馬格努斯常數

    private Rigidbody rigidBody;
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        rigidBody.AddForce(magnusConstant * Vector3.Cross(rigidBody.angularVelocity, rigidBody.velocity));
	}
}
