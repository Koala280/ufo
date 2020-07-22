using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLoop : MonoBehaviour
{

    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels) {
            loadChildObjects(obj);
        }
    }


    void loadChildObjects(GameObject obj) {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.y;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++){
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(obj.transform.position.x, objectWidth * i, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

void repositionChildObjects(GameObject obj) {
    Transform[] children = obj.GetComponentsInChildren<Transform>();
    if (children.Length > 1)
    {
        GameObject firstChild = children[1].gameObject;
        GameObject lastChild = children[children.Length - 1].gameObject;
        float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;
        if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectWidth) {
            firstChild.transform.SetAsLastSibling();
            firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectWidth * 2, lastChild.transform.position.z);
        } else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectWidth) {
            lastChild.transform.SetAsFirstSibling();
            lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfObjectWidth * 2, firstChild.transform.position.z);
        }
    }
}
void LateUpdate() {
    foreach(GameObject obj in levels) {
        repositionChildObjects(obj);
    }
}
    // Update is called once per frame
    /* void Update()
    {
        
    } */
}
