using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int selectWeapon;
    public GameObject GameManager;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("Game Manager");
        
    }

    // Update is called once per frame
    void Update()
    {
        selectWeapon = GameManager.GetComponent<ShopManager>().selectedWeapon;
        SelectWeapon();

    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
