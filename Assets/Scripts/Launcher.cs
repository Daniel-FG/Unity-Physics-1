using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public PhysicsEngine ballToLaunch;
    public AudioClip windUpSound, launchSound;
    public float maxLaunchSpeed;

    private AudioSource audioSource;
    private float launchSpeed;
    private float extraSpeedPerFrame;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = windUpSound;

        //每禎增加的速度 = 最大速度 * 每禎經過的時間 / 時間長度
        //乘上每禎的時間使每一禎做的事情獨立
        extraSpeedPerFrame = maxLaunchSpeed * Time.fixedDeltaTime / windUpSound.length;
    }
    private void OnMouseDown()
    {
        launchSpeed = 0;
        InvokeRepeating("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
        audioSource.clip = windUpSound;
        audioSource.Play();
    }
    private void OnMouseUp()
    {
        CancelInvoke();
        PhysicsEngine newBall = Instantiate(ballToLaunch) as PhysicsEngine;
        newBall.transform.parent = GameObject.Find("Launched Balls").transform;
        Vector3 launchVelocity = new Vector3(1, 1, 0).normalized * launchSpeed;
        newBall.velocityVector = launchVelocity;

        audioSource.Stop();
        audioSource.clip = launchSound;
        audioSource.Play();
    }
    private void IncreaseLaunchSpeed()
    {
        if(launchSpeed <= maxLaunchSpeed)
        {
            launchSpeed = launchSpeed + extraSpeedPerFrame;
        }
    }
}
