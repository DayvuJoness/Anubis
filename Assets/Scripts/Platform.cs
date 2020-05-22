using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public string typeOfPlatform;  //Тип платформы
    public float speedMax;  //Ускорение/замедление max X
    public float speedMin;  //Ускорение/замедление min X
    public float timeBoost;  //Время периода ускорения/замедления
    public float countOfSpeedChange;  //На сколько за один период
    public float countOfLifeChange;  //Уменьшение/восстановление жизни
    public PlayerControll player;  //Анубис
    private Coroutine stop;
    private Coroutine stopA;
    private float oldMass;  //Старая масса Анубиса
    public bool allowBadJump = false;  //Разрешить плохой прыжок

    void Start()
    {
        player = GameObject.Find("Anubis").GetComponent<PlayerControll>();
        oldMass = player.rb.mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)  //Анубис соприкасается с чем-либо 
    {
        player.typeOfPlatform = this.typeOfPlatform;
        //Debug.Log(player.typeOfPlatform);
        stop = StartCoroutine(timeLife());  //Запуск корутины
        if (timeBoost != 0)  //Если время ускорения не равно 0
        {
            stopA = StartCoroutine(speedA());  //Запускается корутина
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    private void OnCollisionExit2D(Collision2D collision)  //Анубис отрывается от чего-либо
    {
        StopCoroutine(stop);  //Остановка корутины
        if (timeBoost != 0)  //Проверка времени (если timeBoost == 0 значит корутина изменения скорости не запускалась)
        {
            StopCoroutine(stopA);  //Остановка
            player.speedVelocity = 1f;
            player.rb.mass = oldMass;
        }
    }

    IEnumerator timeLife()  //Корутина жизни
    {
        while (true)
        {
            player.life = player.life + countOfLifeChange;  //Изменение параметра жизни 

            if (player.life > 100)  //Если жизнь больше 100, то жизнь равна 100
            {
                player.life = 100;
            }
            yield return new WaitForSeconds(0.01f);  //Промежуток выполнения кода
        }
    }


    IEnumerator speedA()  //Корутина скорости
    {
        while (true)
        {
            if (speedMax > speedMin)
            {
                if (player.directionInput != 0 /*Проверка направления*/ && player.speedVelocity < speedMax /*Проверка на max значение*/ && player.speedVelocity + countOfSpeedChange > speedMin /*Проверка на min значение*/ )
                {
                    player.speedVelocity += countOfSpeedChange;  //Изменение параметра ускорения
                }
                else if (player.directionInput == 0)
                {
                    player.speedVelocity = 1f;
                }
            }
            else if (speedMax < speedMin)
            {
                if (player.directionInput != 0 && player.speedVelocity > speedMax)
                {
                    player.speedVelocity -= countOfSpeedChange;  //Изменение параметра ускорения
                }
                else if (player.directionInput == 0)
                {
                    player.speedVelocity = 1f;
                }
            }
            if (allowBadJump)
            {
                player.rb.mass = 2.5f;
            }
            yield return new WaitForSeconds(timeBoost);  //Промежуток выполнения кода
        }
    }
}
