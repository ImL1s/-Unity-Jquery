using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class U
{

    /// <summary>
    /// * = AllGameObject
    /// # = GameObject -> name
    /// . = GameObject -> layer
    /// other = GameObject -> tag
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns
    public static GameObject Find(string name)
    {
        switch (name[0])
        {
            case '*':
                return FindAllObject();

            case '#':
                return FindGameObjectByTag(name.Split('#')[1]);

            case '.':
                return FindGameObjectByLayer(name.Split('.')[1]);

            
            default:
                return FindGameObjectByName(name);
        }
    }


    /// <summary>
    /// * = AllGameObject
    /// # = GameObject -> name
    /// . = GameObject -> layer
    /// other = GameObject -> tag
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject[] FindAll(string name)
    {
        switch (name[0])
        {
            case '*':
                return FindAllObjects();

            case '#':
                return FindGameObjectsByTag(name.Split('#')[1]);

            case '.':
                return FindGameObjectsByLayer(name.Split('.')[1]);

            default:
                return FindGameObjectsByName(name); ;
        }
    }



    private static GameObject FindGameObjectByTag(string tagName)
    {
        GameObject[] foundArray = FindSpecifiedObjects(go => go.tag == tagName);
        return foundArray.Length > 0 ? foundArray[0] : null;
    }

    private static GameObject[] FindGameObjectsByTag(string tagName)
    {
        return FindSpecifiedObjects(go => go.tag == tagName);
    }

    private static GameObject FindGameObjectByName(string name)
    {
        return GameObject.Find(name);
    }

    private static GameObject FindAllObject()
    {
        return GameObject.FindObjectOfType(typeof(GameObject)) as GameObject;
    }

    /// <summary>
    /// 找到所有的Gameobject
    /// </summary>
    /// <returns></returns>
    private static GameObject[] FindAllObjects()
    {
        return GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }

    /// <summary>
    /// 根據Layer name 找到Gameobject
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static GameObject FindGameObjectByLayer(string name)
    {
        GameObject[] foundArray = FindSpecifiedObjects(go => go.layer == LayerMask.NameToLayer(name), true);
        return  foundArray.Length > 0? foundArray[0] : null;
    }

    /// <summary>
    /// 根據Layer name 找到Gameobjects
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static GameObject[] FindGameObjectsByLayer(string name)
    {
        #region old
        //List<GameObject> foundList = new List<GameObject>();
        //GameObject[] findList = FindAllObjects();
        //int layer = LayerMask.GetMask(name);

        //foreach (var go in findList)
        //{
        //    if (go.layer == layer)
        //        foundList.Add(go);
        //}

        //return foundList.ToArray();
        #endregion

        return FindSpecifiedObjects(findGO => findGO.layer == LayerMask.GetMask(name));
    }

    /// <summary>
    /// 根據名字找到Gameobjects
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static GameObject[] FindGameObjectsByName(string name)
    {
        #region old
        //List<GameObject> foundArray = new List<GameObject>();
        //GameObject[] findList = FindAllObjects();

        //foreach (var item in foundArray)
        //{
        //    if (item.name == name)
        //        foundArray.Add(item);
        //}

        //return foundArray.ToArray(); 
        #endregion

        return FindSpecifiedObjects(findGO => findGO.name == name);
    }

    /// <summary>
    /// 根據表達式找到指定Gameobject
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="isSingle">是否只找第一個</param>
    /// <returns></returns>
    private static GameObject[] FindSpecifiedObjects(Func<GameObject,bool> expression, bool isSingle = false)
    {
        List<GameObject> foundList = new List<GameObject>();
        GameObject[] findList = FindAllObjects();
        
        foreach (var go in findList)
        {
            if (expression.Invoke(go))
            {
                foundList.Add(go);
                if (isSingle) break;
            }
        }

        return foundList.ToArray();
    }

}
