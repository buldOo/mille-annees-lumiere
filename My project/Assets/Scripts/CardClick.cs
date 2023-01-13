using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardClick : MonoBehaviour
{

    public TMP_Text CardType;
    public TMP_Text CardDescr;
    public TMP_Text CardDistance;
    public TMP_Text CardSpeed;
    public TMP_Text InGameConsole;

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

    public bool PlayerShield = true;
    public bool OtherPlayerShield = true;

    public float PlayerSpeedLimit = 100f;
    public float OtherPlayerSpeedLimit = 100f;
    
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
            OtherPlayerEnergy = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoEnergy;
            PlayerShield = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield;
            OtherPlayerShield = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            PlayerSpeedLimit = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneSpeedLimit;
            OtherPlayerSpeedLimit = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoSpeedLimit;

            Debug.Log("it's player one");
        }
        else if(transform.parent.tag == "playerTwo")
        {
            player = playerTwo;
            otherPlayer = playerOne;
            PlayerOneTurn = false;
            PlayerEnergy = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoEnergy;
            OtherPlayerEnergy = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy;
            PlayerShield = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield;
            OtherPlayerShield = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield;
            PlayerSpeedLimit = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoSpeedLimit;
            OtherPlayerSpeedLimit = GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneSpeedLimit;
            Debug.Log("it's player two");
        }

        switch (CardType.text)
        {
            case "Carte Distance":
                if (CardDescr.text == "Avancez de : ") {
                    if (PlayerEnergy) {
                        var deplacementAvant = float.Parse(CardDistance.text)/10;
                        if (deplacementAvant <= PlayerSpeedLimit){
                            if (player.transform.position.x + deplacementAvant <= finishLine.transform.position.x)
                            {
                                player.transform.position = new Vector2(player.transform.position.x + deplacementAvant, player.transform.position.y);
                            } else {
                                player.transform.position = new Vector2(finishLine.transform.position.x, player.transform.position.y);
                            }
                        } else {
                            InGameConsole.text = "Votre vaisseau est bridé et ne peux pas avancer de cette distance";
                        }
                    } else {
                        InGameConsole.text = "Votre vaisseau est endommagé, impossible d'avancer";
                    }
                } else {
                    if (OtherPlayerEnergy) {
                        var deplacementArrière = float.Parse(CardDistance.text)/-10;
                        if (otherPlayer.transform.position.x + deplacementArrière >= StartLine.transform.position.x)
                        {
                            otherPlayer.transform.position = new Vector2(otherPlayer.transform.position.x + deplacementArrière, otherPlayer.transform.position.y);
                        } else {
                            otherPlayer.transform.position = new Vector2(StartLine.transform.position.x, otherPlayer.transform.position.y);
                        }
                    }  else {
                        InGameConsole.text = "Le vaiseau adverse est endommagé, impossible de le faire reculer";
                    }
                }
                break;
            case "Carte Speed":
                if (CardDescr.text == "Bride la vitesse du joueur adverse a :"){
                    if(OtherPlayerShield == false) {
                        var speedLimit = float.Parse(CardSpeed.text)/10;
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoSpeedLimit = speedLimit;
                        } else {
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneSpeedLimit = speedLimit;
                        }
                    } else {
                        InGameConsole.text = "Impossible de brider les deplacements du vaisseau ennemi car il a un bouclier d'actif";
                    }
                } else {
                    if (PlayerOneTurn){
                        GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneSpeedLimit = 100f;
                    } else {
                        GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoSpeedLimit = 100f;
                    }
                }
                break;
            case "Carte Shield":
                if (CardDescr.text == "Detruit le bouclier du joueur adverse"){
                    if (OtherPlayerShield == true){
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield = false;
                        } else {
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield = false;
                        }
                    } else {
                        InGameConsole.text = "Le joueur adverse n'a pas de bouclier actif";
                    }
                } else {
                    if (PlayerOneTurn){
                        GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneShield = true;
                    } else {
                        GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoShield = true;
                    }
                }
                break;
            case "Carte Energy":
                if (CardDescr.text == "Endommage l'alimentation du vaisseau adverse"){
                    if(OtherPlayerShield == false) {
                        if (PlayerOneTurn){
                            GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>().PlayerTwoEnergy = false;
                        } else {
                            GameObject.Find("PlayerOne").GetComponent<PlayerOne>().PlayerOneEnergy = false;
                        }
                    } else {
                        InGameConsole.text = "Impossible d'endommager le vaisseau ennemi car il a un bouclier d'actif";
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
