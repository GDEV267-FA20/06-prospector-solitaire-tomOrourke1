using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Prospector : MonoBehaviour
{
    static public Prospector S;
    [Range(0,1)]
    public int style;

    [Header("Set in Inspector")]
    public TextAsset deckXML;
    public TextAsset style2XML;

    public TextAsset GetTextAsset(int style)
    {
        if (style == 0)
        {
            return deckXML;
        }
        else return style2XML;
    }

    [Header("Set Dynamically")]
    public Deck deck;

    private void Awake()
    {
        S = this;
    }


    private void Start()
    {

        deck = GetComponent<Deck>();
        deck.InitDeck(GetTextAsset(style).text);
        Deck.Shuffle(ref deck.cards);

        Card c;
        for (int cNum = 0; cNum < deck.cards.Count; cNum++)
        {
            c = deck.cards[cNum];
            c.transform.localPosition = new Vector3((cNum % 13) * 3, cNum / 13 * 4, 0);
        }
    }



}
