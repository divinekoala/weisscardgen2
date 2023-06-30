using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public CardValue cardValue;

    public GameObject levelPanel;
    public GameObject costPanel;
    public GameObject colourPanel;
    public GameObject cardTypePanel;
    public GameObject setColourPanel;
    public GameObject triggerPanel;
    public GameObject cardTextPanel;

    private string components = "Components/";
    private string backups = "Backup/";
    private string cardBases = "Card Bases/";
    private string costs = "Cost/";
    private string triggers = "Trigger/";
    private string jpName = "JP Name/";
    private string level = "Level/";
    private string characters = "Character/";
    private string climaxes = "Climax/";
    private string events = "Event/";
    private string bars = "Bars/";
    private string weiss = "Weiss/";
    private string both = "Both/";
    private string schwarz = "Schwarz/";

    public RectTransform cardImage;
    public RectTransform setImage;

    public void setupCard(CardValue value)
    {
        cardValue = value;
        setCardBase();
        setLevelImage();
        setCostImage();
        nameText.text = cardValue.name;
        jpNameText.text = cardValue.jpName;
        flavourText.text = cardValue.flavour;
        powerText.text = cardValue.power.ToString();
        setIdText.text = cardValue.setId;
        trait1Text.text = cardValue.trait1;
        trait2Text.text = cardValue.trait2;
        copyrightText.text = cardValue.copyright;
        effectText.text = cardValue.effect;
        setTriggerImage(trigger1Image, cardValue.trigger1);
        setTriggerImage(trigger2Image, cardValue.trigger2);
        setAlarmBackup(alarmBackup1, cardValue.backupAlarm1);
        setAlarmBackup(alarmBackup2, cardValue.backupAlarm2);
        setCardImage();
        setSetImage();
    }

    #region Image

    private void setCardImage()
    {
        cardImage.localPosition = cardValue.imagePosition;
        cardImage.localRotation = Quaternion.Euler(0, 0, cardValue.imageRotation);
        cardImage.localScale = new Vector3(cardValue.imageScale, cardValue.imageScale, 1);
    }
    
    private void setSetImage()
    {
        setImage.localPosition = cardValue.setPosition;
        setImage.localRotation = Quaternion.Euler(0, 0, cardValue.setRotation);
        setImage.localScale = new Vector3(cardValue.setScale, cardValue.setScale, 1);
    }
    

    #endregion

    #region Level
    
    public Image levelImage;

    public void openLevelPanel()
    {
        levelPanel.SetActive(true);
    }

    public void closeLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    public void setLevelImage()
    {
        var levelPath = components + level + cardValue.colour + "l" + cardValue.level;
        levelImage.sprite = Resources.Load<Sprite>(levelPath);
        GameManager.instance.udpateCardElement();
    }

    public void chooseLevel0()
    {
        cardValue.level = 0;
        setLevelImage();
        closeLevelPanel();
    }
    
    public void chooseLevel1()
    {
        cardValue.level = 1;
        setLevelImage();
        closeLevelPanel();
    }
    
    public void chooseLevel2()
    {
        cardValue.level = 2;
        setLevelImage();
        closeLevelPanel();
    }
    
    public void chooseLevel3()
    {
        cardValue.level = 3;
        setLevelImage();
        closeLevelPanel();
    }

    #endregion

    #region Cost

    public Image costImage;

    public void openCostPanel()
    {
        costPanel.SetActive(true);
    }

    public void closeCostPanel()
    {
        costPanel.SetActive(false);
    }
    
    public void setCostImage()
    {
        var levelPath = components + costs + "c" + cardValue.cost;
        costImage.sprite = Resources.Load<Sprite>(levelPath);
        GameManager.instance.udpateCardElement();
    }
    
    public void chooseCost0()
    {
        cardValue.cost = 0;
        setCostImage();
        closeCostPanel();
        
    }
    
    public void chooseCost1()
    {
        cardValue.cost = 1;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost2()
    {
        cardValue.cost = 2;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost3()
    {
        cardValue.cost = 3;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost4()
    {
        cardValue.cost = 4;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost5()
    {
        cardValue.cost = 5;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost6()
    {
        cardValue.cost = 6;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost7()
    {
        cardValue.cost = 7;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost8()
    {
        cardValue.cost = 8;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost9()
    {
        cardValue.cost = 9;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost10()
    {
        cardValue.cost = 10;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost11()
    {
        cardValue.cost = 11;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost12()
    {
        cardValue.cost = 12;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost13()
    {
        cardValue.cost = 13;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost14()
    {
        cardValue.cost = 14;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost15()
    {
        cardValue.cost = 15;
        setCostImage();
        closeCostPanel();
    }
    
    public void chooseCost20()
    {
        cardValue.cost = 20;
        setCostImage();
        closeCostPanel();
    }

    #endregion

    #region Trigger

    private int triggerChanging;
    public Image trigger1Image;
    public Image trigger2Image;

    public void openTriggerPanel1()
    {
        triggerPanel.SetActive(true);
        triggerChanging = 1;
    }
    
    public void openTriggerPanel2()
    {
        triggerPanel.SetActive(true);
        triggerChanging = 2;
    }

    public void closeTriggerPanel()
    {
        triggerPanel.SetActive(false);
    }

    private void setTriggerImage(Image triggerImage, string trigger)
    {
        if (trigger == Trigger.NOTHING)
            triggerImage.color = new Color(0, 0, 0, 0);
        else
        {
            triggerImage.color = Color.white;
            var costPath = components + triggers + trigger;
            triggerImage.sprite = Resources.Load<Sprite>(costPath);
        }
        
    }

    public void chooseTrigger1(string trigger)
    {
        cardValue.trigger1 = trigger;
        setTriggerImage(trigger1Image, trigger);
        closeTriggerPanel();
    }

    public void chooseTrigger2(string trigger)
    {
        cardValue.trigger2 = trigger;
        setTriggerImage(trigger2Image, trigger);
        closeTriggerPanel();
    }

    public void chooseNoneTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.NONE);
        else
            chooseTrigger2(Trigger.NONE);
    }
    
    public void chooseSoulTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.SOUL);
        else
            chooseTrigger2(Trigger.SOUL);
    }
    
    public void chooseBookTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.BOOK);
        else
            chooseTrigger2(Trigger.BOOK);
    }
    
    public void chooseBounceTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.BOUNCE);
        else
            chooseTrigger2(Trigger.BOUNCE);
    }
    
    public void chooseShotTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.SHOT);
        else
            chooseTrigger2(Trigger.SHOT);
    }
    
    public void chooseGateTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.GATE);
        else
            chooseTrigger2(Trigger.GATE);
    }
    
    public void chooseChoiceTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.CHOICE);
        else
            chooseTrigger2(Trigger.CHOICE);
    }
    
    public void chooseDoorTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.DOOR);
        else
            chooseTrigger2(Trigger.DOOR);
    }
    
    public void chooseStandbyTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.STANDBY);
        else
            chooseTrigger2(Trigger.STANDBY);
    }
    
    public void chooseBarTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.BAR);
        else
            chooseTrigger2(Trigger.BAR);
    }
    
    public void chooseBagTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.BAG);
        else
            chooseTrigger2(Trigger.BAG);
    }
    
    public void chooseNothingTrigger()
    {
        if (triggerChanging == 1)
            chooseTrigger1(Trigger.NOTHING);
        else
            chooseTrigger2(Trigger.NOTHING);
    }

    #endregion

    #region Text Values

    public TMP_InputField flavourText;

    public void setFlavourText()
    {
        cardValue.flavour = flavourText.text;
    }
    
    public TMP_InputField effectText;

    public void setEffectText()
    {
        cardValue.effect = effectText.text;
    }
    
    public TMP_InputField jpNameText;

    public void setjpNameText()
    {
        cardValue.jpName = jpNameText.text;
    }

    public TMP_InputField nameText;

    public void setNameText()
    {
        cardValue.name = nameText.text;
        GameManager.instance.udpateCardElement();
    }
    
    public TMP_InputField setIdText;

    public void setSetIDText()
    {
        cardValue.setId = setIdText.text;
    }
    
    public TMP_InputField powerText;

    public void setPowerText()
    {
        int result;
        var res = int.TryParse(powerText.text, out result);
        if(res)
            cardValue.power = result;
    }
    
    public TMP_InputField trait1Text;

    public void setTrait1Text()
    {
        cardValue.trait1 = trait1Text.text;
    }
    
    public TMP_InputField trait2Text;

    public void setTrait2Text()
    {
        cardValue.trait2 = trait2Text.text;
    }
    
    public TMP_InputField copyrightText;

    public void setCopyrightText()
    {
        cardValue.copyright = copyrightText.text;
    }

    #endregion

    public Image cardBase;
    public Image jpNameImage;
    public Image topBar;
    public Image bottomBar;

    public GameObject effectSpacer;
    public GameObject jpNameObj;
    public GameObject flavourJpNameSpacer;

    public GameObject cardEffectObj;
    public GameObject flavourObj;

    private void setCardBase()
    {
        string basePath = "";

        switch (cardValue.cardType)
        {
            case CardType.CHARACTER:
                basePath = components + cardBases + characters + cardValue.setColour + "/" + 
                               cardValue.colour + cardValue.soul + "s" + cardValue.traitCount + "t";
                break;
            
            case CardType.EVENT:
                basePath = components + cardBases + events + cardValue.setColour + "/" + cardValue.colour;
                break;
            
            case CardType.CLIMAX:
                basePath = components + cardBases + climaxes + cardValue.setColour + "/" + cardValue.colour;
                break;
        }
        cardBase.sprite = Resources.Load<Sprite>(basePath);

        var jpNamePath = components + jpName + cardValue.colour;
        jpNameImage.sprite = Resources.Load<Sprite>(jpNamePath);

        var effectTopBarsPath = components + bars + cardValue.colour + "bar";
        var effectBottomBarsPath = components + bars + "b" + cardValue.colour + "bar";
        topBar.sprite = Resources.Load<Sprite>(effectTopBarsPath);
        bottomBar.sprite = Resources.Load<Sprite>(effectBottomBarsPath);
        
        if(cardValue.setColour.Equals(SetColour.SCHWARZ))
            copyrightText.textComponent.color = Color.white;
        else
            copyrightText.textComponent.color = Color.black;

        toggleJpName();
        toggleEffect();
        toggleFlavour();
    }

    #region toggleText

    public void tggleCardTextPanel()
    {
        cardTextPanel.SetActive(!cardTextPanel.activeSelf);
    }

    public Toggle effectToggle;
    public Toggle flavourToggle;
    public Toggle jpNameToggle;

    public void toggleEffectText()
    {
        cardValue.showEffect = effectToggle.isOn;
        toggleEffect();
    }
    
    public void toggleFlavourText()
    {
        cardValue.showFlavour = flavourToggle.isOn;
        toggleFlavour();
    }
    
    public void toggleJpNameText()
    {
        cardValue.showJpName = jpNameToggle.isOn;
        toggleJpName();
    }

    private void toggleEffect()
    {
        cardEffectObj.SetActive(cardValue.showEffect);
        setFlavourJpNameSpacer();
        effectSpacer.SetActive(cardValue.cardType != CardType.CLIMAX && cardValue.showJpName);
    }

    private void toggleFlavour()
    {
        flavourObj.SetActive(cardValue.showFlavour);
        setFlavourJpNameSpacer();
    }

    private void toggleJpName()
    {
        effectSpacer.SetActive(cardValue.cardType != CardType.CLIMAX && cardValue.showJpName);
        jpNameObj.SetActive(cardValue.showJpName);
        setFlavourJpNameSpacer();
    }

    private void setFlavourJpNameSpacer()
    {
        flavourJpNameSpacer.SetActive( cardValue.showFlavour && cardValue.showJpName && (!cardValue.showEffect || cardValue.cardType == CardType.CLIMAX ));
    }

    #endregion

    #region Soul

    public GameObject soulPanel;

    public void openSoulPanel()
    {
        soulPanel.SetActive(true);
    }

    public void choose0Soul()
    {
        cardValue.soul = 0;
        setCardBase();
        closeSoulPanel();
    }
    
    public void choose1Soul()
    {
        cardValue.soul = 1;
        setCardBase();
        closeSoulPanel();
    }
    
    public void choose2Soul()
    {
        cardValue.soul = 2;
        setCardBase();
        closeSoulPanel();
    }
    
    public void choose3Soul()
    {
        cardValue.soul = 3;
        setCardBase();
        closeSoulPanel();
    }

    public void closeSoulPanel()
    {
        soulPanel.SetActive(false);
    }

    #endregion

    #region alarmBackup

    private int alarmBackup;
    public GameObject alarmBackupPanel;

    public Image alarmBackup1;
    public Image alarmBackup2;

    public void openAlarmBackupPanel1()
    {
        alarmBackup = 1;
        alarmBackupPanel.SetActive(true);
    }
    
    public void openAlarmBackupPanel2()
    {
        alarmBackup = 2;
        alarmBackupPanel.SetActive(true);
    }

    private void setAlarmBackup(Image alarmBackupImage, string backupAlarm)
    {
        if(backupAlarm.Equals(BackupAlarm.NONE))
            alarmBackupImage.color = new Color(0, 0, 0, 0);
        else
            alarmBackup1.color = Color.white;
        
        var alarmBackupPath = components + backups + backupAlarm;
        alarmBackupImage.sprite = Resources.Load<Sprite>(alarmBackupPath);
        alarmBackupPanel.SetActive(false);
    }

    public void chooseAlarm()
    {
        if (alarmBackup == 1)
        {
            cardValue.backupAlarm1 = BackupAlarm.ALARM;
            setAlarmBackup(alarmBackup1, cardValue.backupAlarm1);
        }
        else
        {
            cardValue.backupAlarm2 = BackupAlarm.ALARM;
            setAlarmBackup(alarmBackup2, cardValue.backupAlarm2);
        }
    }
    
    public void chooseBackup()
    {
        if (alarmBackup == 1)
        {
            cardValue.backupAlarm1 = BackupAlarm.BACKUP;
            setAlarmBackup(alarmBackup1, cardValue.backupAlarm1);
        }
        else
        {
            cardValue.backupAlarm2 = BackupAlarm.BACKUP;
            setAlarmBackup(alarmBackup2, cardValue.backupAlarm2);
        }
    }

    public void chooseNoBackupAlarm()
    {
        if (alarmBackup == 1)
        {
            cardValue.backupAlarm1 = BackupAlarm.NONE;
            setAlarmBackup(alarmBackup1, cardValue.backupAlarm1);
        }
        else
        {
            cardValue.backupAlarm2 = BackupAlarm.NONE;
            setAlarmBackup(alarmBackup2, cardValue.backupAlarm2);
        }
    }

    #endregion

    #region Colour

    public void openColourPanel()
    {
        colourPanel.SetActive(true);
    }

    public void chooseRed()
    {
        cardValue.colour = Colour.RED;
        setCardBase();
        setLevelImage();
        colourPanel.SetActive(false);
        GameManager.instance.udpateCardElement();
    }
    
    public void chooseBlue()
    {
        cardValue.colour = Colour.BLUE;
        setCardBase();
        setLevelImage();
        colourPanel.SetActive(false);
        GameManager.instance.udpateCardElement();
    }
    
    public void chooseGreen()
    {
        cardValue.colour = Colour.GREEN;
        setCardBase();
        setLevelImage();
        colourPanel.SetActive(false);
        GameManager.instance.udpateCardElement();
    }
    
    public void chooseYellow()
    {
        cardValue.colour = Colour.YELLOW;
        setCardBase();
        setLevelImage();
        colourPanel.SetActive(false);
        GameManager.instance.udpateCardElement();
    }

    #endregion

    #region cardType

    public void openCardTypePanel()
    {
        cardTypePanel.SetActive(true);
    }

    public void chooseCharacter()
    {
        cardValue.cardType = CardType.CHARACTER;
        changeCardType();
        cardTypePanel.SetActive(false);
    }
    
    public void chooseClimax()
    {
        cardValue.cardType = CardType.CLIMAX;
        changeCardType();
        cardTypePanel.SetActive(false);
    }
    
    public void chooseEvent()
    {
        cardValue.cardType = CardType.EVENT;
        changeCardType();
        cardTypePanel.SetActive(false);
    }

    public void changeCardType()
    {
        GameManager.instance.viewCard(null);
    }

    #endregion

    #region setColour

    public void openSetColourPanel()
    {
        setColourPanel.SetActive(true);
    }

    public void chooseWeissColour()
    {
        cardValue.setColour = SetColour.WEISS;
        setCardBase();
        setColourPanel.SetActive(false);
    }
    
    public void chooseScwarzColour()
    {
        cardValue.setColour = SetColour.SCHWARZ;
        setCardBase();
        setColourPanel.SetActive(false);
    }
    
    public void chooseBothColour()
    {
        cardValue.setColour = SetColour.BOTH;
        setCardBase();
        setColourPanel.SetActive(false);
    }
    
    #endregion

    public Image cardAnimeImage;
    public RectTransform cardSetTransform;

    public void resetCardImage()
    {
        cardImage.localPosition = Vector3.zero;
        cardImage.localRotation = Quaternion.Euler(0,0,0);
        cardImage.localScale = Vector3.one;
    }

    public void resetSetImage()
    {
        cardSetTransform.localPosition = Vector3.zero;
        cardSetTransform.localRotation = Quaternion.Euler(0,0,0);
        cardSetTransform.localScale = Vector3.one;
    }
}
