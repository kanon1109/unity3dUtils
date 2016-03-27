using UnityEngine;
using System.Collections;
using UnityEngine.UI;
class RandomNameTest : MonoBehaviour
{
    void Start()
    {
        RandomName.init("Assets/xml/names.xml", "names");
        for(int i = 0; i < 200; ++i)
        {
            print(RandomName.getRandomName());
        }
    }

    void Update()
    {

    }
}
