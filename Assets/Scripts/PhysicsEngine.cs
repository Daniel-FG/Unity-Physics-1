using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public float mass = 1f;  //質量
    public Vector3 netForceVector;  //淨力
    public Vector3 velocityVector;  //每一個FixedUpdate的平均速度
    public bool showTrails = true;  //呈現

    private List<Vector3> forceVectorList = new List<Vector3>();
    private LineRenderer lineRenderer;
    private int numberOfForces;

    void Start ()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(Color.yellow, Color.yellow);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.useWorldSpace = false;

        AddForce forceAdded = GetComponent<AddForce>();
    }
    void FixedUpdate ()
    {
        //Vector3 deltaS = v * Time.deltaTime;  //在Update()裡用Time.deltaTime至於在FixedUpdate()裡用Time.fixedDeltaTime
        //                                                              //Time.deltaTime如果在FixedUpdate()裡呼叫也會回傳Time.fixedDeltaTime
        //                                                              //在FixedUpdate()裡  Time.deltaTime等於Time.fixedDeltaTime
        RenderTrails();
        SumForce();
        UpdatePosition();
    }
    public void AddForce(Vector3 force)
    {
        forceVectorList.Add(force);
    }
    void SumForce()
    {
        netForceVector = Vector3.zero;
        foreach(Vector3 vector in forceVectorList)
        {
            netForceVector = netForceVector + vector;
        }
        forceVectorList.Clear();
    }
    void UpdatePosition()
    {
        Vector3 accelerationVector = netForceVector / mass;
        velocityVector = velocityVector + accelerationVector * Time.fixedDeltaTime;
        Vector3 deltaS = velocityVector * Time.fixedDeltaTime;
        transform.position = transform.position + deltaS;
    }
    void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.SetVertexCount(numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
