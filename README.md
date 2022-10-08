# unity3d-抛物线的三种实现方式

homework for unity3d class

## 使用说明

打开项目后可以看到物体cube和target。物体cube上面挂载了三个脚本，勾选其中一个就可以观察该脚本的效果。

## 原理

脚本1实现的是简单的平抛运动，通过x与y方向上的分解运动来实现。

脚本2在确定了起点和终点的情况下，通过不断调整角度指向目标点来实现抛物线运动。

脚本3在确定了起点和仰角的情况下，通过角度计算来模拟抛物线。

## 代码

paowuxian1.cs

```csharp
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
```

paowuxian2.cs

```csharp
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

```

paowuxian3.cs

```csharp
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
```
