using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace AvionesGeneral
{
    public class General2 : MonoBehaviour
    {
        public GameObject Spawner;
        public GameObject Tierra;
        private static Dictionary<string, AvionUnity> diccionario;
        private Dictionary<string, GameObject> diccionarioPrefabs;
        public string icao;
        // Start is called before the first frame update
        void Start()
        {
            Tierra = GameObject.FindGameObjectsWithTag("Tierra")[0];
            diccionarioPrefabs = new Dictionary<string, GameObject>();
            diccionario = new Dictionary<string, AvionUnity>();
            diccionario = ProgramUnity.crearAviones(diccionario);
            if (diccionario.Count != 0) 
            {
                actualizarPrefabsAvionesDiccionario();
                StartCoroutine("actualizarAviones");
            }
        }
        private IEnumerator actualizarAviones()
        {
            Vector3 anterior = new Vector3(0, 0, 0);
            Vector3 actual = new Vector3(0, 0, 0);
            Vector3 referencia;
            Vector3 normal;
            Vector3 proyeccionReferencia;
            Quaternion q1;
            Quaternion q2;
            GameObject avion;
            while (true)
            {
                diccionario = ProgramUnity.crearAviones(diccionario);
                foreach (KeyValuePair<string, GameObject> clave in diccionarioPrefabs)
                {
                    avion = diccionarioPrefabs[clave.Key];
                    anterior = avion.transform.position;
                    avion.transform.position = new Vector3((float)diccionario[clave.Key].getXGlobal(), (float)diccionario[clave.Key].getYGlobal(), (float)diccionario[clave.Key].getZGlobal());
                    normal = avion.transform.position;
                    referencia = (avion.transform.position - anterior);
                    normal = normal.normalized;
                    q1 = Quaternion.FromToRotation(Vector3.up, normal);
                    avion.transform.rotation = q1;
                    proyeccionReferencia = Vector3.ProjectOnPlane(referencia, normal);
                    q2 = Quaternion.FromToRotation(avion.transform.right, proyeccionReferencia);
                    avion.transform.rotation = q2*avion.transform.rotation;
                }
                yield return new WaitForSeconds(3f);
            }
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
        public static Dictionary<string, AvionUnity> getDiccionario() 
        {
            return diccionario;
        }
        private void pythonEngine()
        {
            Process p = new Process();
            try
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = @"D:\Yeray\Escritorio\TFG\TFG_UNITY\TFG\Assets\Resources\Prueba.exe";
                p.StartInfo.WorkingDirectory = @"D:\Yeray\Escritorio\TFG\TFG_UNITY\TFG\Assets\Resources";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.EnableRaisingEvents = true;
                p.Start();
                p.WaitForExit();
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError("El error al abrir el fichero " + e.Message);
            }
        }
    }
}
