using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue4_Trigger : MonoBehaviour
{
    private GameObject louis, john;
    //private bool dia4; // false if dialogue4 hasn't started, true if it has started

    public string player_name;
    public GameObject dialogue4;

    // Start is called before the first frame update
    void Start()
    {
        //dia4 = false; //세이브 기능이 없으니까...에휴
        louis = GameObject.Find("Louis");
        john = GameObject.Find("john");
        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(player_name).ToString() + "_quest11"))
            if (PlayerPrefs.GetInt(PlayerPrefs.GetInt(player_name).ToString() + "_quest11") == 2)
                this.GetComponent<Dialogue4_Trigger>().enabled = false;
        StartCoroutine(this.CheckLouis());
    }

    IEnumerator CheckLouis()
    {
        if (Mathf.Abs(louis.transform.position.x - this.transform.position.x) > 10.0f)
            yield return new WaitForSeconds(0.5f);
        else
            Dialogue4Time();
    }

    private void Dialogue4Time()
    {
        john.GetComponent<John_Controller>().BeforeDialogue4(louis);
        dialogue4.GetComponent<DialogueTrigger>().TriggerDialogue();
        //dia4 = true;
    }
}
