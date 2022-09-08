using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100f;

    public void TakeDame(float damage)
    {
        health -= damage;
        if ( health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
