using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<ObjectState> objectStates = new List<ObjectState>();
}

[Serializable]
public class ObjectState
{
    public string objectId;
    public bool isDestroyed;
}
