using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float distanceShoot = 100f;
    public float weaponDamage = 25f;
    public GameObject player;
    GameObject anim;
    public ParticleSystem muzzleFlash;
    public GameObject effect;

    public int bullet;
    private int countbullet = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.transform.GetChild(0).gameObject;
        countbullet = bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetComponent<Animator>().GetBool("isShooting"))
        {
            anim.GetComponent<Animator>().SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (bullet > 0)
            {
                Shoot();
                bullet--;
            }
                
            else
                return;
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet = countbullet;
        }
        
    }

    void Shoot()
    {

        anim.GetComponent<Animator>().SetBool("isShooting", true);
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit , distanceShoot)){
            //Debug.Log("Hit");

            //EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            GameObject enemy = hit.transform.gameObject;
            if (enemy.tag == "Enemy")
            {
                enemy.GetComponent<EnemyManager>().TakeDamage(weaponDamage); 
            }

            GameObject temp = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(temp, 0.5f);
            
        }
    }
}
