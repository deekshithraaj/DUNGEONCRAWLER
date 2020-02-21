using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_script : MonoBehaviour
{

    public GameObject Shoppanel;
    public int currentSelectedItem;
    public int currentItemCost;

    private Player _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            _player = other.GetComponent<Player>();

            if (_player != null)
            {
                UImanager.Instance.OpenShop(_player.diamonds);
            }
            Shoppanel.SetActive(true); 
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Shoppanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        // set 0=flame sword,1-boots,2-key to castle 
        Debug.Log("SelectItem()" +item);

        switch (item)
        {
            case 0://flame sword
                UImanager.Instance.UpdateSelection(80);
                currentSelectedItem = 0;
                currentItemCost = 220;
                break;
            case 1:// flying boot
                UImanager.Instance.UpdateSelection(-18);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2://key to castle
                UImanager.Instance.UpdateSelection(-120);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {

        if (_player.diamonds >= currentItemCost)
        {
            if (currentSelectedItem ==2)
            {
                GameManager.Instance.hasKeyToCastle = true;
            }


            _player.diamonds -= currentItemCost;
            Debug.Log("purchased Item  :" + currentSelectedItem);
            Debug.Log("Remaining Gems  :" + _player.diamonds);
            Shoppanel.SetActive(false);
        }
        else
        {
            Debug.Log("you dont have enough money ");
            Shoppanel.SetActive(false);
        }
    }
}
