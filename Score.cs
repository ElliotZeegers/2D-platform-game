using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public text genaamd score zodat die in de inspector gelinkt kan worden aan de text op het canvas zodat die aangepast kan worden in dit script
    public Text score;
    //int om het aantal appels die je hebt opgepakt in op te slaan. Het is public zodat de waarde in een ander script kan worden aangepast
    public int apples = 0;
    void Update()
    {
        //zet de tekst op "score = " apples.ToString(); dus de waarde van de int apples
        score.text = "score = " + apples.ToString();

        //als apples gelijk is aan 5 dan voert die de code hieronder uit
        if(apples == 5)
        {
            //laad de scene genaamd "Win"
            SceneManager.LoadScene("Win");
        }
    }
}
