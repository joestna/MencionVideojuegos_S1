using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string name;
    public string category;
    public int health = 0;

    // Aumenta la vida del jugador sumando el valor que se le pasa por parametro
    public void IncreaseHealth( int masVida )
    {
        health = health + masVida;
        Debug.Log( "La vida del personaje ha aumentado : " + masVida + " puntos." );
    }

    // Disminuye la vida del jugador restando el valor que se le pasa por parametro y si ha muerto lo muestra por consola
    public void DecreaseHealth( int menosVida )
    {
        health = health - menosVida;
        Debug.Log("La vida del personaje ha disminuido : " + menosVida + " puntos.");

        if( !IsAlive() )
        {
            Debug.Log("El personaje esta muerto. ");
        }
    }

    // Indica si el jugador sigue vivo o esta muerto
    public bool IsAlive()
    {
        if( health < 0 )
        {
           return false;
        }

        return true;   
    }

    void Update()
    {

    }
}
