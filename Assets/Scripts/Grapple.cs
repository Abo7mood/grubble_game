using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    [SerializeField] Vector2[] Scale;
  
    private void Start()
    {
        transform.localScale = Scale[Random.Range(0, Scale.Length)];
    }

    //void Update()
    //{
    //    Debug.Log(PlayerController.instance._canGrupple);


    //}
    //private void OnMouseEnter()
    //{

    //        PlayerController.instance._canGrupple = true;

    //}
    //private void OnMouseExit()
    //{
    //    PlayerController.instance._canGrupple = false;
    //}
}
