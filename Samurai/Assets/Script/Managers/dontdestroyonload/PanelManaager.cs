using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManaager : Singleton<PanelManaager>
{
    private Dictionary<panel, GameObject> panels = new();

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected override void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;

        base.OnDestroy();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        List<panel> removeList = new();

        foreach (var pair in panels)
        {
            if (pair.Value == null)
                removeList.Add(pair.Key);
        }

        foreach (var key in removeList)
            panels.Remove(key);
    }

    public void Open(panel panelType)
    {
        GameObject panelObject = null;

        if (!panels.TryGetValue(panelType, out panelObject) || panelObject == null)
        {
            GameObject prefab = Resources.Load<GameObject>(panelType.ToString());

            if (prefab == null) return;

            panelObject = Instantiate(prefab);
            panelObject.name = panelType.ToString();

            panels[panelType] = panelObject;
        }

        panelObject.SetActive(true);
    }

    public void Close(panel panelType)
    {
        if (panels.TryGetValue(panelType, out GameObject panelObject))
        {
            if (panelObject != null)
            {
                panelObject.SetActive(false);
            }
            else
            {
                panels.Remove(panelType);
            }
        }
    }

    public void CloseAll()
    {
        foreach (var pair in panels)
        {
            if (pair.Value != null)
                pair.Value.SetActive(false);
        }
    }
}