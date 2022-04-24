using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Prueba Balance", fileName = "New Prueba Balance")]
public class Users : ScriptableObject
{
    // variables serialized

    
    [SerializeField] Dictionary<string, string> users = new Dictionary<string, string>();

    public Dictionary<string, string> getUsers()
    {
        return users;
    }

    

}
