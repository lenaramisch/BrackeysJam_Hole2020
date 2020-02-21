using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   public int score;

   void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
