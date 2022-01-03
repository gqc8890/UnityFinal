using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemysave : MonoBehaviour
{
    public void Save()
	{
		PlayerPrefs.SetFloat("EmenyPosX1", transform.position.x);
		PlayerPrefs.SetFloat("EmenyPosY1", transform.position.y);
		PlayerPrefs.SetFloat("EmenyPosZ1", transform.position.z);
		Debug.Log("2333");
		PlayerPrefs.SetFloat("EmenyRotX1", transform.rotation.eulerAngles.x);
		PlayerPrefs.SetFloat("EmenyRotY1", transform.rotation.eulerAngles.y);
		PlayerPrefs.SetFloat("EmenyRotZ1", transform.rotation.eulerAngles.z);

	}

	public void Load()
	{
		float emenyPosX = PlayerPrefs.GetFloat("EmenyPosX1");
		float emenyPosY = PlayerPrefs.GetFloat("EmenyPosY1");
		float emenyPosZ = PlayerPrefs.GetFloat("EmenyPosZ1");

		float emenyRotX = PlayerPrefs.GetFloat("EmenyRotX1");
		float emenyRotY = PlayerPrefs.GetFloat("EmenyRotY1");
		float emenyRotZ = PlayerPrefs.GetFloat("EmenyRotZ1");


		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

		transform.position = new Vector3(emenyPosX, emenyPosY, emenyPosZ);
		transform.rotation = Quaternion.Euler(emenyRotX, emenyRotY, emenyRotZ);
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
	}
}
