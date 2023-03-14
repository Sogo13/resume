using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achiv : MonoBehaviour
{

    public int money;
    
    [SerializeField] Button firstAch;
    [SerializeField] Button secAch;
    [SerializeField] Button thirAch;
    [SerializeField] Button fourAch;
    [SerializeField] Button fifthAch;
    [SerializeField] Button sixAch;
    [SerializeField] bool  isFirst;
    [SerializeField] bool  isTwo;
    [SerializeField] bool  isThree;
    [SerializeField] bool  isFour;
    [SerializeField] bool  isFive;
    [SerializeField] bool  isSix;


   
    
    
    void Start()
    {   
        money = PlayerPrefs.GetInt("money");
        isFirst =  PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if(money >= 10 && !isFirst)
        {
            firstAch.interactable = true;

        }
        else
        {
            firstAch.interactable = false;
        } 


        




    }

    public void GetFirst()
    {   
        int money = PlayerPrefs.GetInt("money");
        money +=10;
        

        PlayerPrefs.SetInt("money",money);
       
        isFirst = true;
        PlayerPrefs.SetInt("isFirst",isFirst ? 1 : 0);

    }
    



    public void ToMenu()
    {

        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
