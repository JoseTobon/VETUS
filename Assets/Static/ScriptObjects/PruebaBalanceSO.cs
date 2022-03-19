using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Prueba Balance", fileName = "New Prueba Balance")]
public class PruebaBalanceSO : ScriptableObject
{
    // variables serialized

    [TextArea(2, 6)]
    [SerializeField] string instrucciones = "Escribe las instrucciones aquí:";
    [SerializeField] Image imagenInstruccion;
    [SerializeField] string[] opciones = new string[3];
    [SerializeField] string tipoPrueba = "Escribe el tipo de prueba";


    public string GetInstrucciones()
    {
        return instrucciones;
    }

}
