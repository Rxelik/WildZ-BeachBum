using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Instance
    public static Player Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [Header("Decks")]
    public List<Card> PlayerCards;
    public List<Card> sortedHand;
    public IEnumerator SortHand()
    {
        List<Card> redCards = new List<Card>();
        List<Card> yellowCards = new List<Card>();
        List<Card> blueCards = new List<Card>();
        List<Card> GreenCards = new List<Card>();
        foreach (var item in PlayerCards)
        {
            if (item._color == "Red")
            {
                redCards.Add(item);
                print("addeed" + redCards);
            }
            else if (item._color == "Yellow")
            {
                yellowCards.Add(item);
                print("addeed" + yellowCards);

            }
            else if (item._color == "Blue")
            {
                blueCards.Add(item);
                print("addeed" + blueCards);
            }
            else if (item._color == "Green")
            {
                GreenCards.Add(item);
                print("addeed" + GreenCards);
            }
        }
        yield return new WaitForSeconds(0.25f);
        AddToMain(redCards);
        yield return new WaitForSeconds(0.25f);
        AddToMain(yellowCards);
        yield return new WaitForSeconds(0.25f);
        AddToMain(blueCards);
        yield return new WaitForSeconds(0.25f);
        AddToMain(GreenCards);
        yield return new WaitForSeconds(0.25f);
        EventManager.Instance.SortHand?.Invoke(this, EventArgs.Empty);

    }
    public void AddToMain(List<Card> card)
    {

        for (int i = 9; i >= 0; i--)
        {
            foreach (var item in card)
            {
                if (item.CardNum == i)
                {
                    sortedHand.Add(item);
                }
            }
        }
    }
}
