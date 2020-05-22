using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    Vector2 moveDirection = Vector2.zero;   //Вектор2
    public Rigidbody2D rb; //Физика Анубиса
    public float speed = 5f;   //Скорость
    public float speedVelocity;     //увеличение разгона

    public bool isGrounded = true;    //На земле? Да
    public Transform groundCheck;   //Проверка земли
    private float groundRadius = 0.4f;  //Радиус поиска земли
    public LayerMask whatIsGround;  //Каким объектом является земля
    public string typeOfPlatform;  //Тип платформы, на которой Анубис

    private Animator anim;  //Анимация

    public float directionInput;    //значения кнопок лево/право

    public float life;     //Жизнь
    public Slider visualhealth;    //Слайдер здоровья
    public GameObject respawn;
    public int die;     //0 ничего, 1 лава, 2 падение
    public int reset;
    public float t = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        anim = GetComponent<Animator>();

        reset = PlayerPrefs.GetInt("Reset");

        if (PlayerPrefs.GetFloat("SaverLife") == 0)
        {
            if (reset == 1)
            {
                life = 100;
            }
            if (reset == 0)
            {
                life = 100;
            }
        }
        else if (PlayerPrefs.GetFloat("SaverLife") >= 0)
        {
            if (reset == 1)
            {
                life = 100;
            }
            if (reset == 0)
            {
                life = PlayerPrefs.GetFloat("SaverLife");     //Жизнь
            }
        }
    }

    void OnTriggerStay2D(Collider2D diesp)
    {
        if (diesp.tag == "Die")
        {
            die = 2;
        }
        else
        {
            die = 0;
        }
    }// переписать (при удалении, если упасть в пропасть, то не умирает персонаж  )

    void Update()
    {
        //Debug.Log(typeOfPlatform);
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetFloat("SaverLife", life);
    }

    void FixedUpdate()
    {
        Life();
        if (rb.velocity.x == 0)
        {
            speedVelocity = 1F;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetFloat("Speed", rb.velocity.x);
        anim.SetBool("onGround", isGrounded);
        if (isGrounded)      //стоит на земле
        {
            if (directionInput != 0)
            {
                rb.velocity = new Vector2(speed * directionInput * 60 * Time.deltaTime * speedVelocity, rb.velocity.y);
            }
        }
        else if (!isGrounded)
        {
            if (directionInput != 0)
            {
                rb.velocity = new Vector2(speed * directionInput * 47 * Time.deltaTime, rb.velocity.y);
            }
            if (rb.velocity.y == 0)
            {
                rb.AddForce(1 * Vector2.up * 150000 * Time.fixedDeltaTime);
                isGrounded = false;
            }
        }
    }

    public void Life()
    {
        visualhealth.value = life;
        if (die == 2)
        {
            life = life - 2F;
        }
        if (life <= 0)
        {
            rb.transform.position = respawn.transform.position;
            life = 100;
        }
    }

    public void Jump(bool isJump)
    {
        isJump = isGrounded;

        if (isGrounded)
        {
            rb.AddForce(1 * Vector2.up * 150000 * Time.fixedDeltaTime);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }
}