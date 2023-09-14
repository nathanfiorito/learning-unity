using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public static Contador instance;
    public int count = 0;
    public Text contadorText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            print("instance");
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCount() 
    {
        count++;
        contadorText.text = count.ToString();
    }
}
