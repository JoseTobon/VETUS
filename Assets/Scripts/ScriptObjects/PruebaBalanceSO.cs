using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Prueba Balance", fileName = "New Prueba Balance")]
public class PruebaBalanceSO : ScriptableObject
{
    // variables serialized

    
    [SerializeField] bool esPrueba;
    [SerializeField] bool esPruebaCronometrada;

    [TextArea(2, 6)]
    [SerializeField] string instrucciones = "Escribe las instrucciones aqu�:";
    [SerializeField] string titulo;
    [SerializeField] string textoBoton;
    
    [SerializeField] float MAX_TIME;

    [SerializeField] Sprite imagenInstruccion;
    


    private int resultado_;
    private float tiempo_ = 0; 
    private int attempts_ = 0;
    
    public string GetInstrucciones()
    {
        return instrucciones;
    }
    public int GetResultado()
    {
        return resultado_;
    }
    public float GetTiempo()
    {
        return tiempo_;
    }
    public int GetAttempts()
    {
        return attempts_;
    }

    public bool GetesPrueba()
    {
        return esPrueba;
    }
    public bool GetesPruebaCronometrada()
    {
        return esPruebaCronometrada;
    }
    public string Getinstrucciones()
    {
        return instrucciones;
    }
    public string Gettitulo(){
        return titulo;
    }
    public string GettextoBoton()
    {
        return textoBoton;
    }
    
    public float GetMAX_TIME()
    {
        return MAX_TIME;
    }

    public Sprite GetimagenInstruccion()
    {
        return imagenInstruccion;
    } 





    public void SetResultado(int resultado)
    {
        resultado_ = resultado;
    }
    public void SetTiempo(float tiempo)
    {
        tiempo_ = tiempo;
    }
    public void SetAttempts(int attempts)
    {
        attempts_ = attempts;
    }


}
