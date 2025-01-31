using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{


    #region Constructer
    public static PlayerController instance;
    [Header("Constructer")]
    [SerializeField] Camera maincamera;
    Rigidbody2D rb;
    Animator anim;
    Timer _time;
    [SerializeField] Collider2D c;
    [Header("Follow")]
    [SerializeField] Transform background;
    [SerializeField] Transform Camera;
    [SerializeField] Transform Dad;
    [SerializeField] Transform WinObject;
    #endregion
    #region float&int
    [SerializeField] float offessetx;
    float movX;
    [Header("Movement")]
    [SerializeField] float PlayerSpeed;
    float maxTransform;
    [SerializeField] float transformSpeed;
    [SerializeField] float Multiplier;
    [SerializeField] float _scoreMultiplier;
    private float increasedMutliplier=0;
    [SerializeField] float _value;
    float distance;
    float _RealDistance;
    float _RRealDistance;
    float random;
    Scene scene;
    private float _score=3000;
    #endregion
    #region bool
    [HideInInspector] public bool isMultiplier;
    [HideInInspector] public bool canMultiplier;
    #endregion


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        _time = FindObjectOfType<Timer>().GetComponent<Timer>();
    }
    private void Start()
    {
        canMultiplier = true;
  
        _RealDistance = 10000;
    }

    void Update()=> Call();
       
    private void Call()
    {
        Playermove();
        Follow();
        Animations();
        MultiplierVoid();
        Distance();
        Score();
    }
    private void Distance()
    {
        distance = Vector3.Distance(transform.position, WinObject.position);
        _RRealDistance = distance;
        random = _RealDistance - distance;

        if (_RealDistance > distance)
        {
            _RealDistance = distance;
            Scoresystem.instance.Score += transformSpeed * Multiplier * rb.velocity.x;
        }
    }
    private void MultiplierVoid()
    {
        if (canMultiplier)
            increasedMutliplier += Time.deltaTime * _value;
        else
            increasedMutliplier = 0;

        if (increasedMutliplier >= 5)
            isMultiplier = true;
        else
            isMultiplier = false;

        if (isMultiplier)
            Multiplier = 2;
        else
            Multiplier = 1;
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * PlayerSpeed, ForceMode2D.Impulse);
    }
    void Follow()
    {
        background.transform.position = new Vector3(transform.position.x + offessetx,
            transform.position.y, background.transform.position.z);
        Dad.transform.position = new Vector3(transform.position.x,
          Dad.transform.position.y, Dad.transform.position.z);

    }
    private void Score()
    {
      
        _score -= Time.deltaTime * _scoreMultiplier;
    }
    void Playermove()
    {
        if (rb.velocity.x < 0)
            anim.GetComponent<SpriteRenderer>().flipX = false;
        else if (rb.velocity.x > 0)
            anim.GetComponent<SpriteRenderer>().flipX = true;
    }
    void Animations()
    {
        if (rb.velocity.y <= 0 && rb.velocity.y > -0.5f)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);


        }
        if (rb.velocity.y > 0.1f)
            anim.SetBool("IsJumping", true);

        if (rb.velocity.y < -1.8)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", true);
        }
        if (rb.velocity.y >= 0.1f)
            anim.SetBool("IsFalling", false);

    }
    public void Win()
    {
        if(scene.buildIndex==1)
        SceneManager.LoadScene(scene.buildIndex+1);
        else
            SceneManager.LoadScene(0);
    }

}
