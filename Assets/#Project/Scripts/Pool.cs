using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<CapsuleMovement> pool = new();
    [SerializeField]private GameObject prefab;
    public CapsuleMovement Create(Vector3 position, Quaternion rotation){
        if(pool.Count == 0){
            GameObject newOne = Instantiate(prefab, position, rotation);
            newOne.GetComponent<CapsuleMovement>().Pool = this;
            return newOne.GetComponent<CapsuleMovement>();
        }
        CapsuleMovement movement = pool[0];
        movement.transform.position = position;
        movement.transform.rotation = rotation;
        pool.RemoveAt(0);
        return movement;
    }
    public CapsuleMovement Create() => Create(Vector3.zero, Quaternion.identity);
    public CapsuleMovement Create(Vector3 position) => Create(position, Quaternion.identity);
    public void AddToPool(CapsuleMovement movement){
        pool.Add(movement);
    }
}
