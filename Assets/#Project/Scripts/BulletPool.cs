using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Stack<BulletBehavior> pool = new();
    [SerializeField]private GameObject prefab;
    [SerializeField]private int initialBatch = 50;
    private void Awake(){
        for(int _=0; _ < initialBatch; _++){
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<BulletBehavior>().pool = this;
            newOne.GetComponent<BulletBehavior>().Die();
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
    public BulletBehavior Create(Vector3 position, Quaternion rotation){
        if(pool.Count == 0){
            GameObject newOne = Instantiate(prefab, position, rotation);
            newOne.GetComponent<BulletBehavior>().pool = this;
            return newOne.GetComponent<BulletBehavior>();
        }
        BulletBehavior movement = pool.Pop();
        movement.transform.position = position;
        movement.transform.rotation = rotation;
        return movement;
    }
    public BulletBehavior Create() => Create(Vector3.zero, Quaternion.identity);
    public BulletBehavior Create(Vector3 position) => Create(position, Quaternion.identity);
    public void AddToPool(BulletBehavior movement){
        pool.Push(movement);
    }
}
