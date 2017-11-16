using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

class Scenario1Assembly01 : Scenario
{
    protected override void OnProgressCompleted()
    {
        base.OnProgressCompleted();

        Debug.Log("All goals reached. Switching to next scene");
        SceneManager.LoadScene("assembly02");
    }
}
