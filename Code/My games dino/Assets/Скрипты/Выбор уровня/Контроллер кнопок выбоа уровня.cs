using System.Runtime.InteropServices;
using UnityEngine;

public class Контроллеркнопоквыбоауровня : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private MapDisplay MapDisplay;
    private int currentIndex;

    private void Awake()
    {
        ChangrScriptableObject(0);
    }

    public void ChangrScriptableObject(int change)
    {
        currentIndex += change;
        if (currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
        else if (currentIndex > scriptableObjects.Length -1) currentIndex = 0;

        if (MapDisplay != null) MapDisplay.DisplayMap((Map)scriptableObjects[currentIndex]);

    }
}