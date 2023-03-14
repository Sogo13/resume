using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{   public int money;
    public int total_money;
    public bool  firstBuy = false;
    public bool secondBuy = false;
    [SerializeField] Button firstBuys;
    [SerializeField] Button secondBuys;
    

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
     
     
     
     
    }




    public void ToMenu()
    {

        SceneManager.LoadScene(0);
    }
    
    

    public void BuyOne()
    {
        if (money >=10 && firstBuy == false)
        {
            firstBuy = true;
            money -= 10;
            PlayerPrefs.SetInt("money",money);
            PlayerPrefs.SetInt("firstBuy",firstBuy ? 1 : 0);
            firstBuys.interactable = true;

        }
        else
        {
            firstBuys.interactable = false;
        } 
    }
    
    public void BuyTwo()
    {
        if (money >=100 && secondBuy == false)
        {
            secondBuy = true;
            money -= 100;
            PlayerPrefs.SetInt("money",money);
            PlayerPrefs.SetInt("secondBuy",secondBuy ? 1 : 0);
            secondBuys.interactable = true;

        }
        else
        {
            secondBuys.interactable = false;
        } 
    }


    
    
    void Update(){

    }
    
        
    
}

