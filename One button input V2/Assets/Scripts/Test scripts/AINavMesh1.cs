using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh1 : MonoBehaviour
{
    NavMeshAgent myWalkieBoi;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        myWalkieBoi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        myWalkieBoi.SetDestination(target.position);
    }
}
