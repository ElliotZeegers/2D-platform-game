using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        //laad de scene met de naam "Level 1"
        SceneManager.LoadScene("Level 1");
    }
}
