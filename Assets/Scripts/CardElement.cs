using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardElement : MonoBehaviour
{
    private CardValue _cardValue;
    
    public TMP_Text cardText;
    public Image cardColour;
    public Button viewCard;
    public Button deleteCard;

    public void Start()
    {
        deleteCard.onClick.AddListener(Delete);
        viewCard.onClick.AddListener(() => GameManager.instance.viewCard(_cardValue));
    }

    public void SetValues(CardValue value)
    {
        _cardValue = value;
        cardText.text = value.level + "/" + value.cost + " - " + value.name;
        switch (value.colour)
        {
            case Colour.RED:
                cardColour.color = Color.red;
                break;
            case Colour.YELLOW:
                cardColour.color = Color.yellow;
                break;
            case Colour.GREEN:
                cardColour.color = Color.green;
                break;
            case Colour.BLUE:
                cardColour.color = Color.blue;
                break;
        }
    }

    private void Delete()
    {
        GameManager.instance.deleteCard(_cardValue);
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        viewCard.onClick.RemoveAllListeners();
        deleteCard.onClick.RemoveAllListeners();
    }
}
