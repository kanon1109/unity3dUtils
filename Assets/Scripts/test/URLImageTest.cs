using UnityEngine;

public class URLImageTest:MonoBehaviour
{
    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Resources.Load("Prefabs/URLImage") as GameObject;
            go = MonoBehaviour.Instantiate(go);
            go.transform.SetParent(this.transform);
            go.transform.localPosition = new Vector3(-200 + 100 * i, 0);
            go.transform.localScale = Vector3.one;
            URLImage urlImage = go.GetComponent<URLImage>();
            urlImage.load("http://127.0.0.1/urlImageTest/test.png", "", false);
        }

    }

}