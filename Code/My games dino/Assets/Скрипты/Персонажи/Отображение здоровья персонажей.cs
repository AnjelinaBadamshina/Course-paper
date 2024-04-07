using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Отображениездоровьяперсонажей : MonoBehaviour
{
    public Slider slider;
    public Здоровьеперсонажа playerHelth;

   public void Start()
    {
        SetMaxHealth(playerHelth.maxHealth);
    }

    public void Update()
    {
        SetHealth(playerHelth.totalHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }


}
