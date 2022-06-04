using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCMovementAI : MonoBehaviour
{
    AIDestinationSetter destinationSetter;
    RichAI richAI;

    public NPCProfile npcProfile;

    public List<GameObject> interestingObjects, walkPoints;

    public GameObject eyes;

    public bool isDistracted;

    public Color stateColour;

    Transform targetPos;

    public float attentionSpan;

    void Start()
    {
        stateColour = Color.cyan;

        destinationSetter = GetComponent<AIDestinationSetter>();
        richAI = GetComponent<RichAI>();

        richAI.maxSpeed = npcProfile.speed;

        ListInterestingObjects();

        targetPos = walkPoints[Random.Range(0, walkPoints.Count)].transform;
        destinationSetter.target = targetPos;
    }

    void Update()
    {
        if (isDistracted)
        {
            AttentionSpanTimer();

            if (Vector3.Distance(transform.position, targetPos.position) <= npcProfile.stoppingDistance)
            {
                richAI.canMove = false;
            }
            else
            {
                richAI.canMove = true;
            }

            transform.LookAt(targetPos);
        }
        else
        {
            DetectInterestingObjects();

            
        }
    }

    void ListInterestingObjects()
    {
        foreach (string tag in npcProfile.interestingTags)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag(tag).Length; i++)
            {
                GameObject interestingObject = GameObject.FindGameObjectsWithTag(tag)[i];
                if (!interestingObjects.Contains(interestingObject))
                {
                    interestingObjects.Add(interestingObject);
                }
            }
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Waypoint").Length; i++)
        {
            GameObject walkPoint = GameObject.FindGameObjectsWithTag("Waypoint")[i];
            if (!walkPoints.Contains(walkPoint))
            {
                walkPoints.Add(walkPoint);
            }
        }

            //Debug.Log("Objects Listed");
    }

    void DetectInterestingObjects()
    {

        RaycastHit hit;

        if (Physics.SphereCast(eyes.transform.position, npcProfile.lookSphere, Vector3.forward, out hit, npcProfile.lookRange))
        {
            if (interestingObjects.Contains(hit.transform.gameObject))
            {
                targetPos = hit.transform;

                destinationSetter.target = targetPos;
                stateColour = Color.red;
                isDistracted = true;
            }
        }

        if (Vector3.Distance(transform.position, targetPos.position) <= npcProfile.stoppingDistance)
        {
            targetPos = walkPoints[Random.Range(0, walkPoints.Count)].transform;
            destinationSetter.target = targetPos;
        }

    }

    void AttentionSpanTimer()
    {
        attentionSpan -= Time.deltaTime;

        if (attentionSpan <= 0)
        {
            targetPos = walkPoints[Random.Range(0, walkPoints.Count)].transform;

            destinationSetter.target = targetPos;

            attentionSpan = Random.Range(npcProfile.minAttentionSpanReset, npcProfile.maxAttentionSpanReset);
            stateColour = Color.cyan;
            isDistracted = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = stateColour;
        Gizmos.DrawWireSphere(eyes.transform.position, npcProfile.lookSphere);

        if (isDistracted)
        {
            Gizmos.DrawLine(eyes.transform.position, targetPos.position);
        }
    }
}
