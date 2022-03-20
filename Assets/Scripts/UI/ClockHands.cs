using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ClockHands : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ClockHand;
    public Text timeText;
    public Text Titulo;
    public Text descripcion;
    public Image Instrucciones;
    public GameObject[] botones;
    public Button continuar;
    public Image reloj;
    public float MAX_TIME;
    private float currentTime = 0;
    private string[] opciones_en_prueba = {"Detener", "Reiniciar", "Iniciar"};
    // private List<PruebaBalanceSO> pruebas = GlobalVariables.Instance.pruebas ;
    private int index_prueba;
    private bool pausa = false;
    void Start()
    {
        print(GlobalVariables.Instance.pruebas);
        // print(pruebas);
        ClockHand = reloj.transform;
        RenderTemplate();
    }

    private void RenderTemplate()
    {
        pausa = true;
        currentTime = 0;
        PruebaBalanceSO prueba_actual =  GlobalVariables.Instance.pruebas[index_prueba];
        Titulo.text = prueba_actual.Gettitulo();
        descripcion.text = prueba_actual.Getinstrucciones();
        Instrucciones.sprite= prueba_actual.GetimagenInstruccion();
        MAX_TIME = prueba_actual.GetMAX_TIME();
        ConfigureButtons(prueba_actual);
        
    }
    private void ConfigureButtons(PruebaBalanceSO prueba_actual)
    {
        
        if (prueba_actual.GetesPrueba()){
            for (int i = 0; i<botones.Length; i+=1)
            {
                botones[i].SetActive(true);
                botones[i].GetComponentInChildren<Text>().text = opciones_en_prueba[i];
            }
            
           
        }
        else
        {
            for (int i = 0; i<botones.Length; i+=1)
            {
                botones[i].SetActive(false);
            }
           
        }
        
    }
    public void OnDetener()
    {
        pausa = true;
    }
    public void OnReiniciar()
    {
        
        currentTime = 0;
        TimeHandler();
        pausa= true;
    }
    public void OnIniciar()
    {
        pausa = false;
    }
    
    public void OnContinue()
    {
        if (index_prueba <  GlobalVariables.Instance.pruebas.Count-1)
        {
              
              
              index_prueba+=1;
              RenderTemplate();
        } 
        else
        {
            SceneManager.LoadScene("Final", LoadSceneMode.Single);
        }
          

    }
    private void SaveResults()
    {
        GlobalVariables.Instance.pruebas[index_prueba].SetTiempo(currentTime);

        GlobalVariables.Instance.pruebas[index_prueba].SetResultado(1);
        
              
    }
    void TimeHandler()
    {
        ClockHand.eulerAngles = new Vector3(0, 0, -currentTime * 360f);
        
        var timeToDisplay = currentTime;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (!pausa)
        {
            if (currentTime < MAX_TIME)
            {
                currentTime+= Time.deltaTime;
            }
            else
            {
                currentTime = MAX_TIME;
            }
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        TimeHandler();
    }
}
