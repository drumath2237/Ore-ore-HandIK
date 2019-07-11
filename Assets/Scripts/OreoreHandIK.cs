using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoreHandIK : MonoBehaviour
{
    [SerializeField] GameObject WristBone;
    [SerializeField] GameObject ElbowBone;
    [SerializeField] GameObject ShoulderBone;

    float x;
    float l_we, l_es;
    float _l_we, _l_es;
    float y;
    float theta_e, phi_s;

    Vector3 initialWristPos;

    void Start()
    {
        x = 0;
        l_we = (WristBone.transform.position - ElbowBone.transform.position).magnitude;
        l_es = (ElbowBone.transform.position - ShoulderBone.transform.position).magnitude;

        initialWristPos = WristBone.transform.position;
    }

    void Update()
    {
        calcBoneStates();

        ElbowBone.transform.position = new Vector3(ElbowBone.transform.position.x, ElbowBone.transform.position.y, y);
        ElbowBone.transform.rotation = Quaternion.AngleAxis(theta_e, new Vector3(0, 1, 0));
        ShoulderBone.transform.rotation = Quaternion.AngleAxis(phi_s, new Vector3(0, 1, 0));
    }

    void calcBoneStates()
    {
        x = initialWristPos.x - WristBone.transform.position.x;

        float ratio = (l_we + l_es - x) / (l_we + l_es);
        _l_we = ratio * l_we;
        _l_es = ratio * l_es;

        y = Mathf.Sqrt(l_we * l_we - _l_we * _l_we);

        theta_e = Mathf.Rad2Deg * Mathf.Acos(_l_we / l_we);
        phi_s  = -Mathf.Rad2Deg * Mathf.Acos(_l_es / l_es);
    }
}
