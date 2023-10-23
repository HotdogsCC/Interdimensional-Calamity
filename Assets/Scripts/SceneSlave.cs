using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSlave : MonoBehaviour
{
    public void LoadAScenePls(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
