using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private Stack<CubeMovement> pool = new();
    [SerializeField]private GameObject prefab;
    [SerializeField]private int initialBatch = 50;
    private void Awake(){
        for(int _=0; _ < initialBatch; _++){
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<CubeMovement>().pool = this;
            newOne.GetComponent<CubeMovement>().Die();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CubeMovement Create(Vector3 position, Quaternion rotation){
        if(pool.Count == 0){
            GameObject newOne = Instantiate(prefab, position, rotation);
            newOne.GetComponent<CubeMovement>().pool = this;
            return newOne.GetComponent<CubeMovement>();
        }
        CubeMovement movement = pool.Pop();
        movement.transform.position = position;
        movement.transform.rotation = rotation;
        return movement;
    }
    public CubeMovement Create() => Create(Vector3.zero, Quaternion.identity);
    public CubeMovement Create(Vector3 position) => Create(position, Quaternion.identity);
    public void AddToPool(CubeMovement movement){
        pool.Push(movement);
    }
}
