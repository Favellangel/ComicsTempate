using UnityEngine;

public class Pages : MonoBehaviour
{
    public PageSwaper[] pages;
    public GameObject[] UIPages;

    private int index;
    
    private void Awake()
    {
        //pages = FindObjectsOfType<PageSwaper>(true);
    }

    public bool NextPage()
    {
        if (index >= pages.Length - 1) return false;

        HideCurrentPage();
        index++;
        ShowCurrentPage();

        return true;
    }

    private void HideCurrentPage()
    {
        pages[index].gameObject.SetActive(false);
        UIPages[index].gameObject.SetActive(false);
    }

    public bool PreviousPage()
    {
        if (index <= 0) return false;
        
        pages[index].gameObject.SetActive(false);
        UIPages[index].gameObject.SetActive(false);
        index--;
        ShowCurrentPage();

        return true;
    }


    private void ShowCurrentPage()
    {
        pages[index].transform.position = Vector3.zero;
        pages[index].gameObject.SetActive(true);
        UIPages[index].gameObject.SetActive(true);
    }
}
