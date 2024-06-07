using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public CubePool pool;
    public bool initialized = false;
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnBecameInvisible(){
        Die();
    }
    private void OnBecameVisible(){
        Initialize();
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
}
