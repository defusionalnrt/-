using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paowuxian3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle = 20f;
    public float xSpeed = 10f;
    public float g = 9.8f;
    public Vector3 MoveSpeed;
    public Vector3 gSpeed;
    public float t;
    public Vector3 timeAngle;
    void Start()
    {
        MoveSpeed = Quaternion.Euler(new Vector3(0, 0, angle)) * Vector3.right * xSpeed;
        gSpeed = Vector3.zero;
        t = 0f;
        timeAngle = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.fixedDeltaTime;
        gSpeed.y = - g * t;
        transform.position += (MoveSpeed + gSpeed) * Time.fixedDeltaTime;
        timeAngle.z = Mathf.Atan((MoveSpeed.y + gSpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
        transform.eulerAngles = timeAngle;
    }
}
