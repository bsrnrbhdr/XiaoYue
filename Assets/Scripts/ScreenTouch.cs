using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTouch : MonoBehaviour
{
    private float touchTime;
    public Text directionText;
    private Touch touch;
    private Vector2 touchStartPosition, touchEndPosition;
    public static string direction;
    public static float touchDensity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            for(int i=0;i< Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                    touchTime = Time.time;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    touchEndPosition = touch.position;
                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;
                    if (Time.time - touchTime <= 0.5)
                    {
                        if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                        {
                            direction = "Tapped";
                        }
                        else if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            direction = x > 0 ? "Right" : "Left";
                            touchDensity = x;

                        }
                        else
                        {
                            direction = y > 0 ? "Up" : "Down";
                            touchDensity = y;
                        }
                    }
                    else
                    {
                        // this is a long press or drag​
                        direction = "Attack";
                    }

                }
            }
        }
        else
        {
            direction = " ";

        }
        directionText.text = direction;
    }
}
