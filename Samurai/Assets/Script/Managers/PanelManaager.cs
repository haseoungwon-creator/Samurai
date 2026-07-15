using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PanelManaager : Singleton<PanelManaager>
{
    [SerializeField] GameObject clone = null; 

    Dictionary<panel,GameObject> dictionary = new Dictionary<panel,GameObject>();

    public void Open(panel panel,string message)
    {
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", "");

            dictionary.Add(panel, clone);

            DontDestroyOnLoad(clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }
    }
}
