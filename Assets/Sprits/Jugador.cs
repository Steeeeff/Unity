using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float potenciaSalto;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool puedeSaltar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //si se pulsa alguna tecla
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            puedeSaltar = false;
            animator.SetBool("Saltando", true);
            rigidbody2D.AddForce(new Vector2(0, potenciaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("Saltando", false);
            puedeSaltar = true;
        }

        // cuando colisiono
        if (collision.gameObject.tag == "Obstaculo"){
               gameManager.finJuego = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Contador")
        {
            //Contador
            gameManager.AumentarContador();
        }
    }
}
