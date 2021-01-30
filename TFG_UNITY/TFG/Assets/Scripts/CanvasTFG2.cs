using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace AvionesGeneral {

    public class CanvasTFG2 : MonoBehaviour
    {
        private Dictionary<string, AvionUnity> diccionario;
        private AvionUnity avion;
        public GameObject canvas;
        public GameObject canvas2;
        public Camera camara;
        private int numAviones;
        void Update()
        {
            diccionario = General2.getDiccionario();
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = camara.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (objectHit.gameObject.tag.Equals("Avion"))
                    {

                        diccionario = General2.getDiccionario();
                        diccionario.TryGetValue(objectHit.gameObject.name, out avion);
                        canvas.transform.GetChild(1).GetComponent<TMP_Text>().SetText(avion.getIcao());
                        canvas.transform.GetChild(3).GetComponent<TMP_Text>().SetText(avion.getPais());
                        canvas.transform.GetChild(5).GetComponent<TMP_Text>().SetText(avion.getLat().ToString());
                        canvas.transform.GetChild(7).GetComponent<TMP_Text>().SetText(avion.getLong().ToString());
                        canvas.transform.GetChild(9).GetComponent<TMP_Text>().SetText(avion.getAlt().ToString() + " m");
                        canvas.transform.GetChild(11).GetComponent<TMP_Text>().SetText(avion.getVelocidad().ToString() + " m/s");
                        canvas.transform.GetChild(13).GetComponent<TMP_Text>().SetText(avion.getInlinacion().ToString());
                    }
                }
            }
            numAviones = diccionario.Count;
            canvas2.transform.GetChild(1).GetComponent<TMP_Text>().SetText(numAviones.ToString());
        }
    }





}
