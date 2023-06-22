using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLayer : MonoBehaviour
{
    //als je de collider van dit gameobject aanraakt dan voert die de code hieronder uit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //laad de scene met de naam "GameOver"
        SceneManager.LoadScene("GameOver");
    }
}
