using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Helath : MonoBehaviour
{
    public Slider healthSlider;

    public float hp;

    public Timer temporizador;

    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    private void Update()
    {

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }

        if (hp > 0 && temporizador.restante < 1)
        {
            SceneManager.LoadScene("Victory");
        }

        UpdateHealthUI();

    }

    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;

    }
}
