using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultNamespace;
using SimpleFileBrowser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public CardManager characterManager;
    public CardManager climaxManager;
    public CardManager eventManager;

    public CardManager currentCardManager;
    
    public CardList cardList;
    
    public CardValue currentCardValue;
    public Dictionary<CardValue, CardElement> cardValueList;
    
    private readonly string PICS = "pics";
    private readonly string EXPORTS = "exports";
    private readonly string SAVE = "save";

    public GameObject newLoadPanel;
    private string cardFolder;
    
    public GameObject saveText;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        currentCardManager = characterManager;
        cardValueList = new Dictionary<CardValue, CardElement>();
    }
    
    private CardValue defaultCard = new CardValue()
    {
        level = 3,
        colour = Colour.YELLOW,
        cost = 1,
        setColour = SetColour.WEISS,
        trait1 = "wubbaboo",
        trait2 = "weeewoooo",
        traitCount = 2,
        trigger1 = Trigger.BOOK,
        trigger2 = Trigger.BOUNCE,
        name = "Bwoop Light, Roxanne",
        effect = "Bewoop",
        flavour = "Don't turn it on",
        setId = "R2D2-100 RR",
        power = 12000,
        copyright = "killla @killakorp",
        jpName = "moon runes lol",
        soul = 2,
        showEffect = true,
        showFlavour = true,
        showJpName = true,
        imagePosition = Vector3.zero,
        imageRotation = 0,
        imageScale = 1,
        setPosition = Vector3.zero,
        setRotation = 0,
        setScale = 1,
        backupAlarm1 = BackupAlarm.BACKUP,
        backupAlarm2 = BackupAlarm.NONE,
        cardType = CardType.CHARACTER
    };

    public void createCard()
    {
        createCard(null);
    }

    public void createCard(CardValue card)
    {
        var newCard = card ?? defaultCard.clone();
        if (currentCardValue != null && !currentCardValue.name.Equals(""))
        {
            newCard.setScale = currentCardValue.setScale;
            newCard.setPosition = currentCardValue.setPosition;
            newCard.setRotation = currentCardValue.setRotation;

            newCard.setColour = currentCardValue.setColour;
        }
        
        currentCardValue = newCard;
        setCardType();
        var cardElement = cardList.createCardElement(currentCardValue);
        cardValueList.Add(currentCardValue, cardElement);
        reloadCardImage();
        reloadSetImage();
        currentCardManager.setupCard(currentCardValue);
    }

    public void viewCard(CardValue cardValue)
    {
        if(cardValue != null)
            currentCardValue = cardValue;
        setCardType();
        reloadCardImage();
        reloadSetImage();
        currentCardManager.setupCard(currentCardValue);
    }

    public void udpateCardElement()
    {
        cardValueList[currentCardValue].SetValues(currentCardValue);
    }

    public void deleteCard(CardValue value)
    {
        if (currentCardValue == value)
        {
            cardValueList.Remove(currentCardValue);

            if (cardValueList.Count == 0)
            {
                createCard();
            }
            else
            {
                currentCardValue = cardValueList.First().Key;
                viewCard(currentCardValue);
            }
        }
        else
        {
            cardValueList.Remove(value);
        }
    }

    public GameObject characterPanel;
    public GameObject climaxPanel;
    public GameObject eventPanel;

    public void setCardType()
    {
        characterPanel.SetActive(false);
        climaxPanel.SetActive(false);
        eventPanel.SetActive(false);
        
        switch (currentCardValue.cardType)
        {
            case CardType.CHARACTER:
                currentCardManager = characterManager;
                characterPanel.SetActive(true);
                break;
            case CardType.CLIMAX:
                currentCardManager = climaxManager;
                climaxPanel.SetActive(true);
                break;
            case CardType.EVENT:
                currentCardManager = eventManager;
                eventPanel.SetActive(true);
                break;
        }
    }

    public void exportAllCards()
    {
        StartCoroutine(ExportAll());
    }
    
    IEnumerator ExportAll()
    {
        var current = currentCardValue;
        foreach (var cardValue in cardValueList.Keys)
        {
            viewCard(cardValue);
            yield return StartCoroutine(exportCard());
        }
        viewCard(current);
    }

    public void exportCurrentCard()
    {
        StartCoroutine(exportCard());
    }
    

    private WaitForEndOfFrame eof = new WaitForEndOfFrame();

    private IEnumerator exportCard()
    {
        yield return eof;
        
        var corners = new Vector3[4];
        currentCardManager.GetComponent<RectTransform>().GetWorldCorners(corners);
        var bottomLeft = Camera.main.WorldToScreenPoint(corners[0]);
        var topRight = Camera.main.WorldToScreenPoint(corners[2]);
        var width = (int)(topRight.x - bottomLeft.x);
        var height = (int)(topRight.y - bottomLeft.y);
        
        var imgTex = new Texture2D(width, height,TextureFormat.RGB24, false);
        imgTex.ReadPixels( new Rect(bottomLeft.x, bottomLeft.y, width, height), 0, 0 );
        imgTex.Apply();

        var imgBytes = imgTex.EncodeToPNG();

        if (!FileBrowserHelpers.DirectoryExists(cardFolder + @"/Exports"))
            FileBrowserHelpers.CreateFolderInDirectory(cardFolder, "Exports");
        
        File.WriteAllBytes(cardFolder + @"/Exports/" + currentCardValue.name + ".png", imgBytes);
    }

    public void NewSet()
    {
        StartCoroutine(showNewSetDialogue());
    }
    
    private IEnumerator showNewSetDialogue()
    {
        yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.Folders, false, null, null,
            "Choose folder to put cards in!", "Choose");

        if (!FileBrowser.Success) yield break;
            
        var folder = FileBrowser.Result[0];
        FileBrowserHelpers.CreateFolderInDirectory(folder, PICS);
        FileBrowserHelpers.CreateFolderInDirectory(folder, EXPORTS);
        FileBrowserHelpers.CreateFileInDirectory(folder, SAVE);

        cardFolder = folder;

        currentCardManager = characterManager;
        createCard();
        newLoadPanel.SetActive(false);
    }

    public void LoadSet()
    {
        StartCoroutine(showLoadSetDialogue());
    }
    
    private IEnumerator showLoadSetDialogue()
    {
        yield return FileBrowser.WaitForSaveDialog(FileBrowser.PickMode.Folders, false, null, null,
            "Load folder of cards", "Choose");

        if (FileBrowser.Success)
        {
            var folder = FileBrowser.Result[0];
            if (FileBrowserHelpers.FileExists(folder + "/" + SAVE))
            {
                cardFolder = folder;
                    
                var savedata = FileBrowserHelpers.ReadTextFromFile(folder + "/" + SAVE + ".json");
                var loadedCards = FromJson<CardLoader>(savedata).cards;
                foreach (var card in loadedCards)
                {
                    createCard(card);
                }
            }
        }
        newLoadPanel.SetActive(false);
    }

    public void reloadCardImage()
    {
        loadImageFromFile(currentCardManager.cardAnimeImage, currentCardValue.name);
        currentCardManager.resetCardImage();
    }
    
    public void reloadSetImage()
    {
        loadImageFromFile(currentCardManager.cardSetTransform.GetComponent<Image>(), "setImage");
        currentCardManager.resetSetImage();
    }

    private void loadImageFromFile(Image image, string cardName)
    {
        StartCoroutine(load(image, cardName));
    }
    
    private IEnumerator load(Image imageToSet, string cardName)
    {
        var fullPath =  cardFolder + "/" + PICS + "/"+ cardName;
        if (FileBrowserHelpers.FileExists(fullPath + @".jpg"))
            fullPath += @".jpg";
        else if (FileBrowserHelpers.FileExists(fullPath + @".png"))
            fullPath += @".png";

        if (FileBrowserHelpers.FileExists(fullPath))
        {
            var imageByteArray = File.ReadAllBytes(fullPath);
            var tex = new Texture2D(8, 8);
            if (!tex.LoadImage(imageByteArray)) yield break;
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero, 1f);
            imageToSet.sprite = sprite;
        }
    }

    public void saveSet()
    {
        List<CardValue> cards = cardValueList.Keys.ToList();
        var cardLoader = new CardLoader() { cards = cards };
        var jsonCards = ToJson(cardLoader);
        Debug.Log("Saving: " + jsonCards);
        File.WriteAllText(cardFolder + "/" + SAVE + ".json", jsonCards);
        saveText.SetActive(true);
        StartCoroutine(fadeOutText());
    }

    private WaitForSeconds fadeOutTimer = new WaitForSeconds(5);

    public IEnumerator fadeOutText()
    {
        yield return fadeOutTimer;
        saveText.SetActive(false);
    }
    
    private static string ToJson(object value)
    {
        return JsonUtility.ToJson(value, true);
    }

    private static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public GameObject helpPanel;

    public void openHelp()
    {
        helpPanel.SetActive(true);
    }

    public void closeHelp()
    {
        helpPanel.SetActive(false);
    }
}
