using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipUI : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public BulletBehavior bullet;
    public TMP_Text scoreLabel;
    public TMP_Text lifeLabel;
    int lastLife;
    int lastScore =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        playerMovement.onLifeLost.AddListener(UpdateLife);
        bullet.onHit.AddListener(UpdateScore);
    }
    void OnDisable(){
        playerMovement.onLifeLost.RemoveListener(UpdateLife);
        bullet.onHit.RemoveListener(UpdateScore);
    }
    void UpdateLife(int value)
    {
        if (lastLife != value){
            lifeLabel.SetText($"Life: {value}");
            lastLife = value;
        }
    }
    void UpdateScore(int value)
    {
        if(lastScore != value){
        lastScore+=value;
        scoreLabel.SetText($"Score: {lastScore}");
        }
    }
}
