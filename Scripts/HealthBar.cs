using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");    
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerManager>().health;
        gameObject.transform.localScale = new Vector3(health / 100, 1, 1);
    }
}
