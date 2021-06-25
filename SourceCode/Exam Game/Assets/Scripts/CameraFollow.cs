using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;
    public float Damping = 1;
    public float LookAheadFactor = 3;
    public float LookAheadReturnSpeed = 0.5f;
    public float LookaheadMoveThreshold = 0.1f;
    public float yPosRestriction = -1;

    float OffSetz;
    Vector3 LastTargetPosition;
    Vector3 CurrentVelocity;
    Vector3 LookAheadPos;

    float NextTimeToSearch = 0;

    private void Start()
    {
        LastTargetPosition = Target.position;
        OffSetz = (transform.position - Target.position).z;
        transform.parent = null;
    }

    private void Update()
    {
        if (Target == null)
        {
            FindPlayer();
            return;
        }
        float xMoveDelta = (Target.position - LastTargetPosition).x;

        bool UpdateLookAheadTarget = Mathf.Abs(xMoveDelta) > LookaheadMoveThreshold;

        if (UpdateLookAheadTarget)
        {
            LookAheadPos = LookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            LookAheadPos = Vector3.MoveTowards(LookAheadPos, Vector3.zero, Time.deltaTime * LookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = Target.position + LookAheadPos + Vector3.forward * OffSetz;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref CurrentVelocity, Damping);

        newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

        transform.position = newPos;

        LastTargetPosition = Target.position;
    }

    void FindPlayer()
    {
        if (NextTimeToSearch <= Time.time)
        {
            GameObject SearchResult = GameObject.FindGameObjectWithTag("Player");
            if (SearchResult != null)
                Target = SearchResult.transform;
            NextTimeToSearch = Time.time + 0.2f;
        }
    }



}
