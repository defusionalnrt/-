using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paowuxian2 : MonoBehaviour
{
    public float xSpeed = 10.0f;
    public float ySpeed;
    public float g = 9.8f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        float dis = Vector3.Distance(transform.position, target.position);
        float useTime = dis / xSpeed;
        float riseTime = useTime / 2;
        ySpeed = g * riseTime;
        transform.LookAt(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        ySpeed = ySpeed - g * Time.deltaTime;
        transform.Translate(transform.forward * xSpeed * Time.deltaTime, Space.World);
        transform.Translate(transform.up * ySpeed * Time.deltaTime, Space.World);
    }
}
