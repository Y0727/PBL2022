using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserSettingButtonScript : MonoBehaviour
{
	public void OnClickUserSettingButton()
	{
		SceneManager.LoadScene("UserSettingScene", LoadSceneMode.Single);
	}
 
   
}
