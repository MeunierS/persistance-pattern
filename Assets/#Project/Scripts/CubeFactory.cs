using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [Range(1, 100)][SerializeField]private int batch = 10;
    [SerializeField]private float cooldown = 1;
    [SerializeField] Transform position;
    [SerializeField]private CubePool pool;
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
                CubeMovement movement = pool.Create(transform.position, transform.rotation);
                movement.Initialize();
                Vector3 spawnPoint = new Vector3(transform.position.x,Random.Range(-10f,10f),0);
                movement.transform.position= spawnPoint;
            }
        yield return new WaitForSeconds(cooldown);
        }
    }
}
