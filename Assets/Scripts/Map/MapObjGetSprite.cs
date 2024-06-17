using UnityEngine;

public class GetSprites : MonoBehaviour
{
    private static GetSprites instance;
    public static GetSprites Instance { get => instance;}

    public Sprite[] mapObjSprites;

    private void Awake()
    {
        instance = this;
    }

    public Sprite GetSprite(MyData mydata)
    {
        switch (mydata.type)
        {
            case MapObjectType.Ground:
                return mapObjSprites[0];
            case MapObjectType.Wall: 
                return mapObjSprites[1];
            case MapObjectType.Water:
                return mapObjSprites[2];
            case MapObjectType.BoxTarget: 
                return mapObjSprites[3];
            case MapObjectType.Flag: 
                return mapObjSprites[4];
            case MapObjectType.Player: 
                return mapObjSprites[5];
            case MapObjectType.Box:
                int spriteidx = 6; 
                if (mydata.boxMaterialType == BoxMaterialType.Stone)
                {
                    spriteidx += 3;
                }
                if(mydata.boxKEType== KEDeliverType.None)
                {

                }
                else if (mydata.boxKEType == KEDeliverType.Calculate)
                {
                    spriteidx += 1;
                }
                else if (mydata.boxKEType == KEDeliverType.StaticDir)
                {
                    spriteidx += 2;
                }
                return mapObjSprites[spriteidx];
        }
        return mapObjSprites[0];
    }
}