using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoresystem : MonoBehaviour
{
  public static  Scoresystem instance;
    public float Score;
    [SerializeField] TextMeshProUGUI _scoreTxt;
    [SerializeField] GameObject MutliplierObject;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        _scoreTxt.text = Score.ToString("0");

        if (PlayerController.instance.isMultiplier)
        {
            MutliplierObject.SetActive(true);
        }else
            MutliplierObject.SetActive(false);
    }

}
