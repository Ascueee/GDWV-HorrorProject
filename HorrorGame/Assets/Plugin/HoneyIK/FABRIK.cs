using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRIK : MonoBehaviour
{
    [SerializeField] private ChainHoneyIk chain;
    [SerializeField] private Transform target;
    [SerializeField] private float maxItterations;
    [SerializeField] private float marginofError;
    [SerializeField] private Transform startJoint;
    public float[] jointAngleLimits;
    
    private float totalLength;

    void Start()
    {
        //gets the total length of the chain
        totalLength = chain.GetTotalChainLength();
        startJoint = chain.GetJointInChain(0);
    }
    
    void Update()
    {
        List<JointHoneyIK> fabrikJoints = chain.GetJoints();
        float distanceFromTarget = Vector3.Distance(fabrikJoints[0].transform.position, target.position);
        
        if (distanceFromTarget > totalLength)
        {
            CheckIfTargetIsOutOfDistance(distanceFromTarget, fabrikJoints);
        }
        else
        {
            PerformFABRIK(fabrikJoints);
        }
    }
    
    /// <summary>
    /// Checks if the target is out of reach from the chain, if so then straighten chain in direction of target
    /// </summary>
    void CheckIfTargetIsOutOfDistance(float distanceFromTarget,List<JointHoneyIK> fabrikJoints)
    {
        //checks if the chain cannot reach the target
        if (distanceFromTarget > totalLength)
        {
            for (int i = 0; i < fabrikJoints.Count; i++)
            {
                if ((i + 1) != fabrikJoints.Count)
                {
                    fabrikJoints[i+1].transform.position = fabrikJoints[i].transform.position +(target.position - fabrikJoints[i].transform.position).normalized 
                        * chain.GetLengthOfChain(i);
                }
            }
        }
        
    }
    
    void PerformFABRIK(List<JointHoneyIK> fabrikJoints)
    {
        Vector3[] positions = chain.GetJointPositionsToArray();
        
        int itteration = 0;
        float distance = Vector3.Distance(positions[positions.Length - 1], target.position);

        while (distance > marginofError && itteration < maxItterations)
        {
            
            //forward kinematics is applied
            positions[positions.Length - 1] = target.position;
            for (int i = positions.Length - 2; i >= 0; i--)
            {
                positions[i] = positions[i + 1] + (positions[i] - positions[i+1]).normalized * chain.GetLengthOfChain(i);
            }
            
            //Inverse Kinematics is applied
            positions[0] = fabrikJoints[0].transform.position;
            for (int i = 0; i < positions.Length - 1; i++)
            {
               Vector3 direction = (positions[i + 1] - positions[i]).normalized;
               Vector3 constrainedDirection = ConstrainDirection(fabrikJoints[i].GetTransform(), direction, i);
               positions[i + 1] = positions[i] + constrainedDirection * chain.GetLengthOfChain(i);
            }
            
            distance = Vector3.Distance(positions[positions.Length - 1], target.position);
            itteration++;
        }
        
        Vector3 ConstrainDirection(Transform joint, Vector3 targetDirection, int jointIndex)
        {
               if (jointIndex >= jointAngleLimits.Length) return targetDirection;
                                    
               float angleLimit = jointAngleLimits[jointIndex];
               Vector3 initialDirection = joint.forward; // Use initial 'up' vector as the base direction
                                    
               float angle = Vector3.Angle(initialDirection, targetDirection);
               if (angle > angleLimit)
               {
                   targetDirection = Vector3.RotateTowards(initialDirection, targetDirection, angleLimit * Mathf.Deg2Rad, 0.0f);
    
               }
                  return targetDirection.normalized;
        }
        //applies the positions to the original joints to update their position
        int j = 0;
        foreach (Vector3 position in positions)
        {
            fabrikJoints[j].transform.position = position;
            j++;
        }
        
    }
}
