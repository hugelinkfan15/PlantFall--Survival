using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{

    public Transform Target;
    // Start is called before the first frame update
    void Update()
    {
        if (gameObject.activeSelf)
        {
            var dir = Target.position - transform.position;

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }


}
