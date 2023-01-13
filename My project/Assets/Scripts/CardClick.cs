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

    public bool PlayerOneEnergy = true;
    public bool PlayerTwoEnergy = true;
    public bool PlayerEnergy = true;
    public bool OtherPlayerEnergy = true;

    // public bool PlayerOneShield = false;
    // public bool PlayerTwoShield = false;
    public bool PlayerShield = false;
    public bool OtherPlayerShield = false;
    public bool PlayerOneTurn = true;
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
            PlayerOneTurn = true;
            PlayerEnergy = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy;
            OtherPlayerEnergy = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            PlayerShield = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield;
            OtherPlayerShield = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            Debug.Log("it's player one");
        }
        else if(transform.parent.tag == "playerTwo")
        {
            player = playerTwo;
            otherPlayer = playerOne;
            PlayerOneTurn = false;
            PlayerEnergy = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            OtherPlayerEnergy = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy;
            PlayerShield = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            OtherPlayerShield = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield;
            Debug.Log("it's player two");
        }

        switch (CardType.text)
        {
            case "Carte Distance":
                Debug.Log("carte distance");
                var deplacementAvant = float.Parse(CardDistance.text)/10;
                var deplacementArrière = float.Parse(CardDistance.text)/-10;
                if (CardDescr.text == "Avancez de : ") {
                    if (PlayerEnergy) {
                        if (player.transform.position.x + deplacementAvant <= finishLine.transform.position.x)
                        {
                            player.transform.position = new Vector2(player.transform.position.x + deplacementAvant, player.transform.position.y);
                        } else {
                            player.transform.position = new Vector2(finishLine.transform.position.x, player.transform.position.y);
                        }
                    } else {
                        Debug.Log("Vaisseau endommagé impossible d'avancer");
                    }
                } else {
                    if (OtherPlayerEnergy) {
                        if (otherPlayer.transform.position.x + deplacementArrière >= StartLine.transform.position.x)
                        {
                            otherPlayer.transform.position = new Vector2(otherPlayer.transform.position.x + deplacementArrière, otherPlayer.transform.position.y);
                        } else {
                            otherPlayer.transform.position = new Vector2(StartLine.transform.position.x, otherPlayer.transform.position.y);
                        }
                    }  else {
                        Debug.Log("Vaisseau adverse endommagé impossible de le faire reculer");
                    }
                }
                break;
            case "Carte Speed":
                Debug.Log("carte speed");
                break;
            case "Carte Shield":
                Debug.Log("carte shield");
                if (CardDescr.text == "Detruit le bouclier du joueur adverse"){
                    Debug.Log("Carte Malus Shield");
                    if (OtherPlayerShield == true){
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield = false;
                        } else {
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield = false;
                        }
                    } else {
                        Debug.Log("Le joueur adverse n'a pas de bouclier actif");
                    }
                } else {
                    Debug.Log("Carte Bonus Shield");
                    if (PlayerOneTurn){
                        GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield = true;
                    } else {
                        GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield = true;
                    }
                }
                break;
            case "Carte Energy":
                Debug.Log("carte energy");
                if (CardDescr.text == "Endommage l'alimentation du vaisseau adverse"){
                    if(OtherPlayerShield == false) {
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoEnergy = false;
                        } else {
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy = false;
                        }
                    } else {
                        Debug.Log("Impossible d'endommager le vaisseau ennemi car il a un bouclier d'actif");
                    }
                } else {
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy = true;
                        } else {
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoEnergy = true;
                        }
                }
                break;
        }
    }
}
