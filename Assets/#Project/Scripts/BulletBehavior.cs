using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    public BulletPool pool;
    public bool initialized = false;
    [HideInInspector]public UnityEvent<int> onHit;
    void Start()
    {
        Initialize();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible(){
        Die();
    }
    public void Initialize(){
        if(initialized) return;
        initialized = true;
        gameObject.SetActive(true);
    }
    public void Die(){
        gameObject.SetActive(false);
        initialized = false;
        pool.AddToPool(this);
    }
    void OnTriggerEnter(Collider other){
        onHit?.Invoke(1);
        other.GetComponent<CubeMovement>().Die();
        this.Die();
    }
}
