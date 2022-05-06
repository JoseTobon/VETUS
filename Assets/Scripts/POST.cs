using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class POST : MonoBehaviour
{
    
    void Start()
    {
        string json = generarJSON();
        StartCoroutine(postRequest("localhost:3002/resultados", json));
    }

    IEnumerator postRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    private string generarJSON()
    {
        List<PruebaBalanceSO> data = GlobalVariables.Instance.pruebas;
        int resBalance =0, resVelMarcha=0, resSilla=0, resTotal=0;
        string json = "";
        for (int i = 0; i < data.Count; i++)
        {
            if(data[i].Gettitulo() == "Prueba de balance" && data[i].GetesPrueba())
            {
                resBalance += data[i].GetResultado();
                print("balance" + data[i].GetResultado());
                print("res balance " + resBalance);
            }
            else if (data[i].Gettitulo() == "Prueba de levantarse cinco veces de una silla" && data[i].GetesPrueba())
            {
                resSilla += data[i].GetResultado();
                print("silla" + data[i].GetResultado());
                print("res silla " + resSilla);
            }
            else if (data[i].Gettitulo() == "Prueba de velocidad" && data[i].GetesPrueba())
            {
                resVelMarcha += data[i].GetResultado();
                print("velocidad" + data[i].GetResultado());
                print("res vel " + resVelMarcha);
            }
        }
        resBalance /= 4;
        resTotal = resBalance + resVelMarcha + resSilla;

        json = json + "{\"AplicadorID\":1,\"PacienteID\":3,\"FragilidadTest\":{\"resFatiga\":0,\"resResistencia\":0,\"resDeambulacion\":0,\"resEnfermedades\":0,\"resPeso\":0},";
        json = json + "\"DesempenioTest\":{\"resBalance\":" + resBalance.ToString() + ",\"resVelMarcha\":" + resVelMarcha.ToString() + ",\"resSilla\":" + resSilla.ToString() + ",\"resTotal\":" + resTotal.ToString() + "},";
        json = json + "\"SarcopeniaTest\":{\"resFuerza\":0,\"resCaminar\":0,\"resSilla\":0,\"resEscaleras\":0,\"resCaidas\":0}}";

        return json;
    }
}
