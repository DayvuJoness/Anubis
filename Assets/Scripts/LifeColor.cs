using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeColor : MonoBehaviour
{
    private Animator anim;  //Анимация
    public Slider visualhealth;    //Слайдер здоровья
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Color", visualhealth.value);
    }
}
