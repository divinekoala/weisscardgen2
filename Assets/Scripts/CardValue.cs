using System;
using UnityEngine;

[Serializable]
public class CardValue
{
    public int level;
    public string colour;
    public int cost;
    public string effect;
    public string flavour;
    public string name;
    public string jpName;
    public int power;
    public string setId;
    public string trait1;
    public string trait2;
    public int traitCount;
    public string setColour;
    public int soul;
    public string trigger1;
    public string trigger2;
    public string copyright;
    public string cardType;

    public string backupAlarm1;
    public string backupAlarm2;

    public float imageScale;
    public float imageRotation;
    public Vector3 imagePosition;

    public float setScale;
    public float setRotation;
    public Vector3 setPosition;

    public bool showEffect;
    public bool showFlavour;
    public bool showJpName;

    public CardValue clone()
    {
        return new CardValue()
        {
            level = level,
            colour = colour,
            cost = cost,
            effect = effect,
            flavour = flavour,
            name = name,
            jpName = jpName,
            power = power,
            setId = setId,
            trait1 = trait1,
            trait2 = trait2,
            traitCount = traitCount,
            setColour = setColour,
            soul = soul,
            trigger1 = trigger1,
            trigger2 = trigger2,
            copyright = copyright,
            cardType = cardType,
            backupAlarm1 = backupAlarm1,
            backupAlarm2 = backupAlarm2,
            imageScale = imageScale,
            imageRotation = imageRotation,
            imagePosition = imagePosition,
            setScale = setScale,
            setPosition = setPosition,
            setRotation = setRotation,
            showEffect = showEffect,
            showFlavour = showFlavour,
            showJpName = showJpName

        };
    }
}