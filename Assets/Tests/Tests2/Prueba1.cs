using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Prueba1
{
    // A Test behaves as an ordinary method
    [Test]
    public void Prueba1SimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Prueba1WithEnumeratorPasses()
    {
        SceneManager.LoadScene("pantalla_login2");
        
        
        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual(SceneManager.GetActiveScene().name, "pantalla_login2");
        InputField button = GameObject.Find("InputField").GetComponent<InputField>();
        button.text = "Monty";
        InputField button2 = GameObject.Find("InputField2").GetComponent<InputField>();
        button2.text = "monty";
        Assert.NotNull(button, "");
        yield return new WaitForSeconds(10.0f);
        Assert.AreEqual(SceneManager.GetActiveScene().name, "Prueba_pantalla_inicio");
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
        [UnityTest]
    public IEnumerator Prueba1WithEnumeratorNotPasses()
    {
        SceneManager.LoadScene("pantalla_login2");
        
        
        yield return new WaitForSeconds(1.0f);
        Assert.AreEqual(SceneManager.GetActiveScene().name, "pantalla_login2");
        InputField button = GameObject.Find("InputField").GetComponent<InputField>();
        button.text = "Monty";
        InputField button2 = GameObject.Find("InputField2").GetComponent<InputField>();
        button2.text = "monty2";
        Assert.NotNull(button, "");
        yield return new WaitForSeconds(10.0f);
        Assert.AreNotEqual(SceneManager.GetActiveScene().name, "Prueba_pantalla_inicio");
        yield return null;
    }
}
