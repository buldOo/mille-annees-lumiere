using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardClick : MonoBehaviour
{

    public TMP_Text CardType;
    public TMP_Text CardDescr;
    public TMP_Text CardDistance;

    public GameObject playerOne;
    public GameObject playerTwo;
    private GameObject player;
    private GameObject otherPlayer;
    public GameObject finishLine;

    public GameObject StartLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {

        if (transform.parent.tag == "playerOne")
        {
            player = playerOne;
            otherPlayer = playerTwo;
            Debug.Log("it's player one");
        }
        else if(transform.parent.tag == "playerTwo")
        {
            player = playerTwo;
            otherPlayer = playerOne;
            Debug.Log("it's player two");
        }

        switch (CardType.text)
        {
            case "Carte Distance":
                Debug.Log("carte distance");
                var deplacementAvant = float.Parse(CardDistance.text)/10;
                var deplacementArrière = float.Parse(CardDistance.text)/-10;
                if (CardDescr.text == "Avancez de : ") {
                    if (player.transform.position.x + deplacementAvant <= finishLine.transform.position.x)
                    {
                        player.transform.position = new Vector2(player.transform.position.x + deplacementAvant, player.transform.position.y);
                    } else {
                        player.transform.position = new Vector2(finishLine.transform.position.x, player.transform.position.y);
                    }
                } else {
                    if (otherPlayer.transform.position.x + deplacementArrière >= StartLine.transform.position.x)
                    {
                        otherPlayer.transform.position = new Vector2(otherPlayer.transform.position.x + deplacementArrière, otherPlayer.transform.position.y);
                    } else {
                        otherPlayer.transform.position = new Vector2(StartLine.transform.position.x, otherPlayer.transform.position.y);
                    }
                }
                break;
            case "Carte Speed":
                Debug.Log("carte speed");
                break;
            case "Carte Shield":
                Debug.Log("carte shield");
                break;
            case "Carte Energy":
                Debug.Log("carte energy");
                break;
        }
    }
}
