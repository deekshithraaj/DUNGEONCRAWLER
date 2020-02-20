using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private static UImanager _instance;
    public static UImanager Instance
    {
        get
        {
            if (_instance == null)
            {
                //throw new UnityException
                Debug.LogError("UiManager is Null");
            }
            return _instance;
        }

    }

    public void OpenShop(int gemCount)
    {
        playerGemcountText.text = "" + gemCount + "G";
        //how erver gems player has
    }

    public Text playerGemcountText;

    public Image Selectionimage;
    public Image[] Healthbars;

    public Text gemCountText;
    public void Awake()
    {
        _instance = this;
    }


    public void UpdateSelection(int ypos)
    {
        Selectionimage.rectTransform.anchoredPosition = new Vector2(Selectionimage.rectTransform.anchoredPosition.x, ypos);
    }
    public void UpdateGemcount( int count)
    {
        gemCountText.text = " " + count;  
    }

    public void UpdateLives(int livesReamining)
    {

        for (int i = 0; i <= livesReamining; i++)
        {

            if (i == livesReamining)
            {
                Healthbars[i].enabled = false;

            }
            //hide these #health bars
        }
        //loop throough lives 
        //i ==lives remianing
        //array hide that bars
    }
}
