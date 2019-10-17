using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public float speed;
    public int moveDistance;
    public int noMovement = 0;
    public int y = 0;
    public int progress = 0;
    public float calc = 0f;
    int limit = 1;
    public bool lose = false;
    public bool gameend = false;
   
    public TextMeshProUGUI playerScore;

    public GameObject player;
    
    public float ScreenWidth;
    // Start is called before the first frame update
    public PauseGame pausing;
    public Slider progressbar;
    int stop = 0;
    public ShoeSelect persist;
    int shoeSelection = 0;
    public Animator playeranimator;
    public RuntimeAnimatorController[] animations = new RuntimeAnimatorController[4];
    public Image shoeprogress;
    public Sprite[] shoeSprite = new Sprite[4];
    void Start()
    {
        
        shoeSelection = persist.GetShoeSelection();
        shoeprogress.sprite = shoeSprite[shoeSelection];
        playeranimator.runtimeAnimatorController = animations[shoeSelection];
        ScreenWidth = Screen.width;
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        lose = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausing.pause)
        {
            if (CrossPlatformInputManager.GetButtonDown("Down") && limit != 0)
            {

                limit--;
                y = -moveDistance;

            }
            else if (CrossPlatformInputManager.GetButtonDown("Up") && limit != 2)
            {
                limit++;
                y = moveDistance;
            }
            else
                y = noMovement;




            if (transform.position.x <= 67 && !lose)
            {
                Move(y);
            }

            else if (transform.position.x >= 67 && !lose && stop < 1)
            {
                gameend = true;
                //Debug.Log("youWin!");
                pausing.WinGame();
                stop++;
            }



            if (lose && stop < 1)
            {
                //Debug.Log("You LOSE!");
                gameend = true;
                pausing.LoseGame();
                stop++;
            }
        }
        
        
        
    }
  
    public void Move(int yMove)
    {
        
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, transform.position.y + y);
        progress = (int)transform.position.x;
        progressbar.value = progress;
        calc = (((float)progress / 67f) * (100f));
        
        if(calc > 0)
        {
            playerScore.text = ((int)calc).ToString();
        }
       

        


    }

}
