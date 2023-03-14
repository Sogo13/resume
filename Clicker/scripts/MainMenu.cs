using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] int money;
    
    public int total_money;
    public Text moneyText;
    public GameObject effect;
    public GameObject button;
    public AudioSource auidoSource;
    public bool firstBuy;
    public bool secondBuy;

    private void Start()
    {
        auidoSource = GetComponent<AudioSource>();
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        bool isFirst =  PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if (isFirst)
        {
            StartCoroutine(IdleFarm());
        }
        OfflineTime();

        firstBuy = PlayerPrefs.GetInt("firstBuy") == 1 ? true : false;
        secondBuy = PlayerPrefs.GetInt("secondBuy") == 1 ? true : false;
    }



    public void ButtonClick()
    {
        if (firstBuy && secondBuy)

        {money +=4;

        }
        else 
        { if (firstBuy)
            {
            money +=2;
            }
            else
            {
            money++;
            }
        }
        

          
 
        PlayerPrefs.SetInt("money",money);
        
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0f);
        auidoSource.Play();
    }
   
    public void OnClickUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }   


    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money",money);
        StartCoroutine(IdleFarm());


    }

    private void OfflineTime()
    {
        TimeSpan ts;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(string.Format("Вас не было {0} дней, {1} часов, {2} минут, {3} секунд",ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
            money += (int)ts.TotalSeconds;
            
        }
    }


 #if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)

    {
        if (pause)
        {
            PlayerPrefs.SetString("LastSession",DateTime.Now.ToString());
        }


    }
 #else
    private void OnApplicationQuit()
    {
      PlayerPrefs.SetString("LastSession",DateTime.Now.ToString());  
    }
 #endif
    public void ToAchievements()
    {
        PlayerPrefs.SetString("LastSession",DateTime.Now.ToString());
        SceneManager.LoadScene(1);
    }   
    public void ToShop()
    {
        PlayerPrefs.SetString("LastSession",DateTime.Now.ToString());
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {   
        moneyText.text = money.ToString();
        
        
    }
}
