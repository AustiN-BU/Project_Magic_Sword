/*****************************************************************************
// File Name : NextStage.cs
// Author : Austin Nelson
// Creation Date : April 20, 2025
//
// Brief Description : This is the code used to transition the player between levels
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public void LevelTransition1()
    {
        SceneManager.LoadScene("BadlandsArea2");
    }

    public void LevelTransition2()
    {
        SceneManager.LoadScene("SunsetHeightsArea3");
    }
}
