using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float dampingSpeed = 0.05f;
        [SerializeField] private float scaleSpeed = 0.05f;

        public bool isSetPic;

        private RectTransform _draggingObject;
        private Vector3 _initialMouseVector;
        private Vector3 _velocity;

        public CardManager cardManager;

        private bool isClicked;

        public void Awake()
        {
            _draggingObject = transform as RectTransform;
        }
        
        public void OnPointerClick(PointerEventData eventData) // 3
        {
            print("I was clicked");
            Debug.Log(eventData.hovered);
        }

        private void Update()
        {
            if (!isClicked) return;
            
            var dragScale = Input.mouseScrollDelta.y * scaleSpeed;
            var localScale = _draggingObject.localScale;
            _draggingObject.localScale = new Vector3(localScale.x + dragScale, localScale.y + dragScale,
                localScale.z + dragScale);
            if (isSetPic)
                cardManager.cardValue.setScale = _draggingObject.localScale.x;
            else
                cardManager.cardValue.imageScale = _draggingObject.localScale.x;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingObject, eventData.position,
                    eventData.pressEventCamera, out var globalMousePosition))
                _initialMouseVector = _draggingObject.position - globalMousePosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                {
                    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingObject, eventData.position,
                            eventData.pressEventCamera, out var globalMousePosition))
                    {
                        _draggingObject.position = Vector3.SmoothDamp(_draggingObject.position, globalMousePosition,
                            ref _velocity,
                            dampingSpeed);
                        if (isSetPic)
                            cardManager.cardValue.setPosition = _draggingObject.localPosition;
                        else
                            cardManager.cardValue.imagePosition = _draggingObject.localPosition;
                    }
                    
                    // transform.position = eventData.position;
                    //
                    // if (isSetPic)
                    //     cardManager.cardValues.setPosition = eventData.position;
                    // else
                    //     cardManager.cardValues.imagePosition = eventData.position;

                    break;
                }
                case PointerEventData.InputButton.Right:
                {
                    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingObject, eventData.position,
                            eventData.pressEventCamera, out var globalMousePosition))
                    {
                        var newMouseVector = _draggingObject.position - globalMousePosition;

                        var angleRotated = Vector3.Angle(_initialMouseVector, newMouseVector);
                        var crossProduct = Vector3.Cross(_initialMouseVector, newMouseVector);
                        if (crossProduct.z < 0)
                            angleRotated = -angleRotated;

                        _draggingObject.Rotate(Vector3.forward, angleRotated);
                        if (isSetPic)
                            cardManager.cardValue.setRotation = _draggingObject.localRotation.eulerAngles.z;
                        else
                            cardManager.cardValue.imageRotation = _draggingObject.localRotation.eulerAngles.z;

                        _initialMouseVector = _draggingObject.position - globalMousePosition;
                    }

                    break;
                }
                case PointerEventData.InputButton.Middle:
                default:
                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isClicked = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isClicked = false;
        }
    }
}