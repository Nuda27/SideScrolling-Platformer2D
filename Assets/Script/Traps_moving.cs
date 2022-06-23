using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps_moving : MonoBehaviour
{
    public GameObject TargetObject;
    public Vector3 ParameterVector;
    public float PingPongSpeed;
    Vector3 StartPosition;
    Vector2 EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = TargetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * PingPongSpeed, 1);
        EndPosition = StartPosition + ParameterVector;
        TargetObject.transform.position = Vector3.Lerp(StartPosition, EndPosition, pingPong);
    }
}
