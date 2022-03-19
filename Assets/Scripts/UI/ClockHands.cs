using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockHands : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ClockHand;
    public Text timeText;
    public Image reloj;

    public PruebaBalanceSO[] pruebas;
    void Start()
    {
        ClockHand = reloj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ClockHand.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 90f);
        var timeToDisplay = Time.realtimeSinceStartup;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
