using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public weapon weapon...
    public FloatingTextManager floatingTextManager;




    // Logic
    public int coins;
    public int xp;

    //floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    //Save State
    /*
    *Int preferedSkin
    *int coins
    *int ex
    *int weaponLevel
    */


    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += coins.ToString() + "|";
        s += xp.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change skin
        coins = int.Parse(data[1]);
        xp = int.Parse(data[2]);
        //Change weapon level


        Debug.Log("LoadState");
    }   
    
}
