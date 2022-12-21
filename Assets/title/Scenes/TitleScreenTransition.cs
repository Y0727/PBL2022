using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenTransition : MonoBehaviour
{
	public void OnClickHomeButton()
	{
		SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
	}
}