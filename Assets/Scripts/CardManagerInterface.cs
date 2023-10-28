using UnityEngine;

namespace DefaultNamespace
{
    public class CardManagerInterface : MonoBehaviour
    {
        public CardValue cardValues()
        {
            return GameManager.instance.currentCardValue;
        }

        public CardManager cardManager()
        {
            return GameManager.instance.currentCardManager;
        }

        public void level0()
        {
            cardManager().chooseLevel0();
        }
        
        public void level1()
        {
            cardManager().chooseLevel1();
        }
        
        public void level2()
        {
            cardManager().chooseLevel2();
        }
        
        public void level3()
        {
            cardManager().chooseLevel3();
        }
        
        public void level4()
        {
            cardManager().chooseLevel4();
        }
        
        public void cost0()
        {
            cardManager().chooseCost0();
        }
        
        public void cost1()
        {
            cardManager().chooseCost1();
        }
        public void cost2()
        {
            cardManager().chooseCost2();
        }
        
        public void cost3()
        {
            cardManager().chooseCost3();
        }
        
        public void cost4()
        {
            cardManager().chooseCost4();
        }
        
        public void cost5()
        {
            cardManager().chooseCost5();
        }
        
        public void cost6()
        {
            cardManager().chooseCost6();
        }
        
        public void cost7()
        {
            cardManager().chooseCost7();
        }
        
        public void cost8()
        {
            cardManager().chooseCost8();
        }
        
        public void cost9()
        {
            cardManager().chooseCost9();
        }
        
        public void cost10()
        {
            cardManager().chooseCost10();
        }
        
        public void cost11()
        {
            cardManager().chooseCost11();
        }
        
        public void cost12()
        {
            cardManager().chooseCost12();
        }
        
        public void cost13()
        {
            cardManager().chooseCost13();
        }
        
        public void cost14()
        {
            cardManager().chooseCost14();
        }
        
        public void cost15()
        {
            cardManager().chooseCost15();
        }
        
        public void cost20()
        {
            cardManager().chooseCost20();
        }
        
        public void colourRed()
        {
            cardManager().chooseRed();
        }
        
        public void colourGreen()
        {
            cardManager().chooseGreen();
        }
        
        public void colourBlue()
        {
            cardManager().chooseBlue();
        }
        
        public void colourYellow()
        {
            cardManager().chooseYellow();
        }

        public void colourBlack()
        {
            cardManager().chooseBlack();
        }
        
        public void typeCharacter()
        {
            cardManager().chooseCharacter();
        }
        
        public void typeClimax()
        {
            cardManager().chooseClimax();
        }
        
        public void typeEvent()
        {
            cardManager().chooseEvent();
        }
        
        public void setWeiss()
        {
            cardManager().chooseWeissColour();
        }
        
        public void setSchwarz()
        {
            cardManager().chooseScwarzColour();
        }
        
        public void setBoth()
        {
            cardManager().chooseBothColour();
        }

        public void triggerBook()
        {
            cardManager().chooseBookTrigger();
        }
        
        public void triggerBounce()
        {
            cardManager().chooseBounceTrigger();
        }
        
        public void triggerBag()
        {
            cardManager().chooseBagTrigger();
        }
        
        public void triggerBar()
        {
            cardManager().chooseBarTrigger();
        }
        
        public void triggerChoice()
        {
            cardManager().chooseChoiceTrigger();
        }
        
        public void triggerShot()
        {
            cardManager().chooseShotTrigger();
        }
        
        public void triggerDoor()
        {
            cardManager().chooseDoorTrigger();
        }
        
        public void triggerStandby()
        {
            cardManager().chooseStandbyTrigger();
        }

        public void triggerSoul()
        {
            cardManager().chooseSoulTrigger();
        }

        public void triggerNone()
        {
            cardManager().chooseNoneTrigger();
        }

        public void triggerGate()
        {
            cardManager().chooseGateTrigger();
        }

        public void triggerNull()
        {
            cardManager().chooseNothingTrigger();
        }

        public void toggleEffect()
        {
            cardManager().toggleEffectText();
        }

        public void toggleFlavour()
        {
            cardManager().toggleFlavourText();
        }

        public void toggleJpName()
        {
            cardManager().toggleJpNameText();
        }

        public void effectBackup()
        {
            cardManager().chooseBackup();
        }

        public void effectAlarm()
        {
            cardManager().chooseAlarm();
        }
        
        public void effectNothing()
        {
            cardManager().chooseNoBackupAlarm();
        }

        public void soul0()
        {
            cardManager().choose0Soul();
        }

        public void soul1()
        {
            cardManager().choose1Soul();
        }

        public void soul2()
        {
            cardManager().choose2Soul();
        }
        
        public void soul3()
        {
            cardManager().choose3Soul();
        }

        public void resetCard()
        {
            cardManager().resetCardImage();
        }

        public void resetSet()
        {
            cardManager().resetSetImage();
        }

        public void fixUpTextSprites()
        {
            cardManager().fixUpTextSprites();
        }
    }
}