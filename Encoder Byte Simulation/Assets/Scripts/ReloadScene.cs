using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void Reload() {
        Debug.Log("Reload");
        SceneManager.LoadScene("SampleScene");
    }
}
