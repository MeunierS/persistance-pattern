using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Stack<CapsuleMovement> pool = new();
    [SerializeField]private GameObject prefab;
    [SerializeField]private int initialBatch = 50;
    private void Awake(){
        for(int _=0; _ < initialBatch; _++){
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<CapsuleMovement>().Pool = this;
            newOne.GetComponent<CapsuleMovement>().Die();
        }
    }
    public CapsuleMovement Create(Vector3 position, Quaternion rotation){
        if(pool.Count == 0){
            GameObject newOne = Instantiate(prefab, position, rotation);
            newOne.GetComponent<CapsuleMovement>().Pool = this;
            return newOne.GetComponent<CapsuleMovement>();
        }
        CapsuleMovement movement = pool.Pop();
        movement.transform.position = position;
        movement.transform.rotation = rotation;
        return movement;
    }
    public CapsuleMovement Create() => Create(Vector3.zero, Quaternion.identity);
    public CapsuleMovement Create(Vector3 position) => Create(position, Quaternion.identity);
    public void AddToPool(CapsuleMovement movement){
        pool.Push(movement);
    }
}
