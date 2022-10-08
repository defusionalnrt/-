using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paowuxian1 : MonoBehaviour
{
    public float xSpeed = 10.0f;
    public float ySpeed = 0f;
    public float g = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ySpeed = ySpeed - g * Time.fixedDeltaTime;
        transform.Translate(Vector3.right * xSpeed * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.up * ySpeed * Time.fixedDeltaTime, Space.World);
    }
}
