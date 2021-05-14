using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] bool autoplay = false;
    [SerializeField] float screenWidthInUnits = 16f;
    
    private Ball ball1;
    private float bound = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        ball1 = FindObjectOfType<Ball>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (autoplay && ball1.launched)
        {
            RepositionAt(ball1.transform.position.x);
        }
        else {
            var mp = Input.mousePosition;
            var screenUnitsWidth = (Screen.width / screenWidthInUnits);
            var mouseX = mp.x / screenUnitsWidth;
            RepositionAt(mouseX);
        }
    }

    private void RepositionAt(float newX)
    {
        var mouseXBounded = Mathf.Clamp(
            newX,
            bound,
            screenWidthInUnits - bound);
        transform.position = new Vector2(mouseXBounded, transform.position.y);
    }
}
