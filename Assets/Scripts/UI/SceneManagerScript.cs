using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<string, string> users = new Dictionary<string, string>();
    public InputField user;
    public InputField pass;
    void Start()
    {
        users.Add("Monty", "monty");
        users.Add("Monty2", "monty");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadScene(string scene)
    {
        print("OnClick");
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

    }
    public void loadAndValidateScene(string scene)
    {
        if (users.ContainsKey(user.text)){
            if (users[user.text] == pass.text)
            {
            loadScene(scene);
            }
            else{
                Debug.Log("Unauthorized");
            }
        }
        else {
            Debug.Log("Unauthorized");
        }

    }
}
