using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Changeables;
    public GameObject[] Players;
    public GameObject[] Blacks;
    public GameObject[] Whites;
    public GameObject[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        Changeables = GameObject.FindGameObjectsWithTag("Changeable");
        Players = GameObject.FindGameObjectsWithTag("Player");
        Blacks = GameObject.FindGameObjectsWithTag("Black");
        Whites = GameObject.FindGameObjectsWithTag("White");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {                        
         if (Input.GetKeyDown(KeyCode.Q))
         {
            int amount = 0;

            for (int i = 0; i < Changeables.Length; i++)
            {
                if (Changeables[i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    amount++;
                }

                if (Changeables[i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    amount--;
                }

                if (amount >= 1)
                {
                    Changeables[i].GetComponent<SpriteRenderer>().color = Color.black;

                    int Yop = 0;

                    for (int t = 0; t < Blacks.Length; t++)
                    {
                        Yop++;

                        if (Yop >= 1)
                        {
                            Blacks[t].SetActive(false);
                        }
                    }

                    for (int t = 0; t < Whites.Length; t++)
                    {
                        Yop++;

                        if (Yop >= 1)
                        {
                            Whites[t].SetActive(true);
                        }
                    }
                }

                if (amount <= 0)
                {
                    Changeables[i].GetComponent<SpriteRenderer>().color = Color.white;

                    int Yop = 0;

                    for (int t = 0; t < Blacks.Length; t++)
                    {
                        Yop++;

                        if (Yop >= 1)
                        {
                            Blacks[t].SetActive(true);
                        }
                    }

                    for (int t = 0; t < Whites.Length; t++)
                    {
                        Yop++;

                        if (Yop >= 1)
                        {
                            Whites[t].SetActive(false);
                        }
                    }
                }
            }

            for (int i = 0; i < Players.Length; i++)
            {
                int boop = 0;

                if (Players[i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    boop++;
                }
                if (Players[i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    boop--;
                }

                if (boop >= 1)
                {
                    Players[i].GetComponent<SpriteRenderer>().color = Color.black;
                }

                if (boop <= 0)
                {
                    Players[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            for (int i = 0; i < Enemies.Length; i++)
            {
                int boop = 0;

                if (Enemies[i].GetComponent<SpriteRenderer>().color == Color.white)
                {
                    boop++;
                }
                if (Enemies[i].GetComponent<SpriteRenderer>().color == Color.black)
                {
                    boop--;
                }

                if (boop >= 1)
                {
                    Enemies[i].GetComponent<SpriteRenderer>().color = Color.black;
                }

                if (boop <= 0)
                {
                    Enemies[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}
