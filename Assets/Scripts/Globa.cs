using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<GlobalVariables.Instance.pruebas.Count; i+=1)
        {
            print("resultado ");
            print(i);
            print(GlobalVariables.Instance.pruebas[i].GetResultado());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
