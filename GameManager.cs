using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Prefab para crear a los luchadores
    public GameObject luchadorPrefab;

    // lista que almacena los personajes (vivos y muertos)
    List<GameObject> listaLuchadores = new List<GameObject>();
    // Lista que almacena los personajes que han muerto
    List<GameObject> deaths = new List<GameObject>();

    void Start()
    {
        int cantLuchadoresCrear = 5;

        // Valores para inicializar a los luchadores
        string[,] informacionLuchadores = new string[2, 5] { { "Scorpion", "Kano",       "Sonya",    "Johnny Cage", "Sub - Zero" },
                                                             { "Ninja",    "Mercenario", "Teniente", "Actor",       "Ninja" }};

        // Inicializa 5 luchadores con sus respectivos datos
        InitFighters(informacionLuchadores, cantLuchadoresCrear);

        // Muestra el personaje con mas vida de la lista listaLuchadores
        Fighter luchador = PersonajeConMasVida().GetComponent<Fighter>();
        Debug.Log("Personaje con mas vida : " + luchador.name);

        // Anyade los luchadores muertos a la lista deaths
        AnyadirPersonajesMuertos();

        // Muestra los personajes que han muerto (anyadidos a la lista deaths)
        MostrarPersonajesMuertos();



        /*
        
        Ejercicio 12 : No se como notifiar al GameManager que el jugador ha muerto

        */


    }

    private void InitFighters(string[,] informacionLuchadores, int cantLuchadoresCrear)
    {
        for (int i = 0; i < cantLuchadoresCrear; i++)
        {
            Fighter luchador = new Fighter();
            GameObject luchadorUI = Instantiate(luchadorPrefab, new Vector3(2 * i, 0, 0), Quaternion.identity);

            luchador = luchadorUI.GetComponent<Fighter>();

            luchador.name = informacionLuchadores[0, i];
            luchador.category = informacionLuchadores[1, i];

            // Inicializa la vida de los luchadores entre 80 y 90 puntos
            luchador.health = Random.Range(80, 100); 

            listaLuchadores.Add(luchadorUI);
        }
    }

    public GameObject PersonajeConMasVida()
    {
        int contador;
        int i;

        for ( i = 0; i < listaLuchadores.Count; i++)
        {
            contador = 0;

            for (int j = 0; j < listaLuchadores.Count; j++)
            {
                if( listaLuchadores[i].GetComponent<Fighter>().health >= listaLuchadores[j].GetComponent<Fighter>().health )
                {
                    contador++;
                }

                if( contador == listaLuchadores.Count )
                {
                    break;
                }
            }

            if (contador == listaLuchadores.Count)
            {
                break;
            }
        }

        return listaLuchadores[i];
    }

    public void AnyadirPersonajesMuertos()
    {
        foreach( GameObject luchador in listaLuchadores )
        {
            if( !luchador.GetComponent<Fighter>().IsAlive() )
            {
                deaths.Add(luchador);
            }
        }
    }

    public void MostrarPersonajesMuertos()
    {
        Debug.Log( "> Personajes Muertos : " );

        foreach( GameObject luchador in deaths )
        {
            Debug.Log( luchador.GetComponent<Fighter>().name);
        }
    }

    void Update()
    {
        
    }
}
