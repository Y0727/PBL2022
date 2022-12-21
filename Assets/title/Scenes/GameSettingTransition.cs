using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettingTransition : MonoBehaviour
{
	public void OnClickHomeButton()
	{
		SceneManager.LoadScene("GameSettingScene", LoadSceneMode.Single);
	}
}
