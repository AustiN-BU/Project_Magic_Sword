/*****************************************************************************
// File Name : MainMenu.cs
// Author : Austin Nelson
// Creation Date : March 31, 2025
//
// Brief Description : This is for the button on the main menu, there will be more added when needed.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("ForestArea1");
    }
}
