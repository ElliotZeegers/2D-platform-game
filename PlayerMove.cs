using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    //float voor de snelheid van de speler
    float speed = 7;
    //float voor hoe hoog je kunt springen
    float jumpPower = 3;
    //een bool om te checken of je kunt springen
    bool canJump;
    //float om de movement op de x as in op te slaan
    float Xmovement;

    void Start()
    {
        //linkt rb aan de Rigidbody2D op het gameobject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //zet de float genaamd "Speed" in de animator die word gebruikt om een animatie mee te laten afspelen op de waarde van Xmovement en zorgt ervoor dat het niet negatief kan zijn
        animator.SetFloat("Speed", Mathf.Abs(Xmovement));

        //als de float Xmovement groter is dan 1
        if (Xmovement > 0)
        {
            //zorgt ervoor dat de sprite omdraait als je naar voor loopt
            gameObject.transform.localScale = new Vector3(-2, 2, 2);
        }
        //als de float Xmovement kleiner is dan 1
        if (Xmovement < 0)
        {
            //zorgt ervoor dat de sprite omdraait als je naar achter loopt
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }

        //als de bool canJump op true staat dan voert die de code hieronder uit
        if (canJump == true)
        {
            //zet de float Xmovement op 1 of -1 * speed als je op de knoppen klikt voor het bewegen
            Xmovement = Input.GetAxis("Horizontal") * speed;
            //zet de velocity van de rigidbody op de waarde van Xmovement en de waarde van de velocity op de y as van de rigidbody
            rb.velocity = new Vector2(Xmovement, rb.velocity.y);
        }
        else
        {
            //zet de float Xmovement op 1 of -1 * (speed - 1.75) als je op de knoppen klikt voor het bewegen - 1.75f is zodat je mider snel kunt bewegen in de lucht
            Xmovement = Input.GetAxis("Horizontal") * (speed - 1.75f);
            //zet de velocity van de rigidbody op de waarde van Xmovement en de waarde van de velocity op de y as van de rigidbody
            rb.velocity = new Vector2(Xmovement, rb.velocity.y);
        }
        //schiet een lijn naar onder die begint in het midden van de speler, de lijn is 0,5f lang en slaat op in de RaycastHit2D hit of die iets raakt
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);

        //als hit iets heeft geraakt dan voert die de code hieronder uit
        if(hit.collider != null)
        {
            //als de raycast een collider hit met de tag Level dan voert die de code hieronder uit
            if(hit.collider.tag == "Level")
            {
                //zet de bool canJump op true
                canJump = true;
            }
            //als die de if niet uitvoert voert die de code hieronder uit
            else
            {
                //zet de bool canJump op false
                canJump = false;
            }
        }
        //als die de if niet uitvoert voert die de code hieronder uit
        else
        {
            //zet de bool canJump op true
            canJump = false;
        }

        //als er op de spatiebalk word geklikt en als canJump true is dan voert die de code hieronder uit
        if (Input.GetKeyDown("space") && canJump == true)
        {
            //voegt force toe aan de rigidbody op de y as zodat je kunt springen
            rb.AddForce(new Vector2(0, jumpPower * 90));
        }

    }
}
