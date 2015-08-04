using UnityEngine;

class IllegalWordTest : MonoBehaviour 
{
    // Use this for initialization
    void Start()
    {
        IllegalWord.init("illegalWords");

        print(IllegalWord.filter("阿靠他祖宗斯达 阿斯达援助交际fuck靠他祖宗asdfuck"));

        print(IllegalWord.hasKeyWord("阿斯阿斯靠他祖宗达大多数阿斯请求而设分会"));
    }
}
