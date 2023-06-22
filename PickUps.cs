using UnityEngine;

public class PickUps : MonoBehaviour
{
    //zorgt ervoor dat je vanuit dit script aanpassing kunt maken aan de public variabelen uit het script Score
    public Score score;

    //als je de collider van dit gameobject aanraakt dan voert die de code hieronder uit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //telt 1 bij de int apples in het script Score op
        score.apples++;
        //haalt het gameobject uit de scene
        Destroy(this.gameObject);
    }
}
