using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainHoneyIk : MonoBehaviour
{
    //gets all the joints in the chain
    [SerializeField] List<JointHoneyIK> joints;
    private float[] chainLengths;
    private Transform Target;

    public float GetTotalChainLength()
    {
        float[] boneLengths = new float[joints.Count - 1];
        float length = 0;
        
        for (int i = 0; i < joints.Count; i++)
        {
            if ((i + 1) != joints.Count)
            {
                length = Vector3.Distance(joints[i].transform.position, joints[(i + 1)].transform.position);
                boneLengths[i] = length;
            }
        }
      
        chainLengths = boneLengths;
        return length;
    }

    public Vector3[] GetJointPositionsToArray()
    {
        Vector3[] positions = new Vector3[joints.Count];

        int i = 0;
        foreach (JointHoneyIK j in joints)
        {
            positions[i] = j.transform.position;
            i++;
        }

        return positions;
    }

    public float GetLengthOfChain(int index)
    {
        return chainLengths[index];
    }
    
    public void InsertJointInChain(int index, JointHoneyIK newJoint)
    {
        joints.Insert(index, newJoint);
    }

    public Transform GetJointInChain(int index)
    {
        return joints[index].transform;
    }

    public List<JointHoneyIK> GetJoints()
    {
        return joints;
    }
    
    private void OnDrawGizmos()
    {
        DrawBones(Color.yellow);
    }

    void OnDrawGizmosSelected()
    {
        DrawBones(Color.red);
    }
    
    void DrawBones(Color color)
    {
        Gizmos.color = color;
        for (int i = 0; i < joints.Count; i++)
        { 
            if ((i + 1) != joints.Count)
            {
                Gizmos.DrawLine(joints[i].transform.position, joints[i+1].transform.position);
            }
        }
    }
}
