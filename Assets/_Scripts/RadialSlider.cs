using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialSlider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    bool isPointerDown = false;
    private GameObject ship;
    private GameController gameController;
    private PlayerController playerController;

    void Start()
    {
        ship = GameObject.Find("Player 1(Clone)");
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        playerController = ship.GetComponent<PlayerController>();

    }

    // Called when the pointer enters our GUI component.
    // Start tracking the mouse
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("TrackPointer");
    }

    // Called when the pointer exits our GUI component.
    // Stop tracking the mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("TrackPointer");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        //Debug.Log("mousedown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        //Debug.Log("mousedown");
    }

    // mainloop
    IEnumerator TrackPointer()
    {
        var ray = GetComponentInParent<GraphicRaycaster>();
        var input = FindObjectOfType<StandaloneInputModule>();

        var text = GetComponentInChildren<Text>();

        /*if (ship == null)
        {
            ship = GameObject.Find("Player 1");
            if(ship == null)
                Debug.Log("No ship still component");
            playerController = ship.GetComponent<PlayerController>();
        }*/

        if (ray != null && input != null)
        {   
            while (Application.isPlaying && gameController.getPlayerTurn() == playerController.GetMyTurn() && gameController.getNumBolts() == 0)
            {

                // TODO: if mousebutton down
                if (isPointerDown)
                {
                    Vector2 localPos; // Mouse position  
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos);

                    // local pos is the mouse position.
                    float angle = (Mathf.Atan2(-localPos.y, localPos.x) * 180f / Mathf.PI) / 360f;

                    if (angle < 0)
                    {
                        angle = angle + 360f / 360f;
                    }
                    
                    GetComponent<Image>().fillAmount = angle;
                    
                    GetComponent<Image>().color = Color.Lerp(Color.green, Color.red, angle);
                    text.color = Color.Lerp(Color.green, Color.red, angle);

                    angle = -angle;

                    text.text = ((int)(-angle * 360f)).ToString();
                    ship.transform.eulerAngles = new Vector3(0f, 0f, angle * 360f);

                }

                yield return 0;
            }
        }
        else
            UnityEngine.Debug.LogWarning("Could not find GraphicRaycaster and/or StandaloneInputModule");
    }





}