using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : Singleton<GameManager> //Clase estática
{
    public int estrellas;
    public int vida;
    public Text estrellasText;
    public Text vidaText;
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true; 
        estrellas = 0;
        vida = 10;
        estrellasText.text = estrellas.ToString(); 
        vidaText.text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVida(int extravida)
    {
        if (vida > 0)
        {
            vida += extravida;
            if (vida <= 3)
            {
                vidaText.color = Color.red;
            }
            vidaText.text = vida.ToString();
        } else if(vida <= 0)
        {
            alive = false;
            vidaText.color= Color.red;
            vidaText.text = "Game Over"; 
        }
        
    }

    public void UpdateEstrellas()
    {
        estrellas++;
        if(estrellas == 3)
        {
            alive = false; 
            estrellasText.color = Color.green;
            estrellasText.text = "Winner!!"; 
        }
        else
        {
            estrellasText.text = estrellas.ToString();
        }
        
    }
}
