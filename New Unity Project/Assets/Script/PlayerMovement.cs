using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //usar desde el teclado, velocidad desde unity. tener unos limites,  basado en _fisica_: efecto aceleracion pero mas complejo o en _transform_: simple pero uniforme

    public float playerSpeed;
    public static bool movimiento;
    public GameObject panel;
    public Vector3 desplazamiento;

    void Start()
    {
        movimiento = true;
    }

    void Update()
    {
        // && se cumple ambas condiciones, || una de las dos
        

        //izquierda
        if (movimiento == true)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
            {

                transform.Translate(playerSpeed * Vector3.left);

                //if (transform.position.x < -7)
                //{
                //    //transform.position.Set(5, transform.position.y, transform.position.z);
                //    transform.position = new Vector3(-7, transform.position.y, transform.position.z);
                //}
            }

            //derecha
            if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
            {


                transform.Translate(playerSpeed * Vector3.right);

                //if (transform.position.x > 7)
                //{
                //    //transform.position.Set(5, transform.position.y, transform.position.z);
                //    transform.position = new Vector3(7, transform.position.y, transform.position.z);
                //}
            }
        }
        if (Input.GetKey(KeyCode.P))
        {
            Pausa();
        }
    }

    void Pausa()
    {
        movimiento = false;
        panel.SetActive(true);
    }
    private void OnMouseDown()
    {
        panel.SetActive(false);
        movimiento = true;
    }
}
