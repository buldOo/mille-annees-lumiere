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
    public TMP_Text textTitle;
    public TMP_Text textDistance;
    public TMP_Text textSpeed;
    public GameObject gameObjectCard;
    public GameObject gameObjectHand;
    
    // Start is called before the first frame update
    void Start()
    {
        var player1Hand = GameObject.Find("GameManager").GetComponent<GameRound>().player1.Stack;
        var player2Hand = GameObject.Find("GameManager").GetComponent<GameRound>().player2.Stack;

        if (transform.tag == "playerOne")
        {
            var offset = -360;
            player1Hand.ForEach(card => {
                textDescr.text = card.Description;
                textTitle.text = "Carte " + card.Type;
                if(card.Type == "Distance") {
                    textDistance.text = card.Distance.ToString();
                } else {
                    textDistance.text = "";
                };
                if(card.Type == "Speed") {
                    if (!card.IsCounter){
                    textSpeed.text = card.Speed.ToString();
                    } else {
                        textSpeed.text = "";
                    }
                } else {
                    textSpeed.text = "";
                }
                GameObject gameObjectHand = Instantiate(gameObjectCard, new Vector3(offset, 0, 0), Quaternion.identity) as GameObject;
                gameObjectHand.transform.SetParent (GameObject.FindGameObjectWithTag("playerOne").transform, false);
                offset += 120;
            });
        } else {
            var offset = -360;
            player2Hand.ForEach(card => {
                textDescr.text = card.Description;
                textTitle.text = "Carte " + card.Type;
                if(card.Type == "Distance") {
                    textDistance.text = card.Distance.ToString();
                } else {
                    textDistance.text = "";
                };
                if(card.Type == "Speed") {
                    if (!card.IsCounter){
                    textSpeed.text = card.Speed.ToString();
                    } else {
                        textSpeed.text = "";
                    }
                } else {
                    textSpeed.text = "";
                }
                GameObject gameObjectHand = Instantiate(gameObjectCard, new Vector3(offset, 0, 0), Quaternion.identity) as GameObject;
                gameObjectHand.transform.SetParent (GameObject.FindGameObjectWithTag("playerTwo").transform, false);
                offset += 120;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
