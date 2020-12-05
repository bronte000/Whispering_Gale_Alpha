using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSaveData : MonoBehaviour
{
    public string player_name;
    private int file_number;

    /*
    <List of keys>
    player_name --> its key is file_number
    (file_number)_tutorial_house
    (file_number)_tutorial_walk
    (file_number)_tutorial_run
    
    (file_number)_quest11 (Grandpa's time capsule)
    (file_number)_quest12
    (file_number)_quest13
    (file_number)_quest14 (Grandma's time capsule)
    (file_number)_quest15
    (file_number)_quest16 (hidden quest)
    (file_number)_quest17 (Louis's time capsule; final quest)

    ex) player_name = "ctp321", file_number = 0 --> then keys are: 0_tutorial_house, 0_quest11, ...

    For file_number, the value is an int.
    For all keys excluding file_number:
        value = 0(not started), 1(hasStarted), 2(completed)

    */

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(player_name))
        {
            Debug.Log("existing save file");
            file_number = PlayerPrefs.GetInt(player_name);
        }
        else
            Debug.Log("ERROR: this save file does not exist");
    }

    public int[] GetStoryData(int fileNumber)
    {
        int quest11 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest11");
        int quest12 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest12");
        int quest13 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest13");
        int quest14 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest14");
        int quest15 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest15");
        int quest16 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest16");
        int quest17 = PlayerPrefs.GetInt(fileNumber.ToString() + "_quest17");

        return new int[] { quest11, quest12, quest13, quest14, quest15, quest16, quest17 };
    }

    public int[] GetTutorialData(int fileNumber)
    {
        int tutorial_house = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_house");
        int tutorial_walk = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_walk");
        int tutorial_run = PlayerPrefs.GetInt(fileNumber.ToString() + "_tutorial_run");

        return new int[] { tutorial_house, tutorial_walk, tutorial_run };
    }
}
