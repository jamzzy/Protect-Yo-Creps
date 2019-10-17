using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Shoe : MonoBehaviour
{
    public Sprite[] shoeSprite = new Sprite[4];
    //public TextMeshProUGUI shoeName;
    public string[] shoeNames = new string[4];
    public string[] shoeBonuses = new string[4];
    int left = 0;
    int middle = 1;
    int right = 2;
    public ShoeMapManager smMan;
    int test = 0;
    public string notOwned = "Locked: Purchase In shop";

    public ShoeSelect persist;

    void Awake()
    {
        smMan = GameObject.FindObjectOfType<ShoeMapManager>();
    }

    public void SelectName(TextMeshProUGUI shoeName)
    {
        shoeName.text = shoeNames[middle];
    }
    public void SelectBonus(TextMeshProUGUI shoeBonus)
    {

        if (smMan.IsOwned(middle))
        {
            shoeBonus.text = shoeBonuses[middle];
        }
        else
            shoeBonus.text = notOwned;
    }

    

    public void NextLeftShoe(Image leftImage)
    {
        left++;
        if(left == 4)
        {
            left = 0;
        }
        
      
        leftImage.sprite = shoeSprite[left];
     
    }
    public void NextMiddleShoe(Image middleImage)
    {

        middle++;
        if(middle == 4)
        {
            middle = 0;
        }
        
      
        middleImage.sprite = shoeSprite[middle];
      
    }
   
    public void NextRightShoe(Image rightImage)
    {
        right++;
        if (right == 4)
        {
            right = 0;
        }
        
        rightImage.sprite = shoeSprite[right];
      
    }


    public void PreviousLeftShoe(Image leftImage)
    {
        left--;
        if (left == -1)
        {
            left = 3;
        }

       
        leftImage.sprite = shoeSprite[left];
      
    }
    public void PreviousMiddleShoe(Image middleImage)
    {

        middle--;
        if (middle == -1)
        {
            middle = 3;
        }

      
        middleImage.sprite = shoeSprite[middle];
      
    }

    public void PreviousRightShoe(Image rightImage)
    {
        right--;
        if (right == -1)
        {
            right = 3;
        }
     
        rightImage.sprite = shoeSprite[right];
       
    }

    public void SelectedShoe(Image selected)
    {
        selected.sprite = shoeSprite[middle];
    }

    public void ShoeLeftLock(GameObject LeftP)
    {
        if (smMan.IsOwned(left))
        {
            LeftP.SetActive(false);
        }
        else
            LeftP.SetActive(true);
    }
    public void ShoeMidLock(GameObject MiddleP)
    {
        if(smMan.IsOwned(middle))
        {
            MiddleP.SetActive(false);
        }
        else
            MiddleP.SetActive(true);
    }
    public void ShoeRightLock(GameObject RightP)
    {
        if (smMan.IsOwned(right))
        {
            RightP.SetActive(false);
        }
        else
            RightP.SetActive(true);
    }
    public void DisableNextNotOwned(Button next)
    {
        if (smMan.IsOwned(middle))
        {
            next.interactable = true;
        }
        else
            next.interactable = false;
    }

    public void PlayGame()
    {
        persist.SetShoeSelection(middle);
        //Debug.Log(persist.GetShoeSelection());
        //SceneManager.LoadScene(1);
    }

}
