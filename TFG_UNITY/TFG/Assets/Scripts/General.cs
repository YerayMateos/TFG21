using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace AvionesGeneral
{
    public class General : MonoBehaviour
    {
        public GameObject Spawner;
        public GameObject Tierra;
        private static Dictionary<string, AvionUnity> diccionario;
        private Dictionary<string, GameObject> diccionarioPrefabs;
        private int bucle;
        private int contador;
        private string path;
        public string icao;
        void Start()
        {
            Tierra = GameObject.FindGameObjectsWithTag("Tierra")[0];
            diccionarioPrefabs = new Dictionary<string, GameObject>();
            diccionario = new Dictionary<string, AvionUnity>();
            diccionario = ProgramUnity.crearAvionesSimulacionDiccionario(@"D:\Yeray\Escritorio\TFG\opensky-api-master\python\DatabaseAviones\resultado0.txt", diccionario);
            actualizarPrefabsAvionesDiccionario();
            bucle = 1;
        }
        void Update()
        {
            if (bucle > 0 && bucle < 411)
            {
                if (contador == 70)
                {
                    path = @"D:\Yeray\Escritorio\TFG\opensky-api-master\python\DatabaseAviones\resultado" + bucle + ".txt";
                    actualizarPrefabsAvionesDiccionario();
                    actualizarAvionesSimulacionDiccionario(path);
                    bucle = bucle + 1;
                    contador = 0;
                }
            }
            else 
            {
                UnityEngine.Debug.Log("FIN");                
            } 
            contador = contador + 1;
        }
        private void actualizarPrefabsAvionesDiccionario()
        {
            foreach (KeyValuePair<string, AvionUnity> clave in diccionario)
            {
                if (!diccionarioPrefabs.ContainsKey(clave.Key))
                {
                    GameObject g = (GameObject)Instantiate(Spawner, new Vector3((float)(diccionario[clave.Key].getXGlobal()), (float)diccionario[clave.Key].getYGlobal(), (float)diccionario[clave.Key].getZGlobal()), Quaternion.Euler(new Vector3(0, 0, 0)));
                    g.name = diccionario[clave.Key].getIcao();
                    diccionarioPrefabs.Add(clave.Key, g);
                } 
            }
        }
        private void actualizarAvionesSimulacionDiccionario(string path) 
        {
            Vector3 anterior = new Vector3(0, 0, 0);
            Vector3 actual = new Vector3(0, 0, 0);
            Vector3 referencia;
            Vector3 normal;
            Vector3 proyeccionReferencia;
            Quaternion q1;
            Quaternion q2;
            GameObject avion;
            GameObject aux;
            diccionario = ProgramUnity.crearAvionesSimulacionDiccionario(path, diccionario);

            foreach(KeyValuePair<string, GameObject> clave in diccionarioPrefabs) 
            {
                avion = diccionarioPrefabs[clave.Key];
                anterior = avion.transform.position;
                avion.transform.position = new Vector3((float)diccionario[clave.Key].getXGlobal(), (float)diccionario[clave.Key].getYGlobal(), (float)diccionario[clave.Key].getZGlobal());
                
                normal = avion.transform.position; 
                referencia = (avion.transform.position - anterior);
                normal = normal.normalized;
                if (Vector3.Magnitude(referencia) > 1000)
                {
                    referencia = referencia.normalized;
                    q1 = Quaternion.FromToRotation(Vector3.up, normal);
                    avion.transform.rotation = q1;

                    proyeccionReferencia = Vector3.ProjectOnPlane(referencia, normal);
                    q2 = Quaternion.FromToRotation(avion.transform.right, proyeccionReferencia);
                    avion.transform.rotation = q2 * avion.transform.rotation;
                }
                if (diccionario[clave.Key].getAlt() < 100.0f) 
                {
                    diccionarioPrefabs.TryGetValue(clave.Key, out aux);
                    aux.SetActive(false);
                }
             }
         }

        public static Dictionary<string, AvionUnity> getDiccionario() 
        {
            return diccionario;
        }
    }
}
