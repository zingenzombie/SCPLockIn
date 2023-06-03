using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMesh : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    public GameObject Canvas;
    public float defaultMovSpeed;
    public float defaultAngularSpeed;
    public float defaultAcceleration;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        this.GetComponent<NavMeshAgent>().speed = defaultMovSpeed * Canvas.GetComponent<TimeController>().TimeValue;
        this.GetComponent<NavMeshAgent>().angularSpeed = defaultAngularSpeed * Canvas.GetComponent<TimeController>().TimeValue;
        this.GetComponent<NavMeshAgent>().acceleration = defaultAcceleration * Canvas.GetComponent<TimeController>().TimeValue;
        navMeshAgent.destination = movePositionTransform.position;
    }
}
