using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour
{
    Rigidbody2D miRigidbody;
    SpriteRenderer renderDelSprite;
    Animator animator;
    public float velocidad, velocidadMaxima;
    bool estoyGirado = false;
    public Vector2 fuerzaPrimerSalto, fuerzaSegundoSalto;
    private int numeroDeSaltos = 0;
    public LayerMask mascara;
    public bool sobreElSuelo;
    public Vector3 desplazamiento;
    //public static bool gameOver;
    public GameObject particulas;
    public GameObject particulasWin;
    private AudioSource SonidoSalto;
    public static bool gameWin;


    void Start()
    {

        miRigidbody = GetComponent<Rigidbody2D>();
        renderDelSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        //aqui guardamos los datos de posicion en cada frame
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);

        //Ignoramos todas las capas menos "Suelo"
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + desplazamiento, -Vector2.up, 1f, mascara);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position - desplazamiento, -Vector2.up, 1f, mascara);
        //Rayo paralelo para poder verlo en pantalla
        Debug.DrawLine(transform.position + desplazamiento, (transform.position + desplazamiento) - Vector3.up, Color.red);
        Debug.DrawLine(transform.position - desplazamiento, (transform.position - desplazamiento) - Vector3.up, Color.blue);

        //una u otra
        if (rightHit.collider != null || leftHit.collider != null) //Si estamos chocando con algo
        {
            //print(hit.transform.name); //Dime el nombre del objeto con el que choco
            sobreElSuelo = true;
        }
        else //Si no
        {
            sobreElSuelo = false;
        }


        //Utilizar nuestro componente animator y asignarle al parámetro "Velocidad"
        //la velocidad de nuestro personaje

        //animator.SetFloat("Velocidad", Mathf.Abs(miRigidbody.velocity.x));

        //Si el contador de saltos es 0, significa que no estamos saltando, si es mayor, si saltamos

        if (numeroDeSaltos > 0)
        {
            animator.SetBool("Salto", true);
        }
        else
        {
            animator.SetBool("Salto", false);
        }

        if (gameWin == false)
        {
            if (Mathf.Abs(miRigidbody.velocity.x) < velocidadMaxima)
            {
                miRigidbody.velocity += new Vector2(h, 0);
                print("entro");
            }
            animator.SetFloat("Velocidad", Mathf.Abs(miRigidbody.velocity.x));
            if (Input.GetKey(KeyCode.A)) //andar hacia la izquierda
            {

                //AQUI
                if (!estoyGirado) //estoyGirado == false
                {
                    renderDelSprite.flipX = true; //Activamos la casilla Flip
                    estoyGirado = true;
                }
            }
            if (Input.GetKey(KeyCode.D)) //andar hacia la derecha
            {
                //AQUI
                if (estoyGirado)
                {
                    renderDelSprite.flipX = false; //Desactivamos la casilla Flip
                    estoyGirado = false; //Guardamos nuestra variable girado como false
                }
            }

            //Si pulso la tecla espacio, me voy a mi componente rigidbody y le aplico un impulso hacia arriba

            //Si pulso el espacio Y puedo saltar
            if (Input.GetKeyDown(KeyCode.Space)) //Si pulso el espacio y llevo menos de dos saltos en el aire...
            {
                if (sobreElSuelo)
                {
                    if (numeroDeSaltos == 0) //Si es la primera vez que salta
                    {
                        miRigidbody.velocity += fuerzaPrimerSalto; //Empujamos al personaje hacia la dirección que le pasemos
                                                                   //   SonidoSalto.Play();
                        Debug.Log("primero");
                    }
                    numeroDeSaltos++; //Sumamos 1 al contador de saltos
                }
                else //Ya estamos saltando
                {
                    if (numeroDeSaltos < 2)
                    {
                        if (miRigidbody.velocity.y < 0) //Si estamos cayendo, nos para al jugador justo antes de impulsarlo
                        {
                            miRigidbody.velocity = new Vector2(miRigidbody.velocity.x, 0);
                            Debug.Log("segundo");
                        }
                        if (numeroDeSaltos == 1) //Si es la segunda vez que salta
                        {
                            miRigidbody.velocity += fuerzaSegundoSalto; //Empujamos al personaje hacia la dirección que le pasemos
                            Debug.Log("tercero");
                        }
                        numeroDeSaltos++; //Sumamos 1 al contador de saltos
                        Debug.Log("cuarto");
                    }
                }
            }

            //if (!gameOver || !gameWin)
            //{
            //    if (TimerCountdown.timeless)
            //    {
            //        animator.SetTrigger("Muero");
            //        gameOver = true;
            //        FindObjectOfType<Volumen>().DeathSound();
            //        particulas.SetActive(true);
            //        this.enabled = false;
            //    }

            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Entramos aqui cuando chocamos con el suelo
    {
        numeroDeSaltos = 0; //Ponemos el contador de saltos a 0
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!gameOver || !gameWin)
       // {
            if (collision.transform.CompareTag("enemy"))
            {

                transform.position = new Vector2(-6.992f, -0.588f);
                // animator.SetTrigger("Muero");
                //gameOver = true;
                // FindObjectOfType<Volumen>().DeathSound();
                particulas.SetActive(true);
                //this.enabled = false;
            }
            //if (collision.transform.CompareTag("FinalGem"))
            //{
            //    FindObjectOfType<Volumen>().WinSound();
            //    particulasWin.SetActive(true);
            //    gameWin = true;
            //    gameOver = false;
            //}
        }
        //    if (!gameOver)
        //    {
        //        if (collision.transform.tag == "Key")
        //        {
        //            Destroy(collision.gameObject);
        //            havekey = true;
        //        }
        //    }
        //    if (collision.transform.tag == "Door")
        //    {
        //        if (havekey)
        //        {
        //            print("Level finished");
        //            SceneManager.LoadScene("Menu");
        //        }
        //        else
        //        {
        //            print("U need key");
        //        }
        //    }
        //}
   // }
}
