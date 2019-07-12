using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreOreHandIK2D : MonoBehaviour
{
    [SerializeField] GameObject ShoulderBone;
    [SerializeField] GameObject ElbowBone;
    [SerializeField] GameObject WristBone;

    Transform initElbow, initWrist, initShoulder;
    float theta1, theta2;

    float d1, d2;

    // Start is called before the first frame update
    void Start()
    {
        initElbow = ElbowBone.transform;
        initWrist = WristBone.transform;
        initShoulder = ShoulderBone.transform;

        d1 = (initElbow.position - initShoulder.position).magnitude;
        d2 = (initWrist.position - initElbow.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        calcTheta2();
        ElbowBone.transform.rotation = Quaternion.AngleAxis(theta2, new Vector3(0, 1, 0));
    }

    void calcTheta2()
    {
        var x = WristBone.transform.position.x;
        var y = WristBone.transform.position.z;
        var x2 = x * x;
        var y2 = y * y;
        //var tmp = (x2 + y2 - d1 * d1 - d2 * d2) / 2 * d1 * d2;
        theta2 = Mathf.Rad2Deg * Mathf.Acos((x2 + y2 - d1 * d1 - d2 * d2) / 2 * d1 * d2);
    }
}
