using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class CopyrightClick: MonoBehaviour, IPointerClickHandler
    {
        public CardManager CardManager;
        
        public TMP_InputField copyright;

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            switch (pointerEventData.button)
            {
                case PointerEventData.InputButton.Right:
                    CardManager.openSetColourPanel();
                    break;
                case PointerEventData.InputButton.Left:
                    copyright.Select();
                    break;
            }
        }
    }
}