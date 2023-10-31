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
        Color cardImageColour;
        switch (value.colour)
        {
            case Colour.RED:
                ColorUtility.TryParseHtmlString("#e74c3c", out cardImageColour);
                cardColour.color = cardImageColour ;
                break;
            case Colour.YELLOW:
                ColorUtility.TryParseHtmlString("#f1c40f", out cardImageColour);
                cardColour.color = cardImageColour ;
                break;
            case Colour.GREEN:
                ColorUtility.TryParseHtmlString("#2ecc71", out cardImageColour);
                cardColour.color = cardImageColour ;
                break;
            case Colour.BLUE:
                ColorUtility.TryParseHtmlString("#2980b9", out cardImageColour);
                cardColour.color = cardImageColour ;
                break;
            case Colour.BLACK:
                ColorUtility.TryParseHtmlString("#2c3e50", out cardImageColour);
                cardColour.color = cardImageColour ;
                break;
            case Colour.WHITE:
                ColorUtility.TryParseHtmlString("#ecf0f1", out cardImageColour);
                cardColour.color = cardImageColour ;
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
