using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    private const float velocidad = 2.0f;
    private const float velocidadTrans = 1000000.0f;

    private float xNueva = 0.0f;
    private float yNueva = 0.0f;

    private bool cursorbool;
    public GameObject canvasOcultar;
    private bool canvasBool;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        cursorbool = true;//Verdadero si esta oculto.
        canvasOcultar.gameObject.SetActive(false);
        canvasBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation();
        camTranslation();
    }

    private void camRotation() 
    {
        xNueva = xNueva + velocidad * Input.GetAxis("Mouse X");
        yNueva = yNueva - velocidad * Input.GetAxis("Mouse Y");
        this.transform.eulerAngles = new Vector3(yNueva, xNueva, 0.0f);
    }

    private void camTranslation() 
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(+velocidadTrans * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-velocidadTrans * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, (-velocidadTrans/2) * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, (velocidadTrans/2) * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, velocidadTrans * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, -velocidadTrans * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Tab)) {
            if (cursorbool)
            {
                Cursor.lockState = CursorLockMode.None;
                cursorbool = false;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorbool = true;
            }
            
        }
        if (Input.GetKey(KeyCode.R)) {
            if (!canvasBool)
            {
                canvasBool = true;
                canvasOcultar.gameObject.SetActive(true);
            }
            else 
            {
                canvasBool = false;
                canvasOcultar.gameObject.SetActive(false);
            }
        }
    }
}
