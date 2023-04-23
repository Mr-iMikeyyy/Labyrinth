

public class StringUtils {

    public int GetNodeX(string nodeName) {
        string[] splitName = nodeName.Split('_');
        return int.Parse(splitName[1]);
    }

    public int GetNodeY(string nodeName) {
        string[] splitName = nodeName.Split('_');
        return int.Parse(splitName[2]);
    }

}