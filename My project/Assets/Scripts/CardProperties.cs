using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardProperties : MonoBehaviour
{
    public TMP_Text textDescr;
    
    // Start is called before the first frame update
    void Start()
    {
        textDescr.text = "test card descr";
        var player1Hand = GameObject.Find("GameManager").GetComponent<GameRound>().player1.Stack;
        Debug.Log("foreach :");
        player1Hand.ForEach(card =>
        {
            Debug.Log(card.Description);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
