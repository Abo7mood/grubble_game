using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeTxt;
    [HideInInspector] public float t;
    private float startTime;
    private void Start() => startTime = Time.time;


    private void Update()
    {
         t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TimeTxt.text = minutes + ":" + seconds;
    }
}
