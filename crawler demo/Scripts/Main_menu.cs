﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start_button()
    {

        SceneManager.LoadScene("Game");

    }

    public void Quit_button()
    {
        Application.Quit();
    }
}
