using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MapSelect : MonoBehaviour
{
    public Sprite[] mapSprite = new Sprite[4];
    //public TextMeshProUGUI shoeName;
    public string[] mapNames = new string[4];
    public string[] mapObstacles = new string[4];
    int left = 0;
    int middle = 1;
    int right = 2;
    public ShoeMapManager smMan;
    int test = 0;

    void Awake()
    {
        smMan = GameObject.FindObjectOfType<ShoeMapManager>();
    }

    public void SelectMapName(TextMeshProUGUI shoeName)
    {
        shoeName.text = mapNames[middle];
    }
    public void SelectObstacle(TextMeshProUGUI shoeBonus)
    {
        shoeBonus.text = mapObstacles[middle];
    }
  
    public void NextLeftMap(Image leftImage)
    {
        left++;
        if (left == 4)
        {
            left = 0;
        }

       
        leftImage.sprite = mapSprite[left];
        
    }
    public void NextMiddleMap(Image middleImage)
    {

        middle++;
        if (middle == 4)
        {
            middle = 0;
        }

     
        middleImage.sprite = mapSprite[middle];
       
    }

    public void NextRightMap(Image rightImage)
    {
        right++;
        if (right == 4)
        {
            right = 0;
        }
      
        rightImage.sprite = mapSprite[right];
       
    }


    public void PreviousLeftMap(Image leftImage)
    {
        left--;
        if (left == -1)
        {
            left = 3;
        }


        leftImage.sprite = mapSprite[left];

    }
    public void PreviousMiddleMap(Image middleImage)
    {

        middle--;
        if (middle == -1)
        {
            middle = 3;
        }


        middleImage.sprite = mapSprite[middle];

    }

    public void PreviousRightMap(Image rightImage)
    {
        right--;
        if (right == -1)
        {
            right = 3;
        }

        rightImage.sprite = mapSprite[right];

    }

    public void SelectedMap(Image selectedMap)
    {
        selectedMap.sprite = mapSprite[middle];
    }

}
