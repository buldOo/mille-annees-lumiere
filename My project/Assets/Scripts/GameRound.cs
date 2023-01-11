using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class GameRound : MonoBehaviour
{
    private bool _isPlayer1Turn = true;
    int _deckCounter = 100;

    public Player player1;
    public Player player2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = new Player() { Name = "Killian", Stack = GeneratePlayerDeck() };
        player2 = new Player() { Name = "Gay", Stack = GeneratePlayerDeck() };
        Debug.Log(player1);
        player1.Stack.ForEach(p => Debug.Log(p));
        Debug.Log(player2);
        player2.Stack.ForEach(p => Debug.Log(p));
    }
    // Update is called once per frame
    void Update()
    {
        _isPlayer1Turn = false;
    }
    
    //Générer une list de 100 cartes
    Card GenerateCard()
    {
        Card card = new();
        
        string[] typeList = {"distance","distance","distance", "shield", "energy", "speed"};
        int[] distanceList = {25, 50, 75, 100};
        int[] speedList = {25, 50, 75};
        
        int typeCount = Random.Range(0, typeList.Length - 1);
        int distanceCount = Random.Range(0, distanceList.Length - 1);
        int speedCount = Random.Range(0, speedList.Length - 1);
        bool isCounter  = (Random.value > 0.5f);
        
        card.Type = typeList[typeCount];
        card.IsCounter = isCounter;
        card.Distance = distanceList[distanceCount];
        card.Speed = speedList[speedCount];

        switch (typeList[typeCount])
        {
            case "distance":
                card.Description = isCounter ? "Avance de la valeur précisée" : "Recule de la valeur précisée";
                break;
            case "shield":
                card.Description = isCounter ? "Réactive le bouclier" : "Détruit le bouclier adverse";
                break;
            case "energy":
                card.Description = isCounter ? "Recharge le vaisseau" : "Endommage l'alimentation du vaisseau adverse";
                break;
            case "speed":
                card.Description = isCounter ? "Moteur à pleine puissance" : "Bride la vitesse adverse";
                break;
        }

        _deckCounter -= 1;

        return card;
    }

    List<Card> GeneratePlayerDeck()
    {
        
        List<Card> stack = new();
        
        for (int i = 0; i <= 6; i++)
        {
            stack.Add(GenerateCard());
        }

        return stack;
    }
}