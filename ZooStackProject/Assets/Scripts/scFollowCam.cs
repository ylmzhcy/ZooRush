using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scFollowCam : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    float smoothSpeed = 0.125f;
    Vector3 _followOffset = new Vector3(0, 5, -13);

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPos = _target.position + _followOffset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(desiredPos);
    }
}
