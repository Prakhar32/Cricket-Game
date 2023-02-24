using RotaryHeart;
using RotaryHeart.Lib.SerializableDictionary;

public enum BallType
{
    Spin, Fast
};

[System.Serializable]
public class ProbablityMapper : SerializableDictionaryBase<int, float> { }

[System.Serializable]
public class SelectionMapper : SerializableDictionaryBase<BallType, ProbablityMapper> { }