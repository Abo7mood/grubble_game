using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Kill : MonoBehaviour
{
    [SerializeField] float _force;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
           
            PlayerController.instance.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            PlayerController.instance.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force,ForceMode2D.Impulse);
            PlayerController.instance.canMultiplier = false;
            PlayerController.instance.isMultiplier = false;
        }
         if (collision.name=="Win")
        {
            PlayerController.instance.Win();
        }
        else { return; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
         PlayerController.instance.canMultiplier = true;
       
    }
}
