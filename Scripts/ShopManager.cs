using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public bool isEnable = false;
    public GameObject ShopPanel;

    public GameObject[] buttonObject;
    public Button[] button;
    public Text[] textButton;

    public int coin;
    public int selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<buttonObject.Length; i++)
        {
            button[i] = buttonObject[i].GetComponent<Button>();
            textButton[i] = buttonObject[i].GetComponentInChildren<Text>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        coin = gameObject.GetComponent<GameManager>().coin;
        if (Input.GetKeyDown(KeyCode.V))
        {
            ShopPanel.SetActive(!isEnable);
            if (!isEnable)
                isEnable = true;
            else
                isEnable = false;
        }

        if (isEnable == true)
            Time.timeScale = 0f;
        else 
            Time.timeScale = 1f;

        for (int i = 0; i < buttonObject.Length; i++)
        {
            if (textButton[i].text == "Used")
            {
                selectedWeapon = i;
            }
        }
    }

    public void OnClick(int num)
    {
        int price;
        int.TryParse(textButton[num].text,out price);

        if (textButton[num].text == "Owned")
        {
            for (int i=0; i < buttonObject.Length; i++)
            {
                int other_price;
                int.TryParse(textButton[i].text, out other_price);
                if (i == num) continue;
                else if ( i != num && other_price == 0)
                {
                    textButton[i].text = "Owned";
                }
            }
            textButton[num].text = "Used";
            return;
        }

        if (price <= coin)
        {
            textButton[num].text = "Owned";
            coin -= price;
            gameObject.GetComponent<GameManager>().coin -= price;
            return;
        }

    }
}
