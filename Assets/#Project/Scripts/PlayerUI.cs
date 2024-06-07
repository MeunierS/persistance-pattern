using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUI : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save(){
        float[] tempPos = new float[3];
        tempPos[0] = agent.transform.position.x;
        tempPos[1] = agent.transform.position.y;
        tempPos[2] = agent.transform.position.z;
        float[] tempDest = new float[3];
        tempDest[0] = agent.destination.x;
        tempDest[1] = agent.destination.y;
        tempDest[2] = agent.destination.z;
        PlayerData.Save(tempPos, tempDest);
    }
    public void Load(){
        //agent.transform.position.x = PlayerData.Load()[0];
    }
}
