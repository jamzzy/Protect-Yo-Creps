using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShoeMapManager : MonoBehaviour
{


    public bool[] sold = new bool[4];
    public bool[] owned = new bool[4];
    public int points;
    public int[] cost = new int[4];
    public Sprite[] shoeSprite = new Sprite[4];
    public string[] shoeNames = new string[4];
    public string[] shoeBonuses = new string[4];
    int select = 0;
    int closetshoeselect = 0;
    public string ownedString = "Owned";
    public string shopKeeperbroke = "You can't afford that!";
    public string shopKeeperbuy = "Blessed! No refunds ah ah!";
    public string shopkeepermisc = "Nyeah eh!";
    public string shopkeepermisc2 = "You keep yo creps clean ahlie?";
    public string welcomeshop = "wagwan! Welcome to the shop!";
    public System.Random rnd = new System.Random();
    public int phrase = 0;

    public Animator closetanimator;
    public RuntimeAnimatorController[] closet = new RuntimeAnimatorController[4];

    public void ChangeChar(Image charcloset)
    {
        closetanimator = charcloset.GetComponent<Animator>();
        closetanimator.runtimeAnimatorController = closet[closetshoeselect];
    }
    public void KeeperBuy(TextMeshProUGUI keeper)
    {
        keeper.text = shopKeeperbuy;
    }
    public void KeeperTalk(TextMeshProUGUI keeper)
    {
        phrase = rnd.Next(0, 3);
        if (!owned[select])
        {
            if (points - cost[select] >= 0)
            {
                if (phrase == 1)
                {
                    keeper.text = shopkeepermisc;
                }
                else
                    keeper.text = shopkeepermisc2;
            }
            else
                keeper.text = shopKeeperbroke;
        }
        else
        {
            if (phrase == 1)
            {
                keeper.text = shopkeepermisc;
            }
            else
                keeper.text = shopkeepermisc2;
        }
    }
    public void KeeperWelcome(TextMeshProUGUI keeper)
    {
        keeper.text = welcomeshop;
    }

    // Start is called before the first frame update
    public void NextShoe(Image Select)
    {
        select++;
        if (select == 4)
        {
            select = 0;
        }
        Select.sprite = shoeSprite[select];
    }
    public void CurrentShoe(Image Select)
    {
      
        Select.sprite = shoeSprite[select];
    }

    public void PreviousShoe(Image Select)
    {
        select--;
        if (select == -1)
        {
            select = 3;
        }
        Select.sprite = shoeSprite[select];
    }

    public void SelectName(TextMeshProUGUI shoeName)
    {
        shoeName.text = shoeNames[select];
    }
    public void SelectBonus(TextMeshProUGUI shoeBonus)
    {
        if (owned[select])
        {
            shoeBonus.text = "";
        }
        else
            shoeBonus.text = shoeBonuses[select];
    }

    public void SelectNameCloset(TextMeshProUGUI shoeName)
    {
        shoeName.text = shoeNames[closetshoeselect];
    }
    public void SelectBonusCloset(TextMeshProUGUI shoeBonus)
    {
       
            shoeBonus.text = shoeBonuses[closetshoeselect];
    }

    public void CanBuy(Button buy)
    {
        if (!owned[select])
        {
            if (points - cost[select] >= 0)
            {
                buy.interactable = true;
            }
            else
                buy.interactable = false;
        }
        else
            buy.interactable = false;

    }
    public void BuyShoe()
    {
        points = points - cost[select];
        owned[select] = true;
    }
    public bool IsOwned(int check)
    {
        return owned[check];
    }
    public void CostText(TextMeshProUGUI selectCost)
    {
        if (owned[select])
        {
            selectCost.text = ownedString;
        }
        else
            selectCost.text = "Cost: " + cost[select].ToString();

    }
    public void GetPoints(TextMeshProUGUI player)
    {
        player.text = "Your Points: " + points.ToString();
    }

    public void NextShoeCloset(Image Shoe)
    {
        while (true)
        {
            closetshoeselect++;
            if(closetshoeselect == 4)
            {
                closetshoeselect = 0;
            }
            if (owned[closetshoeselect])
            {
                break;
            }
        }
        Shoe.sprite = shoeSprite[closetshoeselect];
    }

    public void PreviousShoeCloset(Image Shoe)
    {
        while (true)
        {
            closetshoeselect--;
            if (closetshoeselect == -1)
            {
                closetshoeselect = 3;
            }
            if (owned[closetshoeselect])
            {
                break;
            }
        }
        Shoe.sprite = shoeSprite[closetshoeselect];
    }
    
}
