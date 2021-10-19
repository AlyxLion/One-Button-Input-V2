using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavMesh : MonoBehaviour
{
   NavMeshAgent myWalkieBoi;
   GameObject player;

   

        // Start is called before the first frame update
    void Start()
    {
        myWalkieBoi = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        

       
    }

    // Update is called once per frame
    void Update()
    {
        myWalkieBoi.SetDestination(player.transform.position);
    }
}
