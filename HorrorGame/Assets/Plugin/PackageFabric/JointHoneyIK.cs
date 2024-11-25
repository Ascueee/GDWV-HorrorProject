using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointHoneyIK : MonoBehaviour
{
    public Transform GetTransform()
    {
        return transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 0.03f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.03f);
    }
}
