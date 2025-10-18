using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Town : MonoBehaviour
{
    public bool inBattle = false;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlayMusic("Village");
    }

    // Update is called once per frame
    void Update()
    {
        if(inBattle == true)
        {
            SceneManager.LoadScene("BattleSystem");
        }
    }
}
