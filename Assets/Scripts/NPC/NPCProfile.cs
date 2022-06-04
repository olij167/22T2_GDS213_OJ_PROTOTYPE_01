using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NPC Profile")]
public class NPCProfile : ScriptableObject
{
    public List<string> interestingTags;
    public float lookSphere, lookRange, maxAttentionSpanReset, minAttentionSpanReset, stoppingDistance, speed;

}
