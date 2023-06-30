using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CardList : MonoBehaviour
    {
        public static CardList instance;

        public void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);   
        }

        public GameObject cardElement;
        public Transform cardListContent;

        public CardElement createCardElement(CardValue card)
        {
            var newCardElement = Instantiate(cardElement, cardListContent);
            var cardEle = newCardElement.GetComponent<CardElement>();
            cardEle.SetValues(card);
            return cardEle;
        }
    }
}