using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
