using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minBorder = 1f;
    [SerializeField] float maxBorder = 15f;
    [SerializeField] float WorldUnits = 16f;


    //cashed references
    GameStatus theGameStatus;
    Ball theBall; //IMPORTANT! we cache them not to overload our game and to find  it at the START method and not at the UPDATE method without wasting resources each frame
    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<Ball>();
        theGameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minBorder , maxBorder);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoplayEnabled())
        {
            return theBall.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width*WorldUnits;
        }
    }
}
