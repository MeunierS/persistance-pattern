using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFactory : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [Range(1, 100)][SerializeField]private int batch = 10;
    [SerializeField]private float cooldown = 1;
    [SerializeField] Transform destination;
    [SerializeField]private Pool pool;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Create(){
        while(true){
            for(int _ = 0; _ < batch; _++){
                CapsuleMovement movement = pool.Create(transform.position, transform.rotation);
                movement.Initialize();
                movement.SetDestination(destination.position);
            }
        yield return new WaitForSeconds(cooldown);
        }
    }
}
