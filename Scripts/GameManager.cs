using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyAlive = 0;
    public int round = 0;
    public int coin;

    public GameObject[] SpawnPoint;
    public GameObject enemy;

    public Text RoundDisplay;
    public Text CoinDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = GameObject.Find("Zombie(Clone)");
        if (temp == null)
        {
            enemyAlive = 0;
        }
        if (enemyAlive == 0)
        {
            round++;
            NextWave(round);
            RoundDisplay.text = "Round : " + round.ToString();
        }

        CoinDisplay.text = "Coin : " + coin.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Spawn(GameObject spawnLocate)
    {
        GameObject zombie = Instantiate(enemy , spawnLocate.transform.position , Quaternion.identity);
    }

    public void NextWave(int round)
    {
        for (int i = 0; i < round; i++)
        {
            GameObject spawnLocate = SpawnPoint[Random.Range(0, SpawnPoint.Length)];
            Spawn(spawnLocate);
            enemyAlive++;
        }
        
    }
}
