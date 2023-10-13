using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHospital : MonoBehaviour, Interactable
{
    public void Interact()
    {
        SceneManager.Instance().LoadScene("HospitalScene");
    }
}
