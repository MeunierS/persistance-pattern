using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CapsuleMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Pool Pool;
    public bool initialized = false;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(){
        if(initialized) return;
        agent = GetComponent<NavMeshAgent>();
        initialized = true;
        gameObject.SetActive(true);
    }
    public void SetDestination(Vector3 destination){
        agent.SetDestination(destination);
    }
    public void Die(){
        gameObject.SetActive(false);
        initialized = false;
        Pool.AddToPool(this);
    }
}
