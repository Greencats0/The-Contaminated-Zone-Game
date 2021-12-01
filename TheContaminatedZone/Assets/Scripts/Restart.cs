using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;
public class Restart : MonoBehaviour
{
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu"); // loads current scene
		Time.timeScale = 1;
	}
    public void RestartGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		Time.timeScale = 1;

    }
}