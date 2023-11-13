using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Transform screenWrap;
    [SerializeField] Image[] bottomBackIcons;

    [SerializeField] Color selectedColor, unselectedColor;
    [SerializeField] int currentTab = 1;

    [SerializeField] GameObject[] allScreens;

    void Start()
    {
        SwitchTab(1);
    }

    public void SwitchTab(int tab)
    {
        bottomBackIcons[currentTab].color = unselectedColor;
        currentTab = tab;
        bottomBackIcons[currentTab].color = selectedColor;

        string[] tabNames = new string[] { "Tips", "Graph", "Chat", "Settings" };
        OpenScreen(tabNames[tab]);
    }

    public void OpenScreen(string name)
    {
        foreach (Transform t in screenWrap)
            Destroy(t.gameObject);

        foreach(var s in allScreens)
            if(s.name == name)
            {
                Instantiate(s, screenWrap);
                return;
            }
        Debug.Log("Screen name " + name + " does not exist!");
    }

}
