using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    private GameObject scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = scoreManager.GetComponent<ScoreManager>().score.ToString();
    }

    
}
